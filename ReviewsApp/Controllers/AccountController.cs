using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReviewsApp.Models;
using ReviewsApp.Models.Settings;
using ReviewsApp.ViewModels;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User
            {
                UserName = model.Login,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToLoginPage();
            }
            AddErrorsFromResult(result);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Login);
            if (user == null)
            {
                AddLoginError();
                return View(model);
            }
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(
                user, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToHomePage();
            }
            AddLoginError();
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult FacebookLogin()
        {
            string redirectUrl = Url.Action("FacebookResponse");
            var properties = _signInManager
                .ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return new ChallengeResult("Facebook", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> FacebookResponse()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToLoginPage();
            }

            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider, info.ProviderKey, false);
            if (result.Succeeded)
            {
                return RedirectToHomePage();
            }

            var user = CreateUser(info);
            var identityResult = await _userManager.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                return RedirectToHomePage();
            }
            var loginResult = await _userManager
                .AddLoginAsync(user, info);
            if (!loginResult.Succeeded)
            {
                return RedirectToHomePage();
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToHomePage();

        }

        [HttpPost]
        public async Task<IActionResult> FacebookDelete()
        {
            string signedRequest = Request.Form["signed_request"];

            if (string.IsNullOrEmpty(signedRequest))
            {
                return BadRequest();
            }
            var split = signedRequest.Split('.');
            if (string.IsNullOrWhiteSpace(split[0]) == false)
            {
                int mod4 = split[0].Length % 4;
                if (mod4 > 0) split[0] += new string('=', 4 - mod4);

                split[0] = split[0]
                    .Replace('-', '+')
                    .Replace('_', '/');
            }
            if (string.IsNullOrWhiteSpace(split[1]) == false)
            {
                int mod4 = split[1].Length % 4;
                if (mod4 > 0) split[1] += new string('=', 4 - mod4);

                split[1] = split[1]
                    .Replace('-', '+')
                    .Replace('_', '/');
            }
            var dataRaw = Encoding.UTF8.GetString(Convert.FromBase64String(split[1]));
            var json = JObject.Parse(dataRaw);

            var appSecretBytes = Encoding.UTF8.GetBytes(Secrets.FacebookWebAppSecret);
            var hmac = new System.Security.Cryptography.HMACSHA256(appSecretBytes);
            var expectedHash = Convert.ToBase64String(hmac.ComputeHash(
                    Encoding.UTF8.GetBytes(signedRequest.Split('.')[1])))
                .Replace('-', '+')
                .Replace('_', '/');

            if (expectedHash != split[0])
            {
                return BadRequest();
            }

            var userId = json.GetValue("user_id").ToString();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            _context.Remove(user);
            await _context.SaveChangesAsync();

            return Json(new
            {
                url = Url.Action("FacebookInfo", "Account", new { id = userId }, HttpContext.Request.Scheme),
                confirmation_code = userId
            });

        }

        public async Task<IActionResult> FacebookInfo(string id)
        {
            await _signInManager.SignOutAsync();
            return View(id);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        private IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLoginPage()
        {
            return RedirectToAction("Login");
        }

        private static User CreateUser(ExternalLoginInfo info)
        {
            return new User
            {
                Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                UserName = info.Principal.FindFirst(ClaimTypes.Name).Value
            };
        }

        private void AddLoginError()
        {
            ModelState.AddModelError(nameof(LoginViewModel.Login),
                "Invalid Login or password");
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
