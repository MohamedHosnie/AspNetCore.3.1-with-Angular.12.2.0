using ElectronicsShop.Domain.Products;
using ElectronicsShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Products
{
    public class ProductDomainService : ElectronicsShopDomainServiceBase, IProductDomainService
    {
        public readonly IRepository<Product, int> _productRepository;
        public ProductDomainService(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateNewProduct(Product product)
        {
            if (product.Price < 0 || product.PriceOfTwo < 0) throw new Exception("Price cannot be negative");
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
            return product.Id;
        }

        float IProductDomainService.CalculateDiscount(float price, float discount)
        {
            return price - (price * (discount/(float)100.0));
        }

        float IProductDomainService.CalculateDiscountOnTwo(float price, float discountOnTwo)
        {
            return (price * (float)2.0) - ((price * (float)2.0) * (discountOnTwo / (float)100.0));
        }

    }
}
