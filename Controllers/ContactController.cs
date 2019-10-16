using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;


namespace Northwind.Controllers
{
    public class ContactController : Controller
    {
        private INorthwindRepository repository;

        public ContactController(INorthwindRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            //always check model state any time you post data to a controller
            if (ModelState.IsValid)
            {
                repository.AddContact(contact);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}