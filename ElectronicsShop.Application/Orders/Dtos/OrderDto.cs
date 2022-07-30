using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Application.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public bool Fulfilled { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
    }
}
