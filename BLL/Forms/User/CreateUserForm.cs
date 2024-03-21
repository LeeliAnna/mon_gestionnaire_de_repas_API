using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Forms.User
{
    public class CreateUserForm
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string Pseudo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
