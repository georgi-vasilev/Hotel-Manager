using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.Reservation;
using HotelManager.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HotelManager.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotelManagerDbContext context;

        public ReservationService(HotelManagerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ReservationViewModel> All()
        {
            IEnumerable<ReservationViewModel> reservations = context.Reservations
                .Select(x => new ReservationViewModel()
                {
                    RoomId = x.RoomId,
                    UserId = x.UserId,
                    Id = x.Id,
                    ClientReservations = x.ClientReservations,
                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    IncludeBreakfast = x.IncludeBreakfast,
                    AllInclusive = x.AllInclusive,
                    Bills = x.Bills,
                }).ToList();

            return reservations;
        }

        public void Create(ReservationInputModel model)
        {
            Reservation reservations = new Reservation
            {
                RoomId = model.RoomId,
                UserId = model.UserId,
                Id = model.Id,
                ClientReservations = model.ClientReservations,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                IncludeBreakfast = model.IncludeBreakfast,
                AllInclusive = model.AllInclusive,
                Bills = model.Bills,
            };

            context.Reservations.Add(reservations);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Reservation reservation = context.Reservations.Find(id);
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public void Edit(ReservationEditModel model)
        {
            Reservation reservation = context.Reservations.Find(model.Id);
            model.RoomId = model.RoomId;
            model.UserId = model.UserId;
            model.Id = model.Id;
            model.ClientReservations = model.ClientReservations;
            model.CheckIn = model.CheckIn;
            model.CheckOut = model.CheckOut;
            model.IncludeBreakfast = model.IncludeBreakfast;
            model.AllInclusive = model.AllInclusive;
            model.Bills = model.Bills;

        }

        public Reservation GetById(int id)
        {
            return context.Reservations.Find(id);
        }
    }
}
