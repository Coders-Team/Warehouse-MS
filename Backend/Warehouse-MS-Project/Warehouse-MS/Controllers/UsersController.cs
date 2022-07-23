using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Warehouse_MS.Models.Interfaces;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager) // inject IUserService 
        {
            _userService = userService;
            _userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUser data)
        {
            try
            {
                var user = await _userService.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return user;
                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginData loginData)
        {
            try
            {
                var user = await _userService.Authenticate(loginData.Username, loginData.Password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return BadRequest($"User {loginData.Username} with the given password cannot be found");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPassword model)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var res = await _userService.ResetPassword(model.Email, model.Password);
                if (res != null)
                {
                    return Ok("password reset done!");
                }
            }
            return null;
        }
    }
}
