using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData.Models
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this._context.Orders;
        }

        public Order GetOrderById(Guid id)
        {
            return this._context.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public void InsertOrder(Order o)
        {
            this._context.Orders.Add(o);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
