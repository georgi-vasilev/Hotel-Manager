using HotelManager.Common;
using HotelManager.Data.Entities;
using HotelManager.Models.User;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        public async Task<IActionResult> All()
        {
            var users = await userManager.GetUsersInRoleAsync(GlobalConstants.UserRole);
            return View(users);
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            bool result = userService.RegisterNewUser(model).Result;
            if (!result)
            {
                return this.View(model);
            }
            else
            {
                return RedirectToAction(nameof(All));
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            bool result = userService.Login(model).Result;
            if (!result)
            {
                return this.View(model);
            }
            else
            {
                return Redirect("/");
            }
        }

        public IActionResult Logout()
        {
            userService.Logout();
            return Redirect("/");
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            return await this.CreateUserViewById(id);
        }

        private async Task<IActionResult> CreateUserViewById(string id)
        {
            User user = await this.userService.GetUserById(id);

            DetailsUserViewModel model = new DetailsUserViewModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                FathersName = user.FathersName,
                Surname = user.Surname,
                PersonalNumber = user.PersonalNumber,
                DateOfAppointment = user.DateOfAppointment,
                ActiveOrNotActiveAccount = user.ActiveOrNotActiveAccount,
                DateOfDismissal = user.DateOfDismissal,
                Admin = user.Admin,
            };

            return View(model);
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return await this.CreateUserViewById(id);
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.userService.DeleteUser(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await this.CreateUserViewById(id);
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditConfirm(DetailsUserViewModel model)
        {
            await this.userService.EditUser(model);

            return RedirectToAction(nameof(All));
        }
    }
}