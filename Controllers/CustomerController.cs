using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {

        private INorthwindRepository repository;

        public CustomerController(INorthwindRepository repo)
        {
            repository = repo;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if(ModelState.IsValid)
            {
                repository.AddCustomer(customer);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}