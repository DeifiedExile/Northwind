using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}