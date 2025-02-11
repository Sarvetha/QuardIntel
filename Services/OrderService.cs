using Microsoft.EntityFrameworkCore;
using QuardIntel.DTOs;
using QuardIntel.Models;
using AutoMapper;

namespace QuardIntel.Services
{
    public class OrderService : IOrderService
    {
        private readonly QuardDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(QuardDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<OrderDetailsResponse>> GetOrderAsync(int userId)
        {
            var orderDetails = await _context.Order
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId);
                

            if (orderDetails == null)
            {
                return new ApiResponse<OrderDetailsResponse>
                {
                    StatusCode = 404,
                    Message = "Order not found."
                };
            }

            var order = _mapper.Map<OrderDetailsResponse>(orderDetails);

            return new ApiResponse<OrderDetailsResponse>
            {
                Data = order,
                StatusCode = 200,
                Message = "Order retrieved successfully."
            };
        }

        //public async Task<ApiResponse<Order>> CreateOrderAsync(CreateOrder createOrderModel)
        //{
        //    var order = new Order
        //    {
        //        UserId = createOrderModel.UserId,
        //        OrderDate = DateTime.UtcNow,
        //        OrderItems = createOrderModel.Items.Select(i => new OrderItem
        //        {
        //            ProductId = i.ProductId,
        //            Quantity = i.Quantity
        //        }).ToList()
        //    };

        //    await _context.Orders.AddAsync(order);
        //    await _context.SaveChangesAsync();

        //    return new ApiResponse<Order>
        //    {
        //        Data = order,
        //        Success = true,
        //        Message = "Order created successfully."
        //    };
        //}
    }
}
