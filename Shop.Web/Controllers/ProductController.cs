using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Web.Configuration;
using Shop.Web.Models.Response;
using Shop.Web.Models.Response.Products;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Shop.Web.ViewModels.Products;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<ProductController> _logger;
        private readonly ShopRoutes _routeOptions;

        public ProductController(ILogger<ProductController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._routeOptions = configuration.GetSection("Routes").Get<ShopRoutes>();

        }

        public async Task<ActionResult> Index()
        {
            ProductListResponse productListResponse = new ProductListResponse();
            try
            {
                var httpClient = new HttpClient(this.httpClientHandler);
                var response = await httpClient.GetAsync(_routeOptions.Products.List);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productListResponse = JsonConvert.DeserializeObject<ProductListResponse>(apiResponse);
                }

                return View(productListResponse.Data);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }

            return View();
        }


        public async Task<ActionResult> Details(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                var httpClient = new HttpClient(this.httpClientHandler);
                var response = await httpClient.GetAsync(_routeOptions.Products.Get + $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content?.ReadAsStringAsync();
                    productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                }

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }

            return View(productResponse.Data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProductViewModel productCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                productCreateRequest.RequestUser = 3;

                var httpClient = new HttpClient(this.httpClientHandler);

                StringContent content = new StringContent(JsonConvert.SerializeObject(productCreateRequest), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_routeOptions.Products.Create, content);

                string apiResponse = await response.Content.ReadAsStringAsync();

                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                ViewBag.Message = baseResponse.Message;
                ViewBag.Success = baseResponse.Success;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                ViewBag.Message = baseResponse.Message;
            }

            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                var httpClient = new HttpClient(this.httpClientHandler);
                var response = await httpClient.GetAsync(_routeOptions.Products.Get + $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content?.ReadAsStringAsync();
                    productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                }

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }

            return View(productResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateProductViewModel productRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                productRequest.RequestUser = 3;

                var httpClient = new HttpClient(this.httpClientHandler);

                StringContent content = new StringContent(JsonConvert.SerializeObject(productRequest), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_routeOptions.Products.Update, content);

                string apiResponse = await response.Content.ReadAsStringAsync();

                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                if(response.IsSuccessStatusCode) 
                {
                    return RedirectToAction(nameof(Index));
                } 
                else 
                {
                    ViewBag.Message = baseResponse.Message;
                    return View();
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                ViewBag.Message = baseResponse.Message;
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                var httpClient = new HttpClient(this.httpClientHandler);
                var response = await httpClient.GetAsync(_routeOptions.Products.Get + $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content?.ReadAsStringAsync();
                    productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                }

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }

            return View(productResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProductDeleteRequest productDeleteRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                productDeleteRequest.RequestUser = 3;

                var httpClient = new HttpClient(this.httpClientHandler);

                StringContent content = new StringContent(JsonConvert.SerializeObject(productDeleteRequest), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_routeOptions.Products.Delete, content);

                string apiResponse = await response.Content.ReadAsStringAsync();

                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = baseResponse.Message;
                    return View();
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                ViewBag.Message = baseResponse.Message;
                return View();
            }
        }
    }
}
