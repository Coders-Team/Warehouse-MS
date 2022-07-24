using Warehouse_MS.Auth.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Warehouse_MS.Auth.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> GetUser(ClaimsPrincipal principal);
        Task Logout();
    }
}