using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System;
using System.Linq;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private INorthwindRepository repository;
        public ProductController(INorthwindRepository repo) => repository = repo;

        public IActionResult Category() => View(repository.Categories.OrderBy(c => c.CategoryName));


        //public IActionResult Index(int id)
        //{

        //    var results = repository.Products;

        //    if (id != 0)
        //    {
        //        results = repository.Products.Where(p => p.CategoryId == id && !p.Discontinued);
        //    }

        //    //if(id != 0)
        //    //{
        //    //   results = repository.Products.Where(p => p.ProductId == id);

        //    //}


        //    return View(results);

        //}
        public IActionResult Index(int id)
        {
            ViewBag.id = id;
            return View(repository.Categories.OrderBy(c => c.CategoryName));
        }




        public IActionResult Discounts() => View(repository.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));


    }
}
