using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using HotelManager.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HotelManager.Services
{
    public class ClientService : IClientService
    {
        private readonly HotelManagerDbContext context;

        public ClientService(HotelManagerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClientViewModel> All()
        {
            IEnumerable<ClientViewModel> clients = context.Clients
                .Select(x => new ClientViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    Surname = x.Surname,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Adult = x.Adult,
                    ClientReservations = x.ClientReservations,
                }).ToList();

            return clients;
        }

        public void Create(ClientInputViewModel model)
        {
            Client client = new Client
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Adult = model.Adult,
            };

            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Client client = context.Clients.Find(id);
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        public void Edit(ClientEditViewModel model)
        {
            Client client = context.Clients.Find(model.Id);
            client.FirstName = model.FirstName;
            client.Surname = model.Surname;
            client.PhoneNumber = model.PhoneNumber;
            client.Email = model.Email;
            client.Adult = model.Adult;

            context.Clients.Update(client);
            context.SaveChanges();
        }

        public Client GetById(int id)
        {
            return context.Clients.Find(id);
        }
    }
}
