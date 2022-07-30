using ElectronicsShop.Api;
using ElectronicsShop.Application.Products;
using ElectronicsShop.Application.Products.Dtos;
using ElectronicsShop.Core.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        public readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("Categories")]
        public async Task<IList<CategoryDto>> Categories()
        {
            return (await _productAppService.getAllCategories()).Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        [HttpPost]
        public async Task<int> Create(CreateProductDto product)
        {
            return await _productAppService.CreateNewProduct(product);
        }

        [HttpGet]
        public async Task<IList<ProductDto>> GetAll()
        {
            return await _productAppService.GetAllProducts();
        }
    }
}
