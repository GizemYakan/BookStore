using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address Address { get; set; }
        public int OrderItemsCount { get; set; }
    }
}
