using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class Customer
    {
        //[Key]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
