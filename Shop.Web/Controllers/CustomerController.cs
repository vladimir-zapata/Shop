using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System.Collections.Generic;

namespace Shop.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()

        {
            List<CustomerModel> customer = new List<CustomerModel>()
            {
                new CustomerModel()
                {
                    CustId = 1,
                    CompanyName = "Bravo",
                    ContactName = "Carolina Herrara",
                    ContactTittle = "Admin",
                    Address = "Calle A, Piantiani Edif Andrea 1 Apto 2B",
                    Email = "bravo@gmail.com",
                    City = "Santo Domingo",
                    Region = "Norte",
                    PostalCode = "241",
                    Country = "Republica Dominicana",
                    Phone = "809-967-4169",
                    Fax = "no aplica"

                }
            };


            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
