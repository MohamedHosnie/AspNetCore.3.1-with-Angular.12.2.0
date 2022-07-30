using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicsShop.Application.Orders.Dtos
{
    public class CreateOrderDto
    {
        [Required]
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public float? TotalPrice { get; set; }
        public bool Fulfilled { get; set; }
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
