using ElectronicsShop.Core.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicsShop.Core.Products
{
    [Table("Product")]
    public class Product : Entity<int>
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
        public Category Category { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
