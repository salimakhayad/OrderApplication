using OrderData.Models;
using OrderViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderViewer.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }
        public ActionResult Index()
        {
            var ordersFromDb = _orderService.GetAllOrders().ToList();

            
            ordersFromDb.ForEach(o => o.SwitchStatus());
            //  iedere keer dat je dit object wegschrijft zal je deze status switchen. 

            // ordersFromDb = SetsRandomDates(ordersFromDb);
            // to test search between dates funct

            _orderService.SaveChanges();

            OrderIndexModel model = new OrderIndexModel()
            {
                Orders = ordersFromDb
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SearchOrdersBetweenDatesModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.EindDatum == null || model.StartDatum == null)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    // filter
                    var filteredOrders = _orderService.GetAllOrders().Where(o => o.Date >= model.StartDatum && o.Date <= model.EindDatum).ToList();

                    //  iedere keer dat je dit object wegschrijft zal je deze status switchen.
                    filteredOrders.ForEach(o => o.SwitchStatus());

                    _orderService.SaveChanges();

                    OrderIndexModel orderIndexmodel = new OrderIndexModel()
                    {
                        Orders = filteredOrders
                    };

                    return View(orderIndexmodel);
                }
            }
            else
            {
                return View("Index");
            }

        }
        public List<Order> SetsRandomDates(List<Order> orders)
        {
            Random rnd = new Random();

            foreach (var order in orders)
            {
                int randomNumer = rnd.Next(1, 13);
                order.Date = order.Date.AddDays(randomNumer);
            }
            _orderService.SaveChanges();
            return orders;
        }
    }
}