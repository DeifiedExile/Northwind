using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class OrderDetail
    {
        [Key, Column(Order=0)]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
