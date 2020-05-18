using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderViewer.Models
{
    public class SearchOrdersBetweenDatesModel
    {
        public DateTime? StartDatum { get; set; }
        public DateTime? EindDatum { get; set; }
    }
}