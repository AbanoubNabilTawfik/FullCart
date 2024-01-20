using FullCart.Core.Interfaces;
using FullCart.DTO.Brand;
using FullCart.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IResponseDTO> CreateCategory(string LoggedInUserId, CategoryDto categoryDto);
        Task<IResponseDTO> UpdateCategory(string LoggedInUserId, CategoryDto categoryDto);
    }
}
