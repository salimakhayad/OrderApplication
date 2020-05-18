using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() : base("name=OrdersDb")
        {
            Database.SetInitializer<OrderDbContext>(new OrderDbInitializer());
            //Database.SetInitializer<OrderDbContext>(new System.Data.Entity.DropCreateDatabaseIfModelChanges<OrderDbContext>());

        }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
