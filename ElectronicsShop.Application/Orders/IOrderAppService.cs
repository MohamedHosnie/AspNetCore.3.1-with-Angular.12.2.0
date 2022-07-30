using ElectronicsShop.Application.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Orders
{
    public interface IOrderAppService
    {
        public Task<int> CreateNewOrder(CreateOrderDto order);
        public Task<IList<OrderDto>> GetAllOrders();
    }
}
