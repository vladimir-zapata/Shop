using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System.Collections.Generic;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel()
                {
                    ProductId= 1,
                    ProductName= "Laptop Lenovo",
                    CategoryId = 1,
                    SupplierId= 1,
                    UnitPrice = 499.99,
                    Discontinued = false
                },
                new ProductModel()
                {
                    ProductId= 2,
                    ProductName= "Mouse Logitech",
                    CategoryId = 2,
                    SupplierId= 2,
                    UnitPrice = 49.99,
                    Discontinued = false
                },
                new ProductModel()
                {
                    ProductId= 3,
                    ProductName= "Asus Monitor",
                    CategoryId = 3,
                    SupplierId= 4,
                    UnitPrice = 399.99,
                    Discontinued = true
                }
            };


            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
