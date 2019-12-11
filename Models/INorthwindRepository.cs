using System.Linq;

namespace Northwind.Models
{
    public interface INorthwindRepository
    {
        IQueryable<Category> Categories { get; }
        IQueryable<Product> Products { get; }
        IQueryable<Discount> Discounts { get; }
        IQueryable<Contact> Contacts { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<Order> Orders { get; }
        IQueryable<OrderDetail> OrderDetails { get; }
        IQueryable<Shipper> Shippers { get; }
        IQueryable<Supplier> Suppliers { get; }
        IQueryable<Employee> Employees { get; }
        IQueryable<EmployeeTerritory> EmployeeTerritories { get; }
        IQueryable<Territory> Territories { get; }
        IQueryable<Region> Regions { get; }
        IQueryable<CartItem> CartItems { get; }

        void AddContact(Contact contact);
        void AddCustomer(Customer customer);
        void EditCustomer(Customer customer);
        CartItem AddToCart(CartItemJSON cartItemJSON);
        int OrderCart(int customerId);
    }
}
