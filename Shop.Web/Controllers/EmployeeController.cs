using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System;
using System.Collections.Generic;

namespace Shop.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()

        {

            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                   empid= 1,
                   lastname="Guerrero",
                   firstname="Marcos",
                   title="Ingeniero",
                   birthdate= new DateTime(2008,12,25),
                   hiredate= new DateTime(2008,11,22),
                   address="Lion Avenue 1988",
                   city="France",
                   phone="33-905-332",
                   mgrid=9,
                   titleofcourtesy="Graduated",
                   
                   
                   
        }
            };
            
                
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
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

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
