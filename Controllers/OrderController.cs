using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class OrderController : Controller
    {
        private INorthwindRepository repository;
        public OrderController(INorthwindRepository repo) => repository = repo;
        public IActionResult Index()
        {
            var customer = repository.Customers.FirstOrDefault(c => c.Email == User.Identity.Name);
            return View(repository.Orders.Where(c => c.CustomerId == customer.CustomerId));
        }
    }
}