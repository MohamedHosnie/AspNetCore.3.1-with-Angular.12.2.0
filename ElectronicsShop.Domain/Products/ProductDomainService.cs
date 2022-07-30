using ElectronicsShop.Core.Products;
using ElectronicsShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Products
{
    public class ProductDomainService : ElectronicsShopDomainServiceBase, IProductDomainService
    {
        public readonly IRepository<Product, int> _productRepository;
        public ProductDomainService()
        {

        }

        public Task<int> CreateNewProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
