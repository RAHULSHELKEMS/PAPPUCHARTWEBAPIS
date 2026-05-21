using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PAPPUCHARTWEBAPIS.Models
{
    [Index(nameof(MobileNumber), IsUnique = true)]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public bool Active { get; set; }

        public DateTime DateJoined { get; set; }
    }
     public class LoginModel
    {
        public string MobileNumber { get; set; }

        public string Password { get; set; }
    }
}
