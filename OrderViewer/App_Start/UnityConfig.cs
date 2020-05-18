using OrderData.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OrderViewer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IOrderService, OrderService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}