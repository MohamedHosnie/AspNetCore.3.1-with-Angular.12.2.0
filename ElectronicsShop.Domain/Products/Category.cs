using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicsShop.Domain.Products
{
    [Table("Category")]
    public class Category : Entity<short>
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(Shared.Consts.Category.Name_MaximumLength, MinimumLength = Shared.Consts.Category.Name_MinimumLength)]
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
