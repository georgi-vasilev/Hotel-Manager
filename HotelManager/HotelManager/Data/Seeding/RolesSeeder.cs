using System;
using System.Linq;
using System.Threading.Tasks;
using HotelManager.Common;
using HotelManager.Data;
using HotelManager.Data.Seeding;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JudgeSystem.Data.Seeding
{
    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(HotelManagerDbContext dbContext, IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.Roles.Administrator);
            await SeedRoleAsync(roleManager, GlobalConstants.Roles.Employee);
        }

        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
