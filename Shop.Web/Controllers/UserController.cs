using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: UserControler
        public ActionResult Index()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Email = "eurysdeoleo@gmail.com",
                    Name= "eurys",
                    UserId=283
                    
                     
                  
                }
            };
            return View(users);
        }

        // GET: UserControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserControler/Create
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

        // GET: UserControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserControler/Edit/5
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

        // GET: UserControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserControler/Delete/5
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
