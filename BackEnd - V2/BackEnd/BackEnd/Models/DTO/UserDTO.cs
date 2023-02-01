using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class UserDTO
    {
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }
        [MaxLength(50), Required]
        public string UserName { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }
        [MaxLength(50), Required]
        public string Password { get; set; }
    }
}
