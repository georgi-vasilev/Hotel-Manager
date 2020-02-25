using AutoMapper;
using HotelManager.Data.Entities;
using HotelManager.Models.User;

namespace HotelManager.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>();
        }
    }
}
