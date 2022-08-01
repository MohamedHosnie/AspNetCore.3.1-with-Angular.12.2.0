using ElectronicsShop.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Orders
{
    public interface IOrderDomainService
    {
        Task<float> CalculateTotalPrice(int productId, int quantity);
        Task<int> CreateNewOrder(Order orderToAdd);
    }
}
