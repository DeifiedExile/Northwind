using System.Linq;

namespace Northwind.Models
{
    public class EFNorthwindRepository : INorthwindRepository
    {
        // the repository class depends on the NorthwindContext service
        // which was registered at application startup
        private NorthwindContext _context;



        public EFNorthwindRepository(NorthwindContext ctx)
        {
            _context = ctx;
        }
        // create IQueryable for Categories & Products
        public IQueryable<Category> Categories => _context.Categories;
        public IQueryable<Product> Products => _context.Products;
        public IQueryable<Discount> Discounts => _context.Discounts;
        public IQueryable<Contact> Contacts => _context.Contacts;
        public IQueryable<Customer> Customers => _context.Customers;
        public IQueryable<Order> Orders => _context.Orders;
        public IQueryable<OrderDetail> OrderDetails => _context.OrderDetails;
        public IQueryable<Shipper> Shippers => _context.Shippers;
        public IQueryable<Supplier> Suppliers => _context.Suppliers;
        public IQueryable<Employee> Employees => _context.Employees;
        public IQueryable<EmployeeTerritory> EmployeeTerritories => _context.EmployeeTerritories;
        public IQueryable<Territory> Territories => _context.Territories;
        public IQueryable<Region> Regions => _context.Regions;


        public void AddContact(Contact contact)
        {
            //creates insert or update statement automatically based on what you're doing
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            var customerToUpdate = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            customerToUpdate.Address = customer.Address;
            customerToUpdate.City = customer.City;
            customerToUpdate.Region = customer.Region;
            customerToUpdate.PostalCode = customer.PostalCode;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Fax = customer.Fax;
            customerToUpdate.Email = customer.Email;
            _context.SaveChanges();
        }
    }
}
