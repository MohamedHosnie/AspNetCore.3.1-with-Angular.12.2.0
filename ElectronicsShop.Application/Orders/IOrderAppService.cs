using ElectronicsShop.Application.Orders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Orders
{
    public interface IOrderAppService
    {
        Task<int> CreateNewOrder(CreateOrderDto order);
        Task<IList<OrderDto>> GetAllOrders();
    }
}
