using Microsoft.EntityFrameworkCore;

namespace Northwind.Models
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>().HasKey(table => new {
                table.OrderId,
                table.ProductId
            });
            builder.Entity<EmployeeTerritory>().HasKey(table => new {
                table.EmployeeId,
                table.TerritoryId
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderDetail> OrderDetails {get; set;}
        public DbSet<Shipper> Shippers {get; set;}
        public DbSet<Supplier> Suppliers {get; set;}
        public DbSet<Employee> Employees {get; set;}
        public DbSet<EmployeeTerritory> EmployeeTerritories {get; set;}
        public DbSet<Territory> Territories {get; set;}
        public DbSet<Region> Regions {get; set;}

}
}
