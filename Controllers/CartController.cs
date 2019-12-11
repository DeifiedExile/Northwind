using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CartController : Controller
    {
        private INorthwindRepository repository;
        public CartController(INorthwindRepository repo) => repository = repo;
        public IActionResult Index()
        {
            var customer = repository.Customers.FirstOrDefault(c => c.Email == User.Identity.Name);
            return View(repository.CartItems.Where(c=>c.CustomerId==customer.CustomerId));
        }
    }
}