using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.Room;
using System.Collections.Generic;
using System.Linq;

namespace HotelManager.Services.Contracts
{
    public class RoomService : IRoomService
    {
        private readonly HotelManagerDbContext context;

        public RoomService(HotelManagerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RoomViewModel> All()
        {
            IEnumerable<RoomViewModel> rooms = context.Rooms
                .Select(x => new RoomViewModel()
                {
                    Id = x.Id,
                    Capacity = x.Capacity,
                    RoomType=x.RoomType,
                    PricePerAdult=x.PricePerAdult,
                    PricePerKid =x.PricePerKid,
                    RoomNumber=x.RoomNumber,
                }).ToList();

            return rooms;
        }

        public void Create(RoomInputModel model)
        {
            Room room = new Room
            {
                Capacity = model.Capacity,
                RoomType = model.RoomType,
                PricePerAdult = model.PricePerAdult,
                PricePerKid = model.PricePerKid,
                RoomNumber = model.RoomNumber,
            };

            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = context.Rooms.Find(id);
            context.Rooms.Remove(room);
            context.SaveChanges();
        }

        public void Edit(RoomEditModel model)
        {
            Room room = context.Rooms.Find(model.Id);
            room.Capacity = model.Capacity;
            room.RoomType = model.RoomType;
            room.PricePerAdult = model.PricePerAdult;
            room.PricePerKid = model.PricePerKid;
            room.RoomNumber = model.RoomNumber;

            context.Rooms.Update(room);
            context.SaveChanges();
        }

        public Room GetById(int id)
        {
            return context.Rooms.Find(id);
        }
    }
}
