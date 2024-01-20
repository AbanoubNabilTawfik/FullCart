using AutoMapper;
using FullCart.Core.Interfaces;
using FullCart.Data.DbContexts;
using FullCart.Data.DbModels.FullCartSchema;
using FullCart.Data.DbModels.SecuritySchema;
using FullCart.DTO.Brand;
using FullCart.Repositories.Brand;
using FullCart.Repositories.Item;
using FullCart.Repositories.UOW;
using FullCart.Services.GlobalService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.BrandService
{
    public class BrandService :IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IResponseDTO _response;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBrandRepository _brandRepository;
        private readonly IUploadFileService _uploadFilesService;

        public BrandService(
            IMapper mapper,
            IResponseDTO response,
            IUnitOfWork<AppDbContext> unitOfWork,
            UserManager<ApplicationUser> userManager,
            IBrandRepository brandRepository,
            IUploadFileService uploadFilesService


            )
        {
            _mapper= mapper;
            _response= response;
            _unitOfWork= unitOfWork;
            _userManager= userManager;
            _brandRepository= brandRepository;
            _uploadFilesService= uploadFilesService;

        }

        public async Task<IResponseDTO> CreateBrand(string LoggedInUserId, BrandDto brandDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(LoggedInUserId);
                if(user is null)
                {
                    _response.IsPassed = false;
                    _response.Message = "User Not Exists";
                    return _response;
                }
                else
                {
                    var brand =await  _brandRepository.GetFirstAsync(b => b.Name == brandDto.Name);
                    if(brand is not null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Brand Already Exists";
                        _response.Data = brand.Name;
                        return _response;
                    }
                    else
                    {
                        var brandToBeAdded = _mapper.Map<Brand>(brandDto);
                        var path = $"\\Brands\\Brand{Guid.NewGuid()}";
                        if (brandDto.Image != null)
                        {
                            await _uploadFilesService.UploadFile(path, brandDto.Image, true);
                            brandToBeAdded.Image = $"\\{path}\\{brandDto.Image.FileName}";
                        }

                        _brandRepository.Add(brandToBeAdded);
                        await _unitOfWork.SaveAsync();

                        _response.IsPassed = true;
                        _response.Message = "Brand Added Successfully";
                        _response.Data = brandToBeAdded.Name;
                        return _response;


                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> GetAllBrands(string LoggedInUserId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(LoggedInUserId);
                if (user is null)
                {
                    _response.IsPassed = false;
                    _response.Message = "User Not Exists";
                    return _response;
                }
                else
                {
                    var brands = _brandRepository.GetAll();
                    _response.IsPassed = true;
                    _response.Message = "Getting Brands";
                    _response.Data = brands;
                    _response.TotalCount = brands.Count();
                    _response.TotalPageCount= brands.Count()/10;
                    return _response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> UpdateBrand(string LoggedInUserId, BrandDto brandDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(LoggedInUserId);
                if (user is null)
                {
                    _response.IsPassed = false;
                    _response.Message = "User Not Exists";
                    return _response;
                }
                else
                {
                     
                    var brand = await _brandRepository.GetFirstAsync(b => b.Id == brandDto.Id);
                    if (brand is null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Brand Not Exists";
                        return _response;
                    }
                    else
                    {
                        var isExistsBrand = await _brandRepository.GetFirstAsync(b => b.Name == brandDto.Name);
                       if (isExistsBrand is not null)
                        {
                            _response.IsPassed = false;
                            _response.Message = "Brand Already Exists";
                            _response.Data = brand.Name;
                            return _response;
                        }
                        else
                        {
                            var brandToBeUpdated = _mapper.Map<Brand>(brandDto);
                            var path = $"\\Brands\\Brand{Guid.NewGuid()}";
                            if (brandDto.Image != null)
                            {
                                await _uploadFilesService.UploadFile(path, brandDto.Image, true);
                                brandToBeUpdated.Image = $"\\{path}\\{brandDto.Image.FileName}";
                            }

                            _brandRepository.Update(brandToBeUpdated);
                            await _unitOfWork.SaveAsync();

                            _response.IsPassed = true;
                            _response.Message = "Brand Updated Successfully";
                            _response.Data = brandToBeUpdated.Name;
                            return _response;


                        }
                    }
                   

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
