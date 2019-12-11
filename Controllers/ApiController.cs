using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Northwind.Models;

namespace Northwind.Controllers
{
    //[Route("api/product")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // this controller depends on the NorthwindRepository
        private readonly INorthwindRepository _repository;
        
        public ApiController(INorthwindRepository repo) => _repository = repo;
        

        [HttpGet, Route("api/product")]
        // returns all products
        public IEnumerable<Product> Get() => _repository.Products.OrderBy(p => p.ProductName);

        [HttpGet, Route("api/product/{id}")]
        // returns specific product
        public Product Get(int id) => _repository.Products.FirstOrDefault(p => p.ProductId == id);

        [HttpGet, Route("api/product/discontinued/{discontinued}")]
        // returns all products where discontinued = true/false
        public IEnumerable<Product> GetDiscontinued(bool discontinued) => _repository.Products
            .Where(p => p.Discontinued == discontinued).OrderBy(p => p.ProductName);

        [HttpGet, Route("api/category/{CategoryId}/product")]
        // returns all products in a specific category
        public IEnumerable<Product> GetByCategory(int CategoryId)
        {

            var results = _repository.Products
                .Where(p => p.CategoryId == CategoryId).OrderBy(p => p.ProductName);
            return results;
        }

        [HttpGet, Route("api/category/{CategoryId}/product/sales")]
        public JsonResult GetProductSalesData(int CategoryId)
        {
            var results = _repository.Products.Where(p => p.CategoryId == CategoryId).Include(p => p.OrderDetails)
                .OrderBy(p => p.ProductName);

            var data = new ArrayList();

            foreach (Product p in results)
            {

                int unitsSold = 0;
                decimal totalRev = 0;

                foreach (OrderDetail o in p.OrderDetails)
                {
                    unitsSold += o.Quantity;
                    totalRev += o.Quantity * (p.UnitPrice * (1 - o.Discount));
                }


                var entry = new
                {
                    ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice,
                    UnitsSold = unitsSold, TotalRev = totalRev
                };


                data.Add(entry);
            }






            return new JsonResult(data);

           

        }

        [HttpGet, Route("api/category/{CategoryId}/product/discontinued/{discontinued}")]
        // returns all products in a specific category where discontinued = true/false
        public IEnumerable<Product> GetByCategoryDiscontinued(int CategoryId, bool discontinued) => _repository.Products
            .Where(p => p.CategoryId == CategoryId && p.Discontinued == discontinued).OrderBy(p => p.ProductName);



        [HttpGet, Route("api/category/{ProductId}/sales")]
        public IEnumerable<OrderDetail> GetDetails(int ProductId) =>
            _repository.OrderDetails.Where(od => od.ProductId == ProductId);

        [HttpPost, Route("api/addtocart")]
        public CartItem Post([FromBody] CartItemJSON cartItem) => _repository.AddToCart(cartItem);

        [HttpPost, Route("api/ordercart")]
        public int Post([FromBody] int customerId) => _repository.OrderCart(customerId);


        

    }
}