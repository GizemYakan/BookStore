using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice()
        {
            return Price * Quantity;
        }
    }
}
