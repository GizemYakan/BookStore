using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class OrderItemSpecification : Specification<OrderItem>
    {
        public OrderItemSpecification(int orderId)
        {
            Query.Where(x => x.OrderId == orderId);
        }
    }
}
