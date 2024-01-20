using FullCart.Core.Interfaces;
using FullCart.DTO.Brand;
using FullCart.DTO.Item;
using FullCart.Services.BrandService;
using FullCart.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ItemController : BaseController
    {
        private readonly IItemService _itemService;

        public ItemController(
         IHttpContextAccessor httpContextAccessor,
          IItemService itemService
         ) : base(httpContextAccessor)
        {
            _itemService = itemService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> AddItem([FromForm] ItemDto itemDto)
        {
            var result = await _itemService.AddItem(LoggedInUserId, itemDto);

            return result;
        }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IResponseDTO> UpdateItem([FromForm] ItemDto itemDto)
        {
            var result = await _itemService.UpdateItem(LoggedInUserId, itemDto);

            return result;
        }

        [HttpGet, DisableRequestSizeLimit]
        public async Task<IResponseDTO> GetAllItems()
        {
            var result = await _itemService.GetAllItems(LoggedInUserId);
            return result;
        }

        [HttpDelete, DisableRequestSizeLimit]
        public async Task<IResponseDTO> DeleteItem(long Id)
        {
            var result = await _itemService.DeleteItem(LoggedInUserId,Id);
            return result;
        }
    }
}
