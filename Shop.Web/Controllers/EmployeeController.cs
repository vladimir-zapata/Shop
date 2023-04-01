//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using Shop.Web.Configuration;
//using Shop.Web.Models;
//using Shop.Web.Models.Response;
//using Shop.Web.Models.Response.Employees;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace Shop.Web.Controllers
//{
//    public class EmployeeController : Controller
//    {
//        HttpClientHandler httpClientHandler = new HttpClientHandler();
//        private readonly ILogger<EmployeeController> logger;
//        private readonly ShopRoutes routesOptions;
//        private readonly ILogger<EmployeeController> _logger;
//        private readonly ShopRoutes _routeOptions;

//        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configuration)
//        {
//            this._logger = logger;
//            this._routeOptions = configuration.GetSection("Routes").Get<ShopRoutes>();

//        }
//    }

//    public async Task<ActionResult> Index()
//    {
//        EmployeeListResponse EmployeeListResponse = new EmployeeListResponse();
//        try
//        {
//            var httpClient = new HttpClient(this.httpClientHandler);
//            var response = await httpClient.GetAsync(RouteOptions.Employees.List);

//            if (response.IsSuccessStatusCode)
//            {
//                string apiResponse = await response.Content.ReadAsStringAsync();
//                EmployeeListResponse = JsonConvert.DeserializeObject<EmployeeListResponse>(apiResponse);
//            }

//            return ViewResult(EmployeeListResponse.Data);
//        }
//        catch (Exception ex)
//        {
//            this._logger.LogError(ex.Message);
//        }

//        return ViewResult();
//    }

//    public async Task<ActionResult> Details(int id)
//    {
//        EmployeeResponse productResponse = new EmployeeResponse();

//        try
//        {
//            var httpClient = new HttpClient(this.httpClientHandler);
//            var response = await httpClient.GetAsync(RouteOptions.Employees.Get + $"/{id}");

//            if (response.IsSuccessStatusCode)
//            {
//                string apiResponse = await response.Content?.ReadAsStringAsync();
//                EmployeeResponse = JsonConvert.DeserializeObject<EmployeeResponse>(apiResponse);
//            }

//        }
//        catch (Exception ex)
//        {
//            this._logger.LogError(ex.Message);
//        }

//        return ViewResult(EmployeeResponse.Data);
//    }

//    [HttpGet]
//    public ActionResult Create()
//    {
//        return View();
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<ActionResult> Create(CreateEmployeeViewModel EmployeeCreateRequest)
//    {
//        BaseResponse baseResponse = new BaseResponse();

//        try
//        {
//            EmployeeCreateRequest.RequestUser = 3;

//            var httpClient = new HttpClient(this.httpClientHandler);

//            StringContent content = new StringContent(JsonConvert.SerializeObject(EmployeeCreateRequest), Encoding.UTF8, "application/json");

//            var response = await httpClient.PostAsync(RouteOptions.Employees.Create, content);

//            string apiResponse = await response.Content.ReadAsStringAsync();

//            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

//            ViewBag.Message = baseResponse.Message;
//            ViewBag.Success = baseResponse.Success;
//        }
//        catch (Exception ex)
//        {
//            this._logger.LogError(ex.Message);
//            ViewBag.Message = baseResponse.Message;
//        }

//        return ViewResult();
//    }

//    public async Task<ActionResult> Edit(int id)
//    {
//        EmployeeResponse productResponse = new EmployeeResponse();

//        try
//        {
//            var httpClient = new HttpClient(this.httpClientHandler);
//            var response = await httpClient.GetAsync(RouteOptions.Employees.Get + $"/{id}");

//            if (response.IsSuccessStatusCode)
//            {
//                string apiResponse = await response.Content?.ReadAsStringAsync();
//                productResponse = JsonConvert.DeserializeObject<EmployeeResponse>(apiResponse);
//            }

//        }
//        catch (Exception ex)
//        {
//            this._logger.LogError(ex.Message);
//        }

//        return ViewResult(EmployeeResponse.Data);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<ActionResult> Edit(UpdateEmployeeViewModel productRequest)
//    {
//        BaseResponse baseResponse = new BaseResponse();

//        try
//        {
//            productRequest.RequestUser = 3;

//            var httpClient = new HttpClient(this.httpClientHandler);

//            StringContent content = new StringContent(JsonConvert.SerializeObject(productRequest), Encoding.UTF8, "application/json");

//            var response = await httpClient.PostAsync(RouteOptions.Employees.Update, content);

//            string apiResponse = await response.Content.ReadAsStringAsync();

//            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

//            if (response.IsSuccessStatusCode)
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            else
//            {
//                ViewBag.Message = baseResponse.Message;
//                return ViewResult();
//            }
//        }
//        catch (Exception ex)
//        {
//            this._logger.LogError(ex.Message);
//            ViewBag.Message = baseResponse.Message;
//            return ViewResult();
//        }
//    }


//}
















