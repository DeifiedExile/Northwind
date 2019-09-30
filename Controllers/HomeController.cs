using System;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Balloon() => View();


        private INorthwindRepository repository;

        public HomeController(INorthwindRepository repo) => repository = repo;



    }
}
