using FullCart.Core.Interfaces;
using FullCart.DTO.Security;
using FullCart.Services.SecurityService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;

        public SecurityController(
         IHttpContextAccessor httpContextAccessor,
          ISecurityService securityService
         ) : base(httpContextAccessor)
        {
            _securityService = securityService;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize]
        public async Task<IResponseDTO> Register(RegisterDto registerDto)
        {
            IFormFile file = null;//Request.Form.Files.Count() > 0 ? Request.Form.Files[0] : null;
            var result = await _securityService.Register(LoggedInUserId, registerDto, file);

            return result;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> Login(LoginDto loginDto)
        {
            var result = await _securityService.Login(loginDto);

            return result;
        }

    }

}
