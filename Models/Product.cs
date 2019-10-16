using System;
using System.ComponentModel;

namespace Northwind.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        [DisplayName("In Stock")]
        public short UnitsInStock { get; set; }
        [DisplayName("On Order")]
        public short UnitsOnOrder { get; set; }
        [DisplayName("Reorder Level")]
        public short ReorderLevel { get; set; }
        [DisplayName("Discontinued")]
        public bool Discontinued { get; set; }
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public Category Category { get; set; }
    }
}
