using FullCart.Core.Interfaces;
using FullCart.Services.BrandService;
using FullCart.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(
        IHttpContextAccessor httpContextAccessor,
         IOrderService orderService
        ) : base(httpContextAccessor)
        {
            _orderService   = orderService;
        }

        [HttpGet, DisableRequestSizeLimit]
        public async Task<IResponseDTO> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersToAdmin(LoggedInUserId);
            return result;
        }
    }
}
