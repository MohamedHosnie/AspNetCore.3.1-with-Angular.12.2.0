using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Orders.Dtos;
using ElectronicsShop.Core.Orders;
using ElectronicsShop.Domain.Orders;
using ElectronicsShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Orders
{
    public class OrderAppService : ElectronicsShopAppServiceBase, IOrderAppService
    {
        public readonly IOrderDomainService _orderDomainService;
        public readonly IAuthAppService _authAppService;
        public readonly IRepository<Order, int> _orderRepository;
        public OrderAppService(IOrderDomainService orderDomainService, IAuthAppService authAppService, IRepository<Order, int> orderRepository)
        {
            _orderDomainService = orderDomainService;
            _authAppService = authAppService;
            _orderRepository = orderRepository;
        }

        public async Task<int> CreateNewOrder(CreateOrderDto order)
        {
            var orderToAdd = new Order
            {
                ProductId = order.ProductId,
                Quantity = order.Quantity,
            };

            var loggedInUser = await _authAppService.GetLoggedInUser();

            orderToAdd.UserId = loggedInUser.Id;
            orderToAdd.Fulfilled = false;

            orderToAdd.TotalPrice = await _orderDomainService.CalculateTotalPrice(order.ProductId, order.Quantity);

            return await _orderDomainService.CreateNewOrder(orderToAdd);
        }

        public async Task<IList<OrderDto>> GetAllOrders()
        {
            return await _orderRepository.GetAllIQueryable().Include("Customer").Include("Product").Select(o => new OrderDto
            {
                Customer = o.Customer.FullName,
                Product = o.Product.Name,
                Id = o.Id,
                Quantity = o.Quantity,
                Fulfilled = o.Fulfilled,
                ProductId = o.ProductId,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId
            }).ToListAsync();
        }
    }
}
