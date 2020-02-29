using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using System.Collections.Generic;

namespace HotelManager.Services.Contracts
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> All();

        void Create(ClientInputViewModel model);

        void Edit(ClientEditViewModel model);

        void Delete(int id);

        Client GetById(int id);
    }
}
