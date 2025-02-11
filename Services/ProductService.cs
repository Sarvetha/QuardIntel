using Microsoft.EntityFrameworkCore;
using QuardIntel.Models;
using QuardIntel.DTOs;

namespace QuardIntel.Services
{
    public class ProductService : IProductService
    {
        private readonly QuardDbContext _context;

        public ProductService(QuardDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var response = new ApiResponse<IEnumerable<Product>>();
            try
            {
                response.Data = await _context.Products.ToListAsync();
                response.StatusCode = 200;
                response.Message = "Products retrieved successfully.";
            }
            catch (DbUpdateException ex)
            {
                response.StatusCode = 500;
                response.Message = "Database error occurred while retrieving products: " + ex.Message;
                response.Data = null;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "An unexpected error occurred: " + ex.Message;
                response.Data = null;
            }

            return response;
        }

        public async Task<ApiResponse<Product>> GetProductByIdAsync(int id)
        {
            var response = new ApiResponse<Product>();
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                response.StatusCode = 404;
                response.Message = "Product not found.";
                response.Data = null;
            }
            else
            {
                response.StatusCode = 200;
                response.Message = "Product retrieved successfully.";
                response.Data = product;
            }

            return response;
        }

        public async Task<ApiResponse<Product>> CreateProductAsync(Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
            {
                return new ApiResponse<Product>
                {
                    StatusCode = 404,
                    Message = "Invalid product data."
                };
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ApiResponse<Product>
            {
                Data = product,
                StatusCode = 200,
                Message = "Product created successfully."
            };
        }

        public async Task<ApiResponse<Product>> UpdateProductAsync(Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
            {
                return new ApiResponse<Product>
                {
                    StatusCode = 400,
                    Message = "Invalid product data."
                };
            }

            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                return new ApiResponse<Product>
                {
                    StatusCode = 404,
                    Message = "Product not found."
                };
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();

            return new ApiResponse<Product>
            {
                Data = product,
                StatusCode = 200,
                Message = "Product updated successfully."
            };
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiResponse<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found."
                };
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new ApiResponse<bool>
            {
                Data = true,
                StatusCode = 200,
                Message = "Product deleted successfully."
            };
        }

    }
}
