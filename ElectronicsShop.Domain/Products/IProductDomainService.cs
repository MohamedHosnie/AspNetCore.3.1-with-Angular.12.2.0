using ElectronicsShop.Core.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Products
{
    public interface IProductDomainService
    {
        public Task<int> CreateNewProduct(Product product);
    }
}
