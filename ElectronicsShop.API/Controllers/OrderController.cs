using ElectronicsShop.Application.Orders;
using ElectronicsShop.Application.Orders.Dtos;
using ElectronicsShop.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost, Authorize]
        public async Task<int> Create(CreateOrderDto order)
        {
            return await _orderAppService.CreateNewOrder(order);
        }

        [HttpGet, Authorize(Roles = RoleName.Admin)]
        public async Task<IList<OrderDto>> GetAll()
        {
            return await _orderAppService.GetAllOrders();
        }
    }
}
