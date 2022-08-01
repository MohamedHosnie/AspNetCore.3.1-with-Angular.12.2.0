using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Orders.Dtos;
using ElectronicsShop.Domain.Orders;
using ElectronicsShop.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Orders
{
    public class OrderAppService : ElectronicsShopAppServiceBase, IOrderAppService
    {
        private readonly IOrderDomainService _orderDomainService;
        private readonly IAuthAppService _authAppService;
        private readonly IRepository<Order, int> _orderRepository;
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
            var allOrders = await _orderRepository.GetAllAsync(includeProperties: "Customer,Product");
            return allOrders.Select(o => new OrderDto
            {
                Customer = o.Customer.FullName,
                Product = o.Product.Name,
                Id = o.Id,
                Quantity = o.Quantity,
                Fulfilled = o.Fulfilled,
                ProductId = o.ProductId,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId
            }).ToList();
        }
    }
}
