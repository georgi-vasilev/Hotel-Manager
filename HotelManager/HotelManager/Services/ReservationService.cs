using AutoMapper;
using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using HotelManager.Models.Reservation;
using HotelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManager.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotelManagerDbContext context;
        private readonly IMapper mapper;

        public ReservationService(HotelManagerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<ReservationViewModel> All()
        {
            IEnumerable<ReservationViewModel> reservations = context.Reservations
                .Select(x => new ReservationViewModel()
                {
                    RoomId = x.RoomId,
                    Room = x.Room,                
                    UserId = x.UserId,
                    User = x.Employee,
                    ClientId= x.ClientId,
                    Client = x.Client,
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

        public double CalculateBill(ReservationInputModel model)
        {
            double result = 0;
            int period = (model.CheckOut - model.CheckIn).Days;

            Room room = context.Rooms.Find(model.RoomId);
            var clientReservations = context.ClientReservations.Where(cr => cr.ReservationId == model.Id).ToList();
            var clients = new List<Client>();
            foreach (var item in clientReservations)
            {
                clients.Add(context.Clients.FirstOrDefault(c => c.Id == item.ClientId));
            }

            foreach (var client in clients)
            {
                if (client.Adult)
                {
                    result += period * room.PricePerAdult;
                }
                else
                {
                    result += period * room.PricePerKid;
                }
            }
            return result;

        }

        public void Create(ReservationInputModel model)
        {
            Reservation reservations = new Reservation
            {
                RoomId = model.RoomId,
                UserId = model.UserId,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                IncludeBreakfast = model.IncludeBreakfast,
                AllInclusive = model.AllInclusive,
                Bills = model.Bills,
            };

            foreach (var clientModel in model.Clients)
            {
                Client currentClient = new Client
                {
                    FirstName = clientModel.FirstName,
                    Surname = clientModel.Surname,
                    Email = clientModel.Email,
                    PhoneNumber = clientModel.PhoneNumber,
                    Adult = clientModel.Adult,

                };

                if (!context.Clients.Contains(currentClient))
                {
                    context.Clients.Add(currentClient);
                    context.SaveChanges();
                }

                var clientReservation = new ClientReservation
                {
                    Client = GetClient(clientModel),
                    Reservation=reservations,
                    ReservationId=reservations.Id,
                    ClientId = GetClient(clientModel).Id
                };

                reservations.ClientReservations.Add(clientReservation);
            }

            context.Reservations.Add(reservations);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            Reservation reservation = context.Reservations.Find(id);
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public void Edit(ReservationEditModel model)
        {
            Reservation reservation = context.Reservations.Find(model.Id);
            reservation.RoomId = model.RoomId;
            reservation.UserId = model.UserId;
            reservation.Id = model.Id;
            reservation.ClientReservations = model.ClientReservations;
            reservation.CheckIn = model.CheckIn;
            reservation.CheckOut = model.CheckOut;
            reservation.IncludeBreakfast = model.IncludeBreakfast;
            reservation.AllInclusive = model.AllInclusive;
            reservation.Bills = model.Bills;

        }

        public Reservation GetById(string id)
        {
            return context.Reservations.Find(id);
        }

        private Client GetClient(ClientInputModel model)
        {
            var client = context.Clients.FirstOrDefault(c =>
            c.Email == model.Email &&
            c.PhoneNumber == model.PhoneNumber);

            if(client == null)
            {
                client = mapper.Map<Client>(model);
                client.Id = Guid.NewGuid().ToString();
            }

            return client;
        }
    }
}
