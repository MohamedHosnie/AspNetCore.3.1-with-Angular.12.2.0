using ElectronicsShop.Domain.Orders;
using ElectronicsShop.Domain.Products;
using ElectronicsShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Orders
{
    public class OrderDomainService : ElectronicsShopDomainServiceBase, IOrderDomainService
    {
        public readonly IRepository<Product, int> _productRepository;
        public readonly IRepository<Order, int> _orderRepository;
        public OrderDomainService(IRepository<Product, int> productRepository, IRepository<Order, int> orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public Task<float> CalculateTotalPrice(int productId, int quantity)
        {
            if (quantity < 1) throw new Exception("Quantity cannot be less than 1");

            var product = _productRepository.Get(productId);

            var quantity1 = product.PriceOfTwo.HasValue ? (quantity % 2) : quantity;
            var quantity2 = quantity / 2;

            return Task.FromResult((quantity1 * product.Price) + (quantity2 * (product.PriceOfTwo.HasValue ? product.PriceOfTwo.Value : 0)));
        }

        public async Task<int> CreateNewOrder(Order orderToAdd)
        {
            await _orderRepository.AddAsync(orderToAdd);
            await _orderRepository.SaveAsync();
            return orderToAdd.Id;
        }
    }
}
