using AutoMapper;
using FullCart.Core.Interfaces;
using FullCart.Data.DbContexts;
using FullCart.Data.DbModels.SecuritySchema;
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

    }
}
