using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public String CartItemName { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
