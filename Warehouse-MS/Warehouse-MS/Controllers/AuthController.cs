using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Warehouse_MS.Auth.Interfaces;
using Warehouse_MS.Auth.Models.Dto;

namespace Warehouse_MS.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
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
            //var password = _userService.PasswordGenerator(email);

            //if (password == null)
            //{
            //    ViewData["email"] = "Email not found";
            //    return View();
            //}

            //SendGridClient client = new SendGridClient("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");
            //SendGridMessage msg = new SendGridMessage();

            //msg.SetFrom("22029874@student.ltuc.com", "Admin");
            //msg.AddTo(email);
            //msg.SetSubject("Reset your Password");
            //msg.AddContent(MimeType.Html, $"This is your new password {email}");

            //await client.SendEmailAsync(msg);

            //return Redirect("/auth/index");

            var client = new SendGridClient("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");
            var from = new EmailAddress("22029874@student.ltuc.com", "Brent");
            var to = new EmailAddress(email,"Brent");
            var subject = "Sending with Twilio SendGrid is fun!";
            var plainTextContent ="and easy to do anywhere, even with C#!";
            var htmlContent = "‹strong>and easy to do anywhere, even with C#! strong>";
            var msg = MailHelper.CreateSingleEmail(
            from,
            to,
            subject,
            plainTextContent,
            htmlContent
);
            await client.SendEmailAsync(msg);
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
