using Microsoft.AspNetCore.Mvc;
using QuardIntel.DTOs;
using QuardIntel.Models;

namespace QuardIntel.Services
{
    public interface IOrderService
    {
        Task<ApiResponse<OrderDetailsResponse>> GetOrderAsync(int userId);
        //Task<ApiResponse<Order>> CreateOrderAsync(CreateOrderRequest createOrderModel);
        //Task<ApiResponse<Order>> UpdateOrderAsync(UpdateOrderRequest updateOrderModel);
        //Task<ApiResponse<bool>> DeleteOrderAsync(int id);
    }
}
