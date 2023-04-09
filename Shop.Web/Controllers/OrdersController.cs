using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Web.ApiServices.Interfaces;
using Shop.Web.Models.Response;
using Shop.Web.Models.Response.Orders;
using Shop.Web.ViewModels.Orders;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersApiService _ordersApiService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            IOrdersApiService ordersApiService,
            ILogger<OrdersController> logger,
            IConfiguration configuration)
        {
            this._ordersApiService = ordersApiService;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<ActionResult> Index()
        {
            OrdersListResponse ordersListResponse = new OrdersListResponse();

            ordersListResponse = await this._ordersApiService.GetOrders();

            if (!ordersListResponse.Success)
            {
                return View();
            }

            return View(ordersListResponse.Data);
        }


        public async Task<ActionResult> Details(int id)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            ordersResponse = await this._ordersApiService.GetOrder(id);

            if (!ordersResponse.Success)
            {
                return View();
            }

            return View(ordersResponse.Data);
        }   

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOrdersViewModel ordersCreateRequest)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            ordersResponse = await this._ordersApiService.SaveOrder(ordersCreateRequest);

            if (!ordersResponse.Success)
            {
                ViewBag.Message = "Ha ocurrido un error al crear la orden";
                ViewBag.Success = false;
                return View();
            }

            ViewBag.Message = "Orden actualizada correctamente";
            ViewBag.Success = true;

            return View(ordersResponse.Data);
        }

        public async Task<ActionResult> Edit(int id)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            ordersResponse = await this._ordersApiService.GetOrder(id);

            if (!ordersResponse.Success)
            {
                ViewBag.Message = "Ha ocurrido un error al obtener la orden";
                ViewBag.Success = false;
                return View();
            }

            return View(ordersResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateOrdersViewModel updateOrdersViewModel)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            ordersResponse = await this._ordersApiService.EditOrder(updateOrdersViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            ordersResponse = await this._ordersApiService.GetOrder(id);

            return View(ordersResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteOrdersViewModel deleteOrdersViewModel)
        {
            OrdersResponse ordersResponse = new OrdersResponse();

            ordersResponse = await this._ordersApiService.DeleteOrder(deleteOrdersViewModel);

            return RedirectToAction(nameof(Index));
        }
    }
}