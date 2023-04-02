using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Web.ApiServices.Interfaces;
using Shop.Web.Models.Response;
using Shop.Web.Models.Response.Products;
using Shop.Web.ViewModels.Products;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiService _productApiService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductController> _logger;

        public ProductController(
            IProductApiService productApiService,
            ILogger<ProductController> logger, 
            IConfiguration configuration)
        {
            this._productApiService= productApiService;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<ActionResult> Index()
        {
            ProductListResponse productListResponse = new ProductListResponse();

            productListResponse = await this._productApiService.GetProducts();

            if (!productListResponse.Success) 
            {
                return View();
            } 

            return View(productListResponse.Data);
        }


        public async Task<ActionResult> Details(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            productResponse = await this._productApiService.GetProduct(id);

            if (!productResponse.Success)
            {
                return View();
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
            ProductResponse productResponse = new ProductResponse();

            productResponse = await this._productApiService.SaveProduct(productCreateRequest);

            if (!productResponse.Success)
            {
                ViewBag.Message = "Ha ocurrido un error al crear el producto";
                ViewBag.Success = false;
                return View();
            }

            ViewBag.Message = "Producto actualizado correctamente";
            ViewBag.Success = true;

            return View(productResponse.Data);
        }

        public async Task<ActionResult> Edit(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            productResponse = await this._productApiService.GetProduct(id);

            if (!productResponse.Success)
            {
                ViewBag.Message = "Ha ocurrido un error al obtener el producto";
                ViewBag.Success = false;
                return View();
            }

            return View(productResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateProductViewModel updateProductViewModel)
        {
            ProductResponse productResponse = new ProductResponse();

            productResponse = await this._productApiService.EditProduct(updateProductViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            productResponse = await this._productApiService.GetProduct(id);

            return View(productResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteProductViewModel productDeleteRequest)
        {
            ProductResponse productResponse = new ProductResponse();

            productResponse = await this._productApiService.DeleteProduct(productDeleteRequest);

            return RedirectToAction(nameof(Index));
        }
    }
}
