using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData.Models
{
    public interface IOrderService
    {
        void InsertOrder(Order o);
        Order GetOrderById(Guid id);
        IEnumerable<Order> GetAllOrders();
        void SaveChanges();
    }
}
