using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Application.Products.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float? PriceOfTwo { get; set; }
        public short CategoryId { get; set; }
        public string Category { get; set; }
    }
}
