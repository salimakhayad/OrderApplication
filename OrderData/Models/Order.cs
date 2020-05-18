using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData.Models
{
    public class Order : IOrder
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string Xml { get; set; }
        public void SwitchStatus() => this.Status = (this.Status) ? (this.Status) = false : (this.Status) = true;

    }
}
