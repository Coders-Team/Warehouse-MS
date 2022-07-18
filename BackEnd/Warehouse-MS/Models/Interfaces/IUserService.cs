using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using Warehouse_MS.Models.DTO;

namespace Warehouse_MS.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> ResetPassword(string email, string password);
    }
}
