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
            List<OrdersModel> orders = new List<OrdersModel>()
            {
                new OrdersModel()
                {
                    OrderID = 1001,
                    CustID = 101,
                    EmpID = 430,
                    OrderDate = new DateTime(2023, 11, 02),
                    ShippedDate = new DateTime(2023, 11, 09),
                    ShipperID = 100,
                    Freight = 199.99,
                    ShipName = "AJ001",
                    ShipAddress = "1798 ave 1st Apt 203",
                    ShipCity = "Miami",
                    ShipRegion = "Miami-Dade County",
                    ShipCountry = "United States",
                    ShipPostalCode = 32129


                },
                new OrdersModel()
                {
                    OrderID = 1002,
                    CustID = 102,
                    EmpID = 431,
                    OrderDate = new DateTime(2023, 11, 02),
                    ShippedDate = new DateTime(2023, 11, 10),
                    ShipperID = 101,
                    Freight = 99.99,
                    ShipName = "AJ002",
                    ShipAddress = "7135 SW 117th Ave",
                    ShipCity = "Miami",
                    ShipRegion = "Miami-Dade County",
                    ShipCountry = "United States",
                    ShipPostalCode = 33183
                },
                new OrdersModel()
                {
                    OrderID = 1003,
                    CustID = 103,
                    EmpID = 431,
                    OrderDate = new DateTime(2023, 11, 02),
                    ShippedDate = new DateTime(2023, 11, 08),
                    ShipperID = 102,
                    Freight = 353.32,
                    ShipName = "AJ003",
                    ShipAddress = "2488 N University Dr",
                    ShipCity = "Pembroke Pines",
                    ShipRegion = "Broward County",
                    ShipCountry = "United States",
                    ShipPostalCode = 33024
                }
             };
            return View(orders);
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
