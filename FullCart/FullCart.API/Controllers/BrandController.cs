using FullCart.Core.Interfaces;
using FullCart.DTO.Brand;
using FullCart.DTO.Security;
using FullCart.Services.BrandService;
using FullCart.Services.SecurityService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;

        public BrandController(
         IHttpContextAccessor httpContextAccessor,
          IBrandService brandService
         ) : base(httpContextAccessor)
        {
            _brandService = brandService;
        }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> AddBrand([FromForm] BrandDto brandDto)
        {
            var result = await _brandService.CreateBrand(LoggedInUserId, brandDto);

            return result;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> UpdateBrand([FromForm] BrandDto brandDto)
        {
            var result = await _brandService.UpdateBrand(LoggedInUserId, brandDto);

            return result;
        }
    }
}
