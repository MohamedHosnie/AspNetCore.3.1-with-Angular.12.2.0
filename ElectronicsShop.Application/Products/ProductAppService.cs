using ElectronicsShop.Core.Products;
using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Products
{
    public class ProductAppService : ElectronicsShopAppServiceBase, IProductAppService
    {
        public readonly IRepository<Product, int> _productRepository;
        public readonly IRepository<Category, short> _categoryRepository;
        public readonly IProductDomainService _productDomainService;
        public ProductAppService(
            IRepository<Product, int> productRepository, 
            IRepository<Category, short> categoryRepository,
            IProductDomainService productDomainService
            )
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productDomainService = productDomainService;
        }

        public async Task<IList<Category>> getAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<int> CreateNewProduct(Product product)
        {
            return await _productDomainService.CreateNewProduct(product);
        }
    }
}
