using ElectronicsShop.Core.Products;
using ElectronicsShop.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicsShop.Core.Orders
{
    [Table("Order")]
    public class Order : Entity<int>
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float TotalPrice { get; set; }
        public bool Fulfilled { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public User Customer { get; set; }
        public Product Product { get; set; }
    }
}
