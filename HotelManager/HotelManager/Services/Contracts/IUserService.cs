using HotelManager.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> RegisterNewUser(RegisterUserViewModel model);

        Task<bool> Login(LoginUserViewModel model);

        void Logout();
    }
}
