using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class OrderViewModelService : IOrderViewModelService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsyncRepository<OrderItem> _orderItemRepository;

        public OrderViewModelService(IAsyncRepository<Order> orderRepository, IHttpContextAccessor httpContextAccessor, IAsyncRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<List<OrderViewModel>> ListOrderAsync()
        {
            string buyerId = GetBuyerId();
            var spec = new OrderSpecification(buyerId);
            var orders = await _orderRepository.ListAsync(spec);
            var orderViews = new List<OrderViewModel>();
            foreach (var item in orders)
            {
                orderViews.Add(new OrderViewModel()
                {
                    OrderId = item.Id,
                    Address = item.ShipToAddress,
                    OrderDate = item.OrderDate,
                    OrderItemsCount = item.OrderItems.Select(x => x.Quantity).Sum()
                });
            }
            return orderViews;

        }
        public string GetBuyerId()
        {
            var context = _httpContextAccessor.HttpContext;
            var user = context.User;
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<List<OrderItemViewModel>> ListOrderItemsAsync(int orderId)
        {
            var spec = new OrderItemSpecification(orderId);
            var orderItems = await _orderItemRepository.ListAsync(spec);
            var orderItemsView = new List<OrderItemViewModel>();
            foreach (var item in orderItems)
            {
                orderItemsView.Add(new OrderItemViewModel()
                {
                    PictureUri = item.PictureUri,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }
            return orderItemsView;

        }

        public async Task<List<OrderViewModel>> ListOrderAllAsync()
        {
            var spec = new OrderSpecification();
            var orders = await _orderRepository.ListAsync(spec);
            var orderViews = new List<OrderViewModel>();
            foreach (var item in orders)
            {
                orderViews.Add(new OrderViewModel()
                {
                    OrderId = item.Id,
                    Address = item.ShipToAddress,
                    OrderDate = item.OrderDate,
                    OrderItemsCount = item.OrderItems.Select(x => x.Quantity).Sum()
                });
            }
            return orderViews;
        }
    }
}
