using HotelManager.Data.Entities;
using HotelManager.Models.Room;
using System.Collections.Generic;

namespace HotelManager.Services.Contracts
{
    public interface IRoomService
    {
        IEnumerable<RoomViewModel> All();

        void Create(RoomInputModel model);

        void Edit(RoomEditModel model);

        void Delete(string id);

        Room GetById(string id);
    }
}
