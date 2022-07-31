using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Application.Products.Dtos
{
    public class CreateProductDto
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
        public float? Discount { get; set; }
        public float? DiscountOnTwo { get; set; }
        [Required]
        public short CategoryId { get; set; }
    }
}
