using System.Data.Entity;
using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data
{
    public class PizzaDataContext : DbContext
    {
        static PizzaDataContext()
        {
            Database.SetInitializer(new SimpleInitializer());
        }

        public PizzaDataContext() : base("PizzaDataContext")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
       
        public DbSet<PizzaItem> Pizzas { get; set; }

        public DbSet<PizzaTemplate> Templates { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        
    }
}
