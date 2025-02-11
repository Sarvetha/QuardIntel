using System.ComponentModel.DataAnnotations;

namespace QuardIntel.DTOs
{
    public class RegisterUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
