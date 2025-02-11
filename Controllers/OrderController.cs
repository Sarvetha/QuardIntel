using Microsoft.AspNetCore.Mvc;
using QuardIntel.DTOs;
using QuardIntel.Models;
using QuardIntel.Services;

namespace QuardIntel.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrder")]
        public async Task<ActionResult<ApiResponse<OrderDetailsResponse>>> GetOrder(int userId)
        {
            var response = await _orderService.GetOrderAsync(userId);
            if (!response.StatusCode.Equals(200))
            {
                return NotFound(response); 
            }
            return Ok(response); 
        }

       //[HttpPost("CreateOrder")]
       // public async Task<ActionResult<ApiResponse<Order>>> CreateOrder([FromBody] CreateOrderRequest createOrderModel)
       // {
       //     var response = await _orderService.CreateOrderAsync(createOrderModel);
       //     if (!response.StatusCode.Equals(200))
       //     {
       //         return BadRequest(response);
       //     }
       //     return CreatedAtAction(nameof(GetOrder), new { userId = response.Data.UserId }, response);
       // }

        // PUT: api/order/UpdateOrder/{id}
        //[HttpPut("UpdateOrder/{id}")]
        //public async Task<ActionResult<ApiResponse<Order>>> UpdateOrder(int id, [FromBody] UpdateOrderRequest updateOrderModel)
        //{
        //    if (id != updateOrderModel.Id)
        //    {
        //        return BadRequest("Order ID mismatch."); // 400 Bad Request
        //    }

        //    var response = await _orderService.UpdateOrderAsync(updateOrderModel);
        //    if (!response.StatusCode.Equals(200))
        //    {
        //        return NotFound(response);
        //    }
        //    return Ok(response);
        //}

        // DELETE: api/order/DeleteOrder/{id}
        //[HttpDelete("DeleteOrder/{id}")]
        //public async Task<ActionResult<ApiResponse<bool>>> DeleteOrder(int id)
        //{
        //    var response = await _orderService.DeleteOrderAsync(id);
        //    if (!response.StatusCode.Equals(200))
        //    {
        //        return NotFound(response); // 404 Not Found
        //    }
        //    return NoContent(); // 204 No Content
        //}

    }
}
