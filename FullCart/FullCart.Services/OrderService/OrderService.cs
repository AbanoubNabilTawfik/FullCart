using AutoMapper;
using FullCart.Core.Enums;
using FullCart.Core.Interfaces;
using FullCart.Data.DbContexts;
using FullCart.Data.DbModels.FullCartSchema;
using FullCart.Data.DbModels.SecuritySchema;
using FullCart.DTO.Order;
using FullCart.Repositories.Item;
using FullCart.Repositories.Order;
using FullCart.Repositories.OrderItem;
using FullCart.Repositories.UOW;
using FullCart.Services.GlobalService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.OrderService
{
    public class OrderService :IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IResponseDTO _response;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderService(
            IMapper mapper,
            IResponseDTO response,
            IUnitOfWork<AppDbContext> unitOfWork,
            IOrderRepository orderRepository,
            UserManager<ApplicationUser> userManager,
             IItemRepository itemRepository,
             IOrderItemRepository orderItemRepository

            )
        {
            _mapper= mapper;
            _response= response;
            _unitOfWork= unitOfWork;
            _orderRepository= orderRepository;
            _userManager= userManager;
            _itemRepository= itemRepository;
            _orderItemRepository= orderItemRepository;
        }

        public async Task<IResponseDTO> CancelOrder(string LoggedInUserId, long Id)
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
                    var order = await _orderRepository.GetFirstAsync(o=>o.Id==Id);
                    order.Status = (int)OrderStatus.Cancelled;
                    _orderRepository.Update(order);
                    await _unitOfWork.SaveAsync();

                    _response.IsPassed = true;
                    _response.Message = "Order Updated Successfully";
                    _response.Data = order.Status;
                    return _response;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> CreateOrder(string LoggedInUserId, OrderDto orderDto)
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
                    var order = _mapper.Map<Order>(orderDto);
                    order.Status = (int)OrderStatus.New;
                    order.UserID = user.Id;
                    order.CreatedOn = DateTime.Now;
                    _orderRepository.Add(order);
                    await _unitOfWork.SaveAsync();
                    var OrderItems = new List<FullCart.Data.DbModels.FullCartSchema.OrderItem>();

                    foreach (var item in orderDto.Items)
                    {
                        var itemToBeAdded = await _itemRepository.GetAll(x => x.Id == item.ItemId).Include(x => x.Brand).Include(x => x.Category).FirstOrDefaultAsync();
                        if (itemToBeAdded != null)
                        {

                            OrderItems.Add(new Data.DbModels.FullCartSchema.OrderItem()
                            {
                                Order=order,
                                OrderId=order.Id,
                                Item=itemToBeAdded,
                                ItemId=itemToBeAdded.Id,
                                Quantity=item.ItemQuantity,
                            });
                        }

                        var orderItem=await _itemRepository.GetFirstAsync(o=>o.Id==item.ItemId);
                        orderItem.AvaliableQuantity -= item.ItemQuantity;
                        _itemRepository.Update(orderItem);
                        await _unitOfWork.SaveAsync();

                    }

                    _orderItemRepository.AddRange(OrderItems);
                    await _unitOfWork.SaveAsync();
                    
                   

                    _response.IsPassed = true;
                    _response.Message = "Order Created Successfully";
                    _response.Data = order.Status;
                    return _response;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> GetAllOrdersToAdmin(string LoggedInUserId)
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
                    var orders =  _orderRepository.GetAll().Include(x=>x.OrderItems);
                    List<GetOrderDto> ordersDto = new List<GetOrderDto>();
                    foreach ( var order in orders )
                    {
                        List<FullCart.DTO.Order.OrderItem> items = new List<FullCart.DTO.Order.OrderItem>();
                        foreach (var item in order.OrderItems)
                        {
                            items.Add(new FullCart.DTO.Order.OrderItem()
                            {
                                ItemId = item.Id,
                                ItemName = item.Item.Name,
                                ItemPrice = item.Item.Price
                            });
                        }
                        ordersDto.Add(new GetOrderDto()
                        {
                            Id = order.Id,
                            TotalPrice = order.TotalPrice,
                            userName = order.User.FullName,
                            StatusValue = Enum.GetName(typeof(OrderStatus), order.Status),
                            Items=items
                        });
                    }
                    _response.IsPassed = true;
                    _response.Data = ordersDto;
                    _response.Message = "Getting Orders Successfully";
                    return _response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IResponseDTO> GetAllOrdersToCustomer(string LoggedInUserId)
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
                    var orders = _orderRepository.GetAll(x=>x.UserID==LoggedInUserId).Include(x => x.OrderItems);
                    List<GetOrderDto> ordersDto = new List<GetOrderDto>();
                    foreach (var order in orders)
                    {
                        List<FullCart.DTO.Order.OrderItem> items = new List<FullCart.DTO.Order.OrderItem>();
                        foreach (var item in order.OrderItems)
                        {
                            items.Add(new FullCart.DTO.Order.OrderItem()
                            {
                                ItemId = item.Id,
                                ItemName = item.Item.Name,
                                ItemPrice = item.Item.Price
                            });
                        }
                        ordersDto.Add(new GetOrderDto()
                        {
                            Id = order.Id,
                            TotalPrice = order.TotalPrice,
                            userName = order.User.FullName,
                            Items = items,
                            StatusValue = Enum.GetName(typeof(OrderStatus), order.Status)
                        });
                    }
                    _response.IsPassed = true;
                    _response.Data = ordersDto;
                    _response.Message = "Getting Orders Successfully";
                    return _response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
