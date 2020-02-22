using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.User;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> singInManager;
        private readonly UserManager<User> userManager;
        private readonly HotelManagerDbContext dbContext;

        public UserService(SignInManager<User> singInManager, UserManager<User> userManager, HotelManagerDbContext dbContext)
        {
            this.singInManager = singInManager;
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

            var result = await this.singInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

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



            if (this.userManager.Users.Count() == 1)
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
            await this.singInManager.SignOutAsync();

        }
    }
}
