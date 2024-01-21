using FullCart.Core.Interfaces;
using FullCart.DTO.Brand;
using FullCart.DTO.Order;
using FullCart.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IOrderService _orderService;
        public CustomerController(
        IHttpContextAccessor httpContextAccessor,
         IOrderService orderService
        ) : base(httpContextAccessor)
        {
            _orderService = orderService;
        }

        [HttpGet, DisableRequestSizeLimit]
        [Authorize]
        public async Task<IResponseDTO> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersToCustomer(LoggedInUserId);
            return result;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize]
        public async Task<IResponseDTO> CreateOrder([FromBody] OrderDto orderDto)
        {
            var result = await _orderService.CreateOrder(LoggedInUserId, orderDto);
            return result;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize]
        public async Task<IResponseDTO> CancelOrder(long Id)
        {
            var result = await _orderService.CancelOrder(LoggedInUserId, Id);
            return result;
        }
    }
}
