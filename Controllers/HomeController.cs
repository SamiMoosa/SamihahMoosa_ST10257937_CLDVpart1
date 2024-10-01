//using Microsoft.AspNetCore.Mvc;
//using ST10257937cldv.Models;
//using ST10257937cldv.Services;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Diagnostics;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace ST10257937cldv.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly BlobService _blobService;
//        private readonly TableService _tableService;
//        private readonly QueueService _queueService;
//        private readonly FileService _fileService;
//        private readonly ILogger<HomeController> _logger;
//        private readonly IHttpClientFactory _httpClientFactory;

//        //public HomeController(BlobService blobService, TableService tableService, QueueService queueService, FileService fileService, ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
//        //{
//        //    _blobService = blobService;
//        //    _tableService = tableService;
//        //    _queueService = queueService;
//        //    _fileService = fileService;
//        //    _logger = logger;
//        //    _httpClientFactory = httpClientFactory;
//        //}

//        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
//        {
//            _httpClientFactory = httpClientFactory;
//            _logger = logger;
//        }


//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> UploadImage(IFormFile file)
//        {
//            if (file != null)
//            {
//                try
//                {
//                    using var httpClient = _httpClientFactory.CreateClient();
//                    using var stream = file.OpenReadStream();
//                    var content = new StreamContent(stream);
//                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

//                    string url = $"https://samipart2.azurewebsites.net/api/UploadBlob?code=0tm3otLr6bnqULmTDfRlPXbhNEXNAfLnW0p_vdBvbNswAzFu6GoYaQ%3D%3D={file.FileName}";
//                    var response = await httpClient.PostAsync(url, content);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                    else
//                    {
//                        _logger.LogError($"Error submitting image: {response.ReasonPhrase}");
//                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError($"Exception occurred while submitting image: {ex.Message}");
//                }
//            }
//            else
//            {
//                _logger.LogError("No image file provided");
//            }

//            return View("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
//        {
//            if (profile != null && ModelState.IsValid)
//            {
//                try
//                {
//                    var httpClient = _httpClientFactory.CreateClient();
//                    var url = "https://samipart2.azurewebsites.net/api/StoreTableInfo?code=B9SD9C9WSmFMeKsulvdAHrJF2dfu1iwZGphucenMDcMvAzFueeEOWA%3D%3D";
//                    var response = await httpClient.PostAsJsonAsync(url, profile);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                    else
//                    {
//                        _logger.LogError($"Error submitting customer profile: {response.ReasonPhrase}");
//                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError($"Exception occurred while submitting customer profile: {ex.Message}");
//                }
//            }
//            else
//            {
//                _logger.LogError("Invalid customer profile or model state");
//            }

//            return View("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> ProcessOrder(string orderId)
//        {
//            if (!string.IsNullOrEmpty(orderId))
//            {
//                try
//                {
//                    var httpClient = _httpClientFactory.CreateClient();
//                    var url = "https://samipart2.azurewebsites.net/api/ProcessQueueMessage?code=d8c0q0H7NJ5UDhH8BHj_MZ4Qg2DkE-A_mB2qCKAeuYnAAzFuQ3ay6A%3D%3D"; // Replace with your actual endpoint URL
//                    var response = await httpClient.PostAsync(url, new StringContent(orderId));

//                    if (response.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                    else
//                    {
//                        _logger.LogError($"Error processing order: {response.ReasonPhrase}");
//                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError($"Exception occurred while processing order {orderId}: {ex.Message}");
//                }
//            }
//            else
//            {
//                _logger.LogError("Order ID is null or empty");
//            }

//            return View("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> UploadContract(IFormFile file)
//        {
//            if (file != null)
//            {
//                try
//                {
//                    using var httpClient = _httpClientFactory.CreateClient();
//                    using var stream = file.OpenReadStream();
//                    var content = new StreamContent(stream);
//                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

//                    string url = "https://samipart2.azurewebsites.net/api/UploadFile?code=cALq067xOzt8SJlQz7FZOQ5IUTSByVuqDfnHaO4g-YuKAzFutKhNxg%3D%3D{file.FileName}";
//                    var response = await httpClient.PostAsync(url, content);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                    else
//                    {
//                        _logger.LogError($"Error uploading contract: {response.ReasonPhrase}");
//                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError($"Exception occurred while uploading contract: {ex.Message}");
//                }
//            }
//            else
//            {
//                _logger.LogError("No contract file provided");
//            }

//            return View("Index");
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using ST10257937cldv.Models;
using ST10257937cldv.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration; // Add this
using System.Net.Http;
using System.Threading.Tasks;

namespace ST10257937cldv.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration; // Add IConfiguration

        public HomeController(
            IHttpClientFactory httpClientFactory,
            ILogger<HomeController> logger,
            IConfiguration configuration) // Inject IConfiguration
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration; // Set configuration
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();
                    using var stream = file.OpenReadStream();
                    var content = new StreamContent(stream);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                    // Get the URL from configuration
                    string url = _configuration["AzureFunctions:UploadBlobUrl"];
                    url += $"&blobName={file.FileName}";

                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting image: {response.ReasonPhrase}");
                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting image: {ex.Message}");
                }
            }
            else
            {
                _logger.LogError("No image file provided");
            }
           

            return View("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
        //{
        //    if (profile != null && ModelState.IsValid)
        //    {
        //        try
        //        {
        //            using var httpClient = _httpClientFactory.CreateClient();
        //            string url = _configuration["AzureFunctions:StoreInfoTableUrl"];
        //            var response = await httpClient.PostAsJsonAsync(url, profile);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                _logger.LogError($"Error submitting customer profile: {response.ReasonPhrase}");
        //                _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"Exception occurred while submitting customer profile: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        _logger.LogError("Invalid customer profile or model state");
        //    }

        //    return View("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();

                    // Prepare the request URI with query parameters
                    var requestUri = $"\"https://samipart2.azurewebsites.net/api/StoreTableInfo?code=B9SD9C9WSmFMeKsulvdAHrJF2dfu1iwZGphucenMDcMvAzFueeEOWA%3D%3D&tableName=CustomerProfiles&partitionKey={profile.PartitionKey}&rowKey={profile.RowKey}&data={profile}&firstName={profile.FirstName}&lastName={profile.LastName}&phoneNumber={profile.PhoneNumber}&Email={profile.Email}";

                    // Send an HTTP POST request to your Azure Function
                    var response = await httpClient.PostAsync(requestUri, null);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error submitting client info: {response.ReasonPhrase}");
                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while submitting client info: {ex.Message}");
                }
            }

            return View("Index", profile);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderId)
        {
            if (!string.IsNullOrEmpty(orderId))
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();
                    string url = _configuration["AzureFunctions:ProcessQueueMessageUrl"];
                    url += $"&message=Processing order {orderId}";

                    var response = await httpClient.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error processing order: {response.ReasonPhrase}");
                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while processing order {orderId}: {ex.Message}");
                }
            }
            else
            {
                _logger.LogError("Order ID is null or empty");
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadContract(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    using var httpClient = _httpClientFactory.CreateClient();
                    using var stream = file.OpenReadStream();
                    var content = new StreamContent(stream);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                    string url = _configuration["AzureFunctions:UploadFileUrl"];
                    url += $"&fileName={file.FileName}";

                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError($"Error uploading contract: {response.ReasonPhrase}");
                        _logger.LogError($"Response content: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occurred while uploading contract: {ex.Message}");
                }
            }
            else
            {
                _logger.LogError("No contract file provided");
            }

            return View("Index");
        }
    }
}
