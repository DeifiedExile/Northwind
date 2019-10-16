using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        

        
        
        public ActionResult Balloon() => View();


        private INorthwindRepository repository;

        public HomeController(INorthwindRepository repo) => repository = repo;

        public ActionResult Index()
        {
            var results = repository.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).Take(3);

            return View(results);

        }

    }
}
