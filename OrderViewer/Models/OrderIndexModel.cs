using OrderData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderViewer.Models
{
    public class OrderIndexModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Eind { get; set; }
    }
}