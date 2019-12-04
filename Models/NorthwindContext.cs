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

    }
}
