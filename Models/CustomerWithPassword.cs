using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class CustomerWithPassword
    {
        public Customer Customer { get; set; }
        [UIHint("password"), Required]
        public string Password { get; set; }
    }
}
