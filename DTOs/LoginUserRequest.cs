using System.ComponentModel.DataAnnotations;

namespace QuardIntel.DTOs
{
    public class LoginUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
