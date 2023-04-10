using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using Shop.Web.Models.Request;
using Shop.Web.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Web.Controllers
{
    public class CustomerController : Controller
    {
       
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<CustomerController> logger;
        private readonly IConfiguration configuration;

        public CustomerController(ILogger<CustomerController> logger,
                                 IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            CustomerListResponse customerListResponse = new CustomerListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var response = await httpClient.GetAsync("http://localhost:31881/api/Customer");
                   

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        customerListResponse = JsonConvert.DeserializeObject<CustomerListResponse>(apiResponse);
                    }
                    else
                    {
                        // completar //       
                    }


                }

                return View(customerListResponse.data);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los clientes", ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> Details(int id)
        {

            CustomerResponse customerResponse = new CustomerResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                var response = await httpClient.GetAsync($"http://localhost:31881/api/Customer/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customerResponse = JsonConvert.DeserializeObject<CustomerResponse>(apiResponse);
                }
                else
                {
                    // realizar x logica //       
                }


            }

            return View(customerResponse.data);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerCreateRequest customerCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                customerCreate.creationDate = DateTime.Now;
                customerCreate.creationUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerCreate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:31881/api/Customer/SaveCustomer", content);

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


            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            CustomerResponse customerResponse = new CustomerResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                var response = await httpClient.GetAsync($"http://localhost:31881/api/Customer/UpdateCustomer" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customerResponse = JsonConvert.DeserializeObject<CustomerResponse>(apiResponse);
                }
                else
                {
                    // completar //       
                }


            }
            return View(customerResponse.data);

        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerUpdateRequest customerUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                customerUpdate.modifyDate = DateTime.Now;
                customerUpdate.modifyUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:31881/api/Customer/UpdateCustomer", content);
                

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


            }
            catch
            {
                return View();
            }
        }
    }
}
