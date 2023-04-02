using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Web.ApiServices.Interfaces;
using Shop.Web.Models.Response.Products;
using Shop.Web.ViewModels.Products;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Web.ApiServices.Services
{
    public class ProductApiService : IProductApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductApiService> logger;
        private readonly string baseUrl;
        public ProductApiService(IHttpClientFactory httpClientFactory,
                                 IConfiguration configuration,
                                 ILogger<ProductApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }

        public async Task<ProductListResponse> GetProducts()
        {
            ProductListResponse productListResponse = new ProductListResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient()) 
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Product"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            productListResponse = JsonConvert.DeserializeObject<ProductListResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                productListResponse.Message = "Error al obtener los productos";
                productListResponse.Success = false;
                this.logger.LogError(productListResponse.Message, ex.ToString());
            }

            return productListResponse;
        }

        public async Task<ProductResponse> GetProduct(int id)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Product/" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                productResponse.Message = "Error al obtener el producto";
                productResponse.Success = false;
                this.logger.LogError(productResponse.Message, ex.ToString());
            }

            return productResponse;
        }
        public async Task<ProductResponse> SaveProduct(CreateProductViewModel createProductViewModel)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                createProductViewModel.RequestUser = 3;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(createProductViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Product/CreateProduct", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                productResponse.Message = "Error al guardar el producto";
                productResponse.Success = false;
                this.logger.LogError(productResponse.Message, ex.ToString());
            }

            return productResponse;
        }

        public async Task<ProductResponse> EditProduct(UpdateProductViewModel updateProductViewModel)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                updateProductViewModel.RequestUser = 3;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(updateProductViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Product/UpdateProduct", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                productResponse.Message = "Error al actualizar el producto";
                productResponse.Success = false;
                this.logger.LogError(productResponse.Message, ex.ToString());
            }

            return productResponse;
        }
        public async Task<ProductResponse> DeleteProduct(DeleteProductViewModel deleteProductViewModel)
        {
            ProductResponse productResponse = new ProductResponse();

            try
            {
                deleteProductViewModel.RequestUser = 3;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(deleteProductViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Product/DeleteProduct", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            productResponse = JsonConvert.DeserializeObject<ProductResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                productResponse.Message = "Error al eliminar el producto";
                productResponse.Success = false;
                this.logger.LogError(productResponse.Message, ex.ToString());
            }

            return productResponse;
        }
    }
}
