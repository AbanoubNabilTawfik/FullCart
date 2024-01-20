using FullCart.Core.Interfaces;
using FullCart.DTO.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.ItemService
{
    public interface IItemService
    {
        Task<IResponseDTO> AddItem(string LoggedInUserId, ItemDto item);
        Task<IResponseDTO> UpdateItem(string LoggedInUserId, ItemDto item);
        Task<IResponseDTO> GetAllItems(string LoggedInUserId);
        Task<IResponseDTO> DeleteItem(string LoggedInUserId, long Id);
    }
}
