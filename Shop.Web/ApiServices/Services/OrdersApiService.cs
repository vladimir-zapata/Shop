using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Web.ApiServices.Interfaces;
using Shop.Web.Models.Response.Orders;
using Shop.Web.ViewModels.Orders;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Web.ApiServices.Services
{
    public class OrdersApiService : IOrdersApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<OrdersApiService> logger;
        private readonly string baseUrl;
        public OrdersApiService(IHttpClientFactory httpClientFactory,
                                 IConfiguration configuration,
                                 ILogger<OrdersApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }

        public async Task<OrdersListResponse> GetOrders()
        {
            OrdersListResponse ordersListResponse = new OrdersListResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Order"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ordersListResponse = JsonConvert.DeserializeObject<OrdersListResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ordersListResponse.Message = "Error al obtener las ordenes";
                ordersListResponse.Success = false;
                this.logger.LogError(ordersListResponse.Message, ex.ToString());
            }

            return ordersListResponse;
        }

        public async Task<OrdersResponse> GetOrder(int id)
        {
            OrdersResponse ordersResponse = new OrdersResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Order/" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ordersResponse = JsonConvert.DeserializeObject<OrdersResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ordersResponse.Message = "Error al obtener la orden";
                ordersResponse.Success = false;
                this.logger.LogError(ordersResponse.Message, ex.ToString());
            }

            return ordersResponse;
        }
        public async Task<OrdersResponse> SaveOrder(CreateOrdersViewModel createOrdersViewModel)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            try
            {
                createOrdersViewModel.RequestUser = 3;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(createOrdersViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Order/CreateOrder", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ordersResponse = JsonConvert.DeserializeObject<OrdersResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ordersResponse.Message = "Error al guardar la orden";
                ordersResponse.Success = false;
                this.logger.LogError(ordersResponse.Message, ex.ToString());
            }

            return ordersResponse;
        }

        public async Task<OrdersResponse> EditOrder(UpdateOrdersViewModel updateOrdersViewModel)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            try
            {
                updateOrdersViewModel.RequestUser = 3;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(updateOrdersViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Order/UpdateOrder", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ordersResponse = JsonConvert.DeserializeObject<OrdersResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ordersResponse.Message = "Error al actualizar la orden";
                ordersResponse.Success = false;
                this.logger.LogError(ordersResponse.Message, ex.ToString());
            }

            return ordersResponse;
        }
        public async Task<OrdersResponse> DeleteOrder(DeleteOrdersViewModel deleteOrdersViewModel)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            try
            {
                deleteOrdersViewModel.RequestUser = 3;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(deleteOrdersViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Order/DeleteOrder", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ordersResponse = JsonConvert.DeserializeObject<OrdersResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ordersResponse.Message = "Error al eliminar la orden";
                ordersResponse.Success = false;
                this.logger.LogError(ordersResponse.Message, ex.ToString());
            }

            return ordersResponse;
        }
    }
}