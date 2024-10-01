using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ST10257937.FunctionApp
{
    public static class StoreTableInfo
    {
        [Function("StoreTableInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string tableName = "CustomerProfiles";
            string partitionKey = req.Query["partitionKey"];
            string rowKey = req.Query["rowKey"];
            string data = req.Query["data"];
            string firstName = req.Query["firstName"];
            string lastName = req.Query["lastName"];
            string phoneNumber = req.Query["phoneNumber"];
            string email = req.Query["Email"];

            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(partitionKey) || string.IsNullOrEmpty(rowKey) || string.IsNullOrEmpty(data))
            {
                return new BadRequestObjectResult("Table name, partition key, row key, and data must be provided.");
            }

            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var serviceClient = new TableServiceClient(connectionString);
            var tableClient = serviceClient.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync();

            var entity = new TableEntity(partitionKey, rowKey)
            {
                ["Data"] = data,
                ["FirstName"] = firstName,
                ["LastName"] = lastName,
                ["PhoneNumber"] = phoneNumber,
                ["Email"] = email
            };

            await tableClient.AddEntityAsync(entity);

            return new OkObjectResult("Data added to table");
        }
    }
}