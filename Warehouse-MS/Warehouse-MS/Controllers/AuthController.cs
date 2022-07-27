using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Warehouse_MS.Auth.Interfaces;
using Warehouse_MS.Auth.Models;
using Warehouse_MS.Auth.Models.Dto;

namespace Warehouse_MS.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/home/index");
            }
            return View();
        }

        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/auth/index");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = HttpContext.User.Identity.Name;
                await _userService.Logout();
                ViewData["user"] = userName;
                return View();
            }
            return Redirect("/auth/index");
        }

        public IActionResult Forgotpassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forgotpassword(string email)
        {
            if (email == null)
            {
                ViewData["emptyEmail"] = "Email cannot be empty";
                return View();
            }
            var userMail = await _userManager.FindByEmailAsync(email);
            if (userMail == null)
            {
                ViewData["email"] = "Email not found";
                return View();
            }
            var password = await _userService.PasswordGenerator(email);
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dynamicTemplateData = new
            {
                u = username,
                password = password
            };

            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("22029874@student.ltuc.com", "Warehouse MS"),
                Subject = "Reset password"
            };
            msg.AddTo(new EmailAddress(email, username));
            msg.SetTemplateId("d-41e2bb1ed91d4805b5a7fe7e6d63f2e1");
            msg.SetTemplateData(dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);

            return Redirect("/auth/index");
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto register)
        {
            if (register.UserName != null && register.Email != null && register.Password != null)
            {
                await _userService.Register(register, this.ModelState);
            }

            if (ModelState.IsValid)
            {
                return Redirect("/auth/index");
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Index(LoginDto login)
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

        [HttpPost]
        public async Task<ActionResult> Logout(string Username, string Password)
        {
            if (Username != null && Password != null)
            {
                var user = await _userService.Authenticate(Username, Password);
                if (user != null)
                {
                    return Redirect("/home/index");
                }
                ViewData["user"] = Username;
                ViewData["match"] = "Username and Passowrd not match";
                return View();
            }
            ViewData["data"] = "Please enter your password";
            ViewData["user"] = Username;
            return View();
        }
    }
}
