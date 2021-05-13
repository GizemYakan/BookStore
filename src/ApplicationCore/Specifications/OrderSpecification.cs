using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class OrderSpecification : Specification<Order>
    {
        public OrderSpecification()
        {
            Query.Include(x => x.OrderItems).Include(x => x.ShipToAddress);
        }
        public OrderSpecification(string buyerId)
        {
            Query.Include(x => x.OrderItems).Include(x => x.ShipToAddress).Where(x => x.BuyerId == buyerId);
        }
    }
}
