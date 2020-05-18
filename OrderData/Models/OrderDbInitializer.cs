using System.Data.Entity;

namespace OrderData.Models
{
    internal class OrderDbInitializer : IDatabaseInitializer<OrderDbContext>
    {
        public void InitializeDatabase(OrderDbContext context)
        {
            Database.SetInitializer<OrderDbContext>(null);
        }
    }
}