using AutoMapper;
using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.User;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelManager.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly HotelManagerDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, HotelManagerDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<bool> Login(LoginUserViewModel model)
        {
            var user = this.GetUser(model.Username).Result;
            if (user == null)
            {
                return false;
            }

            var result = await this.signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }


        public async Task<bool> RegisterNewUser(RegisterUserViewModel model)
        {
            if (model.Username == null ||
                model.Password == null ||
                model.ConfirmPassword == null ||
                model.FirstName == null ||
                model.FathersName == null ||
                model.Surname == null ||
                model.PersonalNumber == null ||
                model.PhoneNumber == 0 ||
                model.Email == null ||
                model.DateOfAppointment == null ||
                model.ActiveOrNotActiveAccount == false ||
                model.DateOfDismissal == null
                )
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }

            var user = new User
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                FathersName = model.FathersName,
                Surname = model.Surname,
                PersonalNumber = model.PersonalNumber,
                DateOfAppointment = model.DateOfAppointment,
                ActiveOrNotActiveAccount = model.ActiveOrNotActiveAccount,
                DateOfDismissal = model.DateOfDismissal,
                Admin = model.Admin
            };

            var userCreateResult = await this.userManager.CreateAsync(user, model.Password);


            if (!userCreateResult.Succeeded)
            {
                return false;
            }

            IdentityResult addRoleResult = null;



            if (model.Admin == true)
            {
                addRoleResult = await this.userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                addRoleResult = await this.userManager.AddToRoleAsync(user, "User");
            }

            if (!addRoleResult.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            return user;
        }

        public async void Logout()
        {
            await this.signInManager.SignOutAsync();

        }

        public async Task<User> GetUserById(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await GetAllUsers().ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync(Expression<Func<User, bool>> predicate)
        {
            return await GetAllUsers().Where(predicate).ToListAsync();
        }

        private IQueryable<User> GetAllUsers()
        {
            return this.userManager.Users.AsQueryable();
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = this.userManager.FindByIdAsync(id).Result;

            return await this.userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> EditUser(DetailsUserViewModel model)
        {
            User user = await this.userManager.FindByIdAsync(model.Id);

            user.UserName = model.Username;
            user.FirstName = model.FirstName;
            user.FathersName = model.FathersName;
            user.Surname = model.Surname;
            user.PersonalNumber = model.PersonalNumber;
            user.DateOfAppointment = model.DateOfAppointment;
            user.ActiveOrNotActiveAccount = model.ActiveOrNotActiveAccount;
            user.DateOfDismissal = model.DateOfDismissal;
            user.Admin = model.Admin;

            return await this.userManager.UpdateAsync(user);
        }
    }
}
