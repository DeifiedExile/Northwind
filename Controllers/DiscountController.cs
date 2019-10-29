using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System;
using System.Linq;

namespace Northwind.Controllers
{
    public class DiscountController : Controller
    {
        private INorthwindRepository repository;

        public DiscountController(INorthwindRepository repo) => repository = repo;

        public IActionResult Index()
        {
            var results = repository.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now);
            return View(results);
        }
    }
}