using AutoMapper;
using FullCart.Core.Interfaces;
using FullCart.Data.DbContexts;
using FullCart.Data.DbModels.FullCartSchema;
using FullCart.Data.DbModels.SecuritySchema;
using FullCart.DTO.Brand;
using FullCart.DTO.Category;
using FullCart.Repositories.Brand;
using FullCart.Repositories.Category;
using FullCart.Repositories.UOW;
using FullCart.Services.GlobalService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.CategoryService
{
    public class CategoryService :ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IResponseDTO _response;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUploadFileService _uploadFilesService;

        public CategoryService(
            IMapper mapper,
            IResponseDTO response,
            IUnitOfWork<AppDbContext> unitOfWork,
            UserManager<ApplicationUser> userManager,
            ICategoryRepository categoryRepository,
            IUploadFileService uploadFilesService
            )
        {
            _mapper = mapper;
            _response = response;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
            _uploadFilesService = uploadFilesService;

        }

        public async Task<IResponseDTO> CreateCategory(string LoggedInUserId, CategoryDto categoryDto)
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
                    var category = await _categoryRepository.GetFirstAsync(b => b.Name == categoryDto.Name);
                    if (category is not null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Category Already Exists";
                        _response.Data = category.Name;
                        return _response;
                    }
                    else
                    {
                        var categoryToBeAdded = _mapper.Map<Category>(categoryDto);
                        var path = $"\\Categories\\Category{Guid.NewGuid()}";
                        if (categoryDto.Image != null)
                        {
                            await _uploadFilesService.UploadFile(path, categoryDto.Image, true);
                            categoryToBeAdded.Image = $"\\{path}\\{categoryDto.Image.FileName}";
                        }

                        _categoryRepository.Add(categoryToBeAdded);
                        await _unitOfWork.SaveAsync();

                        _response.IsPassed = true;
                        _response.Message = "Category Added Successfully";
                        _response.Data = categoryToBeAdded.Name;
                        return _response;


                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IResponseDTO> UpdateCategory(string LoggedInUserId, CategoryDto categoryDto)
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

                    var Category = await _categoryRepository.GetFirstAsync(b => b.Id == categoryDto.Id);
                    if (Category is null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Category Not Exists";
                        return _response;
                    }
                    else
                    {
                        var isExistsCategory = await _categoryRepository.GetFirstAsync(b => b.Name == categoryDto.Name);
                        if (isExistsCategory is not null)
                        {
                            _response.IsPassed = false;
                            _response.Message = "Category Already Exists";
                            _response.Data = Category.Name;
                            return _response;
                        }
                        else
                        {
                            var categoryToBeUpdated = _mapper.Map<Category>(categoryDto);
                            var path = $"\\Categories\\Category{Guid.NewGuid()}";
                            if (categoryDto.Image != null)
                            {
                                await _uploadFilesService.UploadFile(path, categoryDto.Image, true);
                                categoryToBeUpdated.Image = $"\\{path}\\{categoryDto.Image.FileName}";
                            }

                            _categoryRepository.Update(categoryToBeUpdated);
                            await _unitOfWork.SaveAsync();

                            _response.IsPassed = true;
                            _response.Message = "Category Updated Successfully";
                            _response.Data = categoryToBeUpdated.Name;
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
