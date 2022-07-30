using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicsShop.Application.Products.Dtos
{
    public class ProductDto
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(Shared.Consts.Product.Name_MaximumLength, MinimumLength = Shared.Consts.Product.Name_MinimumLength)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(Shared.Consts.Product.Description_MaximumLength, MinimumLength = Shared.Consts.Product.Description_MinimumLength)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [DataType(DataType.Currency)]
        public float PriceOfTwo { get; set; }
        [Required]
        public short CategoryId { get; set; }
    }
}
