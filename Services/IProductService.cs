using QuardIntel.DTOs;
using QuardIntel.Models;

namespace QuardIntel.Services
{
    public interface IProductService
    {
        Task<ApiResponse<IEnumerable<Product>>> GetAllProductsAsync();
        Task<ApiResponse<Product>> GetProductByIdAsync(int id);
        Task<ApiResponse<Product>> CreateProductAsync(Product product);
        Task<ApiResponse<Product>> UpdateProductAsync(Product product);
        Task<ApiResponse<bool>> DeleteProductAsync(int id);
    }
}
