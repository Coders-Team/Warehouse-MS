using System.ComponentModel.DataAnnotations;

namespace Warehouse_MS.Models.DTO
{
    public class ResetPassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
