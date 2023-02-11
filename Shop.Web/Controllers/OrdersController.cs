using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System;
using System.Collections.Generic;

namespace Shop.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: OrdersController
        public ActionResult Index()
        {
            List<OrdersModel> products = new List<OrdersModel>()
            {
                new OrdersModel()
                {
                    OrderID = 0001,
                    CustID = 01,
                    EmpID = 01,
                    OrderDate = new DateTime(2023, 11, 02),
                    ShippedDate = new DateTime(2023, 11, 09),
                    ShipperID = 001,
                    Freight = 199,
                    ShipName = "AJ001",
                    ShipAddress = "1798 ave 1st Apt 203",
                    ShipCity = "Miami",
                    ShipRegion = "Palm Beach County",
                    ShipCountry = "United States",
                    ShipPostalCode = 32129
                }
            };
            return View();
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
