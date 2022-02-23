using AutoMapper;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models;
using ReviewsApp.Utils;
using ReviewsApp.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, AppDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
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
            var user = _mapper.Map<User>(model);
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
            return GetSocialLoginResult(FacebookDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            return GetSocialLoginResult(GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SocialResponse()
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
            if (await UserWithSameEmailRegistered(user))
            {
                TempData["message"] = $"User with email '{user.Email}' already registered";
                return RedirectToLoginPage();
            }
            var identityResult = await _userManager.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                return RedirectToLoginPage();
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
            var helper = new FacebookHelper(signedRequest);
            if (helper.GetExpectedHash() != helper.GetEncodedSignature())
            {
                return BadRequest();
            }
            var json = helper.GetJsonObject();
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

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private ChallengeResult GetSocialLoginResult(string scheme)
        {
            string redirectUrl = Url.Action("SocialResponse");
            var properties = _signInManager
                .ConfigureExternalAuthenticationProperties(scheme, redirectUrl);
            return new ChallengeResult(scheme, properties);
        }

        private async Task<bool> UserWithSameEmailRegistered(User user)
        {
            return await _userManager.FindByEmailAsync(user.Email) != null;
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
