using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using ZhotelWeb.Repositories;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;
using ZHotelWeb.Models.DTOs;

namespace ZhotelWeb.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ICustomerHalper dataHalperCust;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ICustomerHalper dataHalperCust)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataHalperCust = dataHalperCust;
        }


        public async Task<IActionResult> Login()
        {
                return View();           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = await userManager.FindByNameAsync(userLoginDto.UserName);
                if (identityUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(identityUser, userLoginDto.Password);
                    if (found)
                    {
						await signInManager.SignInAsync(identityUser, userLoginDto.RememberMe);
                        var userRole = await userManager.GetRolesAsync(identityUser);

                        if (userRole.FirstOrDefault() != "User")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        return RedirectToAction("Index", "HomeUser");
                    }
                }
				ModelState.AddModelError("", "Username and password invalid");

			}
			return View();
		}


		public async Task<IActionResult> Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(UserCustRegistration userCustRegistration)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser()
                {
                    UserName = userCustRegistration.UserName,
                    Email = userCustRegistration.Email,
                    PasswordHash = userCustRegistration.Password
                };
                Customer customer = new Customer()
                {
                    FirstName = userCustRegistration.FirstName,
                    LastName = userCustRegistration.LastName,
                    Email = userCustRegistration.Email,
                    Phone = userCustRegistration.Phone
                };
                IdentityResult identityResult = await userManager.CreateAsync(identityUser, userCustRegistration.Password);
                if (identityResult.Succeeded)
                {
                    await dataHalperCust.Add(customer);
                    await signInManager.SignInAsync(identityUser, false);
                    await userManager.AddToRoleAsync(identityUser, "User");
                    return RedirectToAction("Index", "HomeUser");
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userCustRegistration);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
