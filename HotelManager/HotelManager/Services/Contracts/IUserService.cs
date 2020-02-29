using HotelManager.Data.Entities;
using HotelManager.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManager.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> RegisterNewUser(RegisterUserViewModel model);

        Task<bool> Login(LoginUserViewModel model);

        void Logout();

        Task<User> GetUserById(string id);

        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetAllUsersAsync(Expression<Func<User, bool>> predicate);

        Task<IdentityResult> DeleteUser(string id);

        Task<IdentityResult> EditUser(DetailsUserViewModel model);
    }
}
