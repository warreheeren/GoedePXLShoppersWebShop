using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PXLPro2022Shoppers07.ViewModels;
using System.Threading.Tasks;

namespace PXLPro2022Shoppers07.Controllers
{
    public class AccountController : Controller
    {
            UserManager<IdentityUser> _userManager;
            RoleManager<IdentityRole> _roleManager;
            SignInManager<IdentityUser> _signInManager;

            public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _signInManager = signInManager;

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

                    var identityUser = new IdentityUser() { UserName = user.Email, Email = user.Email, };
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
            #endregion


            public IActionResult AccessDenied()
            {
                return View();
            }


        }
    }

