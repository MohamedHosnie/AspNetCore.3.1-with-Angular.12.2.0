using ElectronicsShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Products
{
    public interface IProductDomainService
    {
        Task<int> CreateNewProduct(Product product);
        float CalculateDiscount(float price, float discount);
        float CalculateDiscountOnTwo(float price, float discountOnTwo);
    }
}
