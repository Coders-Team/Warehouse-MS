using Warehouse_MS.Auth.Interfaces;
using Warehouse_MS.Auth.Models;
using Warehouse_MS.Auth.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace Warehouse_MS.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr)
        {
            _userManager = userManager;
            _signInManager = SignInMngr;
        }
        public async Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate)//,bool flag
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                IList<string> Roles = new List<string>();
                Roles.Add("Admin");
                await _userManager.AddToRolesAsync(user, Roles);

                UserDto userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
                    "";

                modelstate.AddModelError(errorKey, error.Description);
            }

            return null;
        }


        public async Task<UserDto> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new UserDto
                {
                    Username = user.UserName
                };
            }

            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDto
            {
                Username = user.UserName
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> PasswordGenerator(string email)
        {
            char[] alphaCapital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            char[] alphaSmall = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            string[] special = { "@", "$", "_" };

            Random rnd = new Random();
            int alphaC = rnd.Next(0, 26);
            int alphaS = rnd.Next(0, 26);
            int num = rnd.Next(0, 10);
            int specCahr = rnd.Next(0, 3);

            string password = $"{alphaCapital[alphaC]}{alphaSmall[alphaS]}{alphaSmall[alphaS]}{alphaSmall[alphaS]}{special[specCahr]}{numbers[num]}{numbers[num]}{numbers[num]}{numbers[num]}";

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var hashPassword = _userManager.PasswordHasher.HashPassword(user, password);
            user.PasswordHash = hashPassword;
            await _userManager.UpdateAsync(user);

            return password;
        }
    }
}
