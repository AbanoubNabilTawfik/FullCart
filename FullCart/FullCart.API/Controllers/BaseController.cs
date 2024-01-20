using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string LoggedInUserId => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value!;
        public string? LoggedInUserName => _httpContextAccessor.HttpContext?.User.Identity?.Name;
    }
}
