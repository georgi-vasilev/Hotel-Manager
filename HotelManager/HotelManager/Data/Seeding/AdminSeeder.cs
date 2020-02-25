using System;
using System.Threading.Tasks;
using HotelManager.Common;
using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Data.Seeding;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JudgeSystem.Data.Seeding
{
	public class AdminSeeder : ISeeder
	{
		public async Task SeedAsync(HotelManagerDbContext dbContext, IServiceProvider serviceProvider)
		{
			UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
			User userFromDb = await userManager.FindByNameAsync("admin");

            if (userFromDb != null)
            {
                return;
            }

            var user = new User
			{
				Email = "admin@admin.bg",
				UserName = "admin",
				Surname = "Georgi",
			};

			await userManager.CreateAsync(user, "asd123asd");
			await userManager.AddToRoleAsync(user, GlobalConstants.Roles.Administrator);
        }
    }
}
