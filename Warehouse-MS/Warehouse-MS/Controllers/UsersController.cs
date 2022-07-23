using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Users");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();

            return Redirect("/");
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterUser register)
        {
            if (register.Username != null && register.Email != null && register.Password != null)
            {
                await _userService.Register(register, this.ModelState);
            }

            if (ModelState.IsValid)
            {
                return Redirect("/home/index");
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Index(LoginData login)
        {
            if (login.Username != null && login.Password != null)
            {
                var user = await _userService.Authenticate(login.Username, login.Password);
                if (user != null)
                {
                    return Redirect("/home/index");
                }
                ModelState.AddModelError("NotMatch", "Username and Passowrd not match");
                return View();
            }
            return View();
        }
    }
}
