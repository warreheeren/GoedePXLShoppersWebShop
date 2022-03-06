using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.ViewModels;
using System.Threading.Tasks;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class AccountController : Controller
    {
        UserManager<UserDetails> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<UserDetails> _signInManager;
        private IOrderRepository _orderRepository;

        public AccountController(UserManager<UserDetails> userManager, RoleManager<IdentityRole> roleManager, SignInManager<UserDetails> signInManager, IOrderRepository orderRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _orderRepository = orderRepository;

        }

        #region login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await _userManager.FindByEmailAsync(user.Email);
                if (identityUser != null)
                {
                    var userName = identityUser.UserName;
                    var result = await _signInManager.PasswordSignInAsync(userName, user.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                    }
                }
            }

            return View(user);
        }
        #endregion

        #region regiser

        [HttpGet]
        public IActionResult Register()
        {
            //ViewBag.listRole = new SelectList(_context.Roles, "Id", "Name");
            ViewBag.listRole = new SelectList(_roleManager.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(user.RoleId);

                var identityUser = new UserDetails()
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Email = user.Email,
                    BirthDay = user.BirthDay,
                    City = user.City,
                    HouseNumber = user.HouseNumber,
                    PhoneNumber = user.PhoneNumber,
                    StreetName = user.StreetName,
                    PostalCode = user.PostalCode
                };
                var result = await _userManager.CreateAsync(identityUser, user.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "Client");
                    return View("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View(user);
                    }
                }
            }
            ViewBag.listRole = new SelectList(_roleManager.Roles, "Key", "Value");
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails()
        {
            var id = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }
        #endregion


        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            var orderDetail = _orderRepository.getOrderDetails(id);
            return View(orderDetail);
        }


        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var id = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(id);
            var orders = _orderRepository.getOrders(user.Id);
            return View(orders);
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}

