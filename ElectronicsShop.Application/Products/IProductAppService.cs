using ElectronicsShop.Application.Products.Dtos;
using ElectronicsShop.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Products
{
    public interface IProductAppService
    {
        public Task<IList<Category>> getAllCategories();
        public Task<int> CreateNewProduct(CreateProductDto product);
        Task<IList<ProductDto>> GetAllProducts();
    }
}
