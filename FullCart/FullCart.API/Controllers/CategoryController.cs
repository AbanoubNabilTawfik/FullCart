using FullCart.Core.Interfaces;
using FullCart.DTO.Brand;
using FullCart.DTO.Category;
using FullCart.Services.BrandService;
using FullCart.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
         IHttpContextAccessor httpContextAccessor,
          ICategoryService categoryService
         ) : base(httpContextAccessor)
        {
            _categoryService = categoryService;
        }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> AddCategory([FromForm] CategoryDto categoryDto)
        {
            var result = await _categoryService.CreateCategory(LoggedInUserId, categoryDto);
            return result;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> UpdateCategory([FromForm] CategoryDto categoryDto)
        {
            var result = await _categoryService.UpdateCategory(LoggedInUserId, categoryDto);
            return result;
        }

        [HttpGet, DisableRequestSizeLimit]
        public async Task<IResponseDTO> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategories(LoggedInUserId);
            return result;
        }
    }
}
