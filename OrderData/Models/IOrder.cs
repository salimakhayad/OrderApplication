using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData.Models
{
    interface IOrder
    {
        void SwitchStatus();
        bool Status
        {
            get;
            set;
        }
        string FileName
        {
            get;
            set;
        }

    }
}
