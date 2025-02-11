using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuardIntel.DTOs;
using QuardIntel.Models;
using QuardIntel.Services;

namespace QuardIntel.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetAllProducts()

        {
            var response = await _productService.GetAllProductsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Product>>> GetProductById(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            if (!response.StatusCode.Equals(200))
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ActionResult<ApiResponse<Product>>> CreateProduct([FromBody] Product product)
        {
            var response = await _productService.CreateProductAsync(product);
            if (!response.StatusCode.Equals(200))
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Product>>> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            var response = await _productService.UpdateProductAsync(product);
            if (!response.StatusCode.Equals(200))
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (!response.StatusCode.Equals(200))
            {
                return NotFound(response);
            }
            return NoContent();
        }
    }
}
