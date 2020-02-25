using AutoMapper;
using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using System.Threading.Tasks;

namespace HotelManager.Services
{
    public class ClientService : IClientService
    {
        private readonly HotelManagerDbContext context;
        private readonly IMapper mapper;

        public ClientService(HotelManagerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ClientViewModel GetById(string id)
        {
            Client client = context.Clients.Find(id);

            ClientViewModel model = mapper.Map<ClientViewModel>(client);
            return model;
        }
    }
}
