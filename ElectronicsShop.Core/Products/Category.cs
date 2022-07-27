using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicsShop.Core.Products
{
    [Table("Category")]
    public class Category : Entity<short>
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 6)]
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
