using HotelManager.Data;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using HotelManager.Common;
using HotelManager.Data.Entities;

namespace HotelManager.Initialisation
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<HotelManagerDbContext>();
                db.Database.Migrate();

                if (!db.Roles.AnyAsync().Result)
                {
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                    Task.Run(async () =>
                    {
                        var adminRole = GlobalConstants.AdminRole;
                        var userRole = GlobalConstants.UserRole;

                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminRole
                        });

                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = userRole
                        });
                    }).Wait();

                    User user = new User
                    {
                        UserName = "Admin",
                        FirstName = "Admin1",
                        FathersName = "Admin2",
                        Surname = "Admin3",
                        PersonalNumber = "0213546875",
                        Admin = true,
                        ActiveOrNotActiveAccount = true,
                        ClientReservation = new HashSet<Reservation>(),
                    };

                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                    string pass = "Admin";
                    Task.Run(async () =>
                    {
                        await userManager.CreateAsync(user, pass);
                        await userManager.AddToRoleAsync(user, "Admin");
                    }).Wait();
                }
            }

            return app;
        }
    }
}
