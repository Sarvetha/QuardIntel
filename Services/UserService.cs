using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuardIntel.DTOs;
using QuardIntel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuardIntel.Services
{
    public class UserService : IUserService
    {
        private readonly QuardDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserService(QuardDbContext context, IConfiguration configuration, ILogger<UserService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ApiResponse<User>> Register(RegisterUserRequest registerUser)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            var user = new User
            {
                Username = registerUser.Username,
                PasswordHash = passwordHash,
                Email = registerUser.Email,
                Phone = registerUser.Phone,
                Address = registerUser.Address
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ApiResponse<User>
            {
                StatusCode = 200,
                Message = "User registered successfully",
                Data = user
            };
        }

        public async Task<ApiResponse<string>> Login(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null; // Invalid credentials
            }

            // Generate JWT token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //new Claim(ClaimTypes.Name, user.Username)
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor); 

            return new ApiResponse<string>
            {
                StatusCode = 200,
                Message = "User registered successfully",
                Data = null
            };

        }
    }
}
