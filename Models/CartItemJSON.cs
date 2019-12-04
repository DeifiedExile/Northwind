using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class CartItemJSON
    {
        public int id { get; set; }
        public string email { get; set; }
        public int qty { get; set; }
    }
}
