using System;
using System.Threading.Tasks;

namespace HotelManager.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(HotelManagerDbContext dbContext, IServiceProvider serviceProvider);
    }
}
