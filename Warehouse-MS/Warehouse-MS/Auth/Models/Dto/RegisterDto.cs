using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse_MS.Auth.Models.Dto
{
    public class RegisterDto
    {
        [Required]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum length is 3 character")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}