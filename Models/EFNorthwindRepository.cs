using System.Linq;

namespace Northwind.Models
{
    public class EFNorthwindRepository : INorthwindRepository
    {
        // the repository class depends on the NorthwindContext service
        // which was registered at application startup
        private NorthwindContext context;

        

        public EFNorthwindRepository(NorthwindContext ctx)
        {
            context = ctx;
        }
        // create IQueryable for Categories & Products
        public IQueryable<Category> Categories => context.Categories;
        public IQueryable<Product> Products => context.Products;
        public IQueryable<Discount> Discounts => context.Discounts;
        public IQueryable<Contact> Contacts => context.Contacts;

        public void AddContact(Contact contact)
        {
            //creates insert or update statement automatically based on what you're doing
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        
    }
}
