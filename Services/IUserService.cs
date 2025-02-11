using QuardIntel.DTOs;
using QuardIntel.Models;

namespace QuardIntel.Services
{
    public interface IUserService
    {
        Task<ApiResponse<User>> Register(RegisterUserRequest registerUser);
        Task<ApiResponse<string>> Login(string username, string password);
    }
}
