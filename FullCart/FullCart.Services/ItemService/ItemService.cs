using AutoMapper;
using FullCart.Core.Interfaces;
using FullCart.Data.DbContexts;
using FullCart.Data.DbModels.FullCartSchema;
using FullCart.Data.DbModels.SecuritySchema;
using FullCart.DTO.Category;
using FullCart.DTO.Item;
using FullCart.Repositories.Item;
using FullCart.Repositories.UOW;
using FullCart.Repositories.User;
using FullCart.Services.GlobalService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.ItemService
{
    public class ItemService:IItemService
    {
        private readonly IMapper _mapper;
        private readonly IResponseDTO _response;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IItemRepository _itemRepository;
        private readonly IUploadFileService _uploadFilesService;

        public ItemService(
            IMapper mapper,
            IResponseDTO response,
            IUnitOfWork<AppDbContext> unitOfWork,
            UserManager<ApplicationUser> userManager,
            IItemRepository itemRepository,
            IUploadFileService uploadFilesService

            )
        {
            _mapper = mapper;
            _response = response;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _itemRepository = itemRepository;
            _uploadFilesService = uploadFilesService;
        }

        public async Task<IResponseDTO> AddItem(string LoggedInUserId, ItemDto item)
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
                    var Item = await _itemRepository.GetFirstAsync(b => b.Name == item.Name && !b.IsDeleted);
                    if (Item is not null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Item Already Exists";
                        _response.Data = Item.Name;
                        return _response;
                    }
                    else
                    {
                        var itemToBeAdded = _mapper.Map<Item>(item);
                        var path = $"\\Items\\Item{Guid.NewGuid()}";
                        if (item.Image != null)
                        {
                            await _uploadFilesService.UploadFile(path, item.Image, true);
                            itemToBeAdded.Image = $"\\{path}\\{item.Image.FileName}";
                        }

                        _itemRepository.Add(itemToBeAdded);
                        await _unitOfWork.SaveAsync();

                        _response.IsPassed = true;
                        _response.Message = "Item Added Successfully";
                        _response.Data = itemToBeAdded.Name;
                        return _response;


                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IResponseDTO> DeleteItem(string LoggedInUserId, long Id)
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
                    var item=await _itemRepository.GetFirstAsync(i=>i.Id == Id&& !i.IsDeleted);
                    if (item is null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Item Not Exists";
                        return _response;
                    }
                    else
                    {
                        _itemRepository.Remove(item,false);
                        _unitOfWork.SaveAsync();
                        _response.IsPassed = true;
                        _response.Message = "Item Deleted Successfully";
                        return _response;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> GetAllItems(string LoggedInUserId)
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
                    var items = _itemRepository.GetAll(i=>!i.IsDeleted);
                    _response.IsPassed = true;
                    _response.Message = "Getting Items Successfully";
                    _response.Data = items;
                    _response.TotalCount = items.Count();
                    return _response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> UpdateItem(string LoggedInUserId, ItemDto item)
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

                    var Item = await _itemRepository.GetFirstAsync(b => b.Id == item.Id && !b.IsDeleted);
                    if (Item is null)
                    {
                        _response.IsPassed = false;
                        _response.Message = "Item Not Exists";
                        return _response;
                    }
                    else
                    {
                        var isExistsCategory = await _itemRepository.GetFirstAsync(b => b.Name == item.Name&&!b.IsDeleted);
                        if (isExistsCategory is not null)
                        {
                            _response.IsPassed = false;
                            _response.Message = "Item Already Exists";
                            _response.Data = isExistsCategory.Name;
                            return _response;
                        }
                        else
                        {
                            var itemToBeUpdated = _mapper.Map<Item>(item);
                            var path = $"\\Items\\Item{Guid.NewGuid()}";
                            if (item.Image != null)
                            {
                                await _uploadFilesService.UploadFile(path, item.Image, true);
                                itemToBeUpdated.Image = $"\\{path}\\{item.Image.FileName}";
                            }

                            _itemRepository.Update(itemToBeUpdated);
                            await _unitOfWork.SaveAsync();

                            _response.IsPassed = true;
                            _response.Message = "Item Updated Successfully";
                            _response.Data = itemToBeUpdated.Name;
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
