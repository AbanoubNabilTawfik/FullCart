using FullCart.Core.Interfaces;
using FullCart.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.OrderService
{
    public interface IOrderService
    {
        Task<IResponseDTO> GetAllOrdersToAdmin(string LoggedInUserId);
        Task<IResponseDTO> GetAllOrdersToCustomer(string LoggedInUserId);
        Task<IResponseDTO> CreateOrder(string LoggedInUserId, OrderDto orderDto);
        Task<IResponseDTO> CancelOrder(string LoggedInUserId, long Id);

    }
}
