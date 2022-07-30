using ElectronicsShop.Core.Products;
using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ElectronicsShop.Application.Products.Dtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateNewProduct(CreateProductDto product)
        {
            var productToAdd = new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price
            };

            if(product.Discount != null && product.Discount > 0)
            {
                productToAdd.Price = _productDomainService.CalculateDiscount(productToAdd.Price, product.Discount.Value);
            }

            if (product.DiscountOnTwo != null && product.DiscountOnTwo > 0)
            {
                productToAdd.PriceOfTwo = _productDomainService.CalculateDiscountOnTwo(productToAdd.Price, product.DiscountOnTwo.Value);
            }

            return await _productDomainService.CreateNewProduct(productToAdd);
        }

        public async Task<IList<ProductDto>> GetAllProducts()
        {
            return await _productRepository.GetAllIQueryable().Include("Category").Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Category = p.Category.Name,
                Description = p.Description,
                Price = p.Price,
                PriceOfTwo = p.PriceOfTwo
            }).ToListAsync();
        }
    }
}
