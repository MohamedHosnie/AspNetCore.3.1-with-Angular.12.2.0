using ElectronicsShop.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Orders
{
    public interface IOrderDomainService
    {
        public Task<float> CalculateTotalPrice(int productId, int quantity);
        public Task<int> CreateNewOrder(Order orderToAdd);
    }
}
