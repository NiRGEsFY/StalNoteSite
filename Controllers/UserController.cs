using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StalNoteSite.Models.Users;

namespace StalNoteSite.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View(_userManager);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl == null)
            {
                returnUrl = Url.Action("Index", "Home");
            }
            return View(new LoginViewModel() { ReturnUrl = returnUrl});
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ModelState.Remove("ReturnUrl");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", $"Пользователь не найден");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            ModelState.AddModelError("", "Пароль не верный");
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(StalNoteSite.Models.Users.RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError("", $"Пользователь с таким именем уже существует");
                return View(model);
            }
            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError("", $"Пользователь с такой почтой уже существует");
                return View(model);
            }
            user = new StalNoteSite.User(model);


            var result = _userManager.CreateAsync(user, model.Password).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                _userManager.DeleteAsync(user).GetAwaiter().GetResult();
                return View(model);
            }
            result = await _userManager.AddToRoleAsync(user,"Новичек");
            if (!result.Succeeded)
            {
                return View(model);
            }

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            ModelState.AddModelError("", "Пароль ненадежный");
            return View(model);
        }
    }
}
