﻿using HotelManager.Data.Entities;
using HotelManager.Models.User;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        private readonly IUserService userService;

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

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
                return Redirect("/");
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
            if(!result)
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
    }
}