using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class CreateModel
    {
        //prop tab to generate this
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
