using FullCart.Core.Interfaces;
using FullCart.DTO.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.BrandService
{
    public interface IBrandService
    {
        Task<IResponseDTO> CreateBrand(string LoggedInUserId,BrandDto brandDto);
        Task<IResponseDTO> UpdateBrand(string LoggedInUserId, BrandDto brandDto);
        Task<IResponseDTO> GetAllBrands(string LoggedInUserId);

    }
}
