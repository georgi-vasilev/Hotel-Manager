using HotelManager.Data.Entities;
using HotelManager.Models.Reservation;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace HotelManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService service;
        private readonly IRoomService roomService;

        public ReservationController(IReservationService service, IRoomService roomService)
        {
            this.service = service;
            this.roomService = roomService;
        }

        public IActionResult All()
        {
            IEnumerable<ReservationViewModel> model = service.All();
            return View(model);
        }

        public IActionResult ShowDetails(string id)
        {
            Reservation reservation = service.GetById(id);

            ReservationDetailsViewModel model = new ReservationDetailsViewModel
            {
                RoomId = reservation.RoomId,
                UserId = reservation.UserId,
                ClientReservations = reservation.ClientReservations,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                IncludeBreakfast = reservation.IncludeBreakfast,
                AllInclusive = reservation.AllInclusive,
                Bills = reservation.Bills,
            };

            return View(model);
        }

        public IActionResult Create()
        {
            var rooms = roomService.All();
            ViewData["Rooms"] = rooms;
            return View(new ReservationInputModel());
        }

        [HttpPost]
        public IActionResult Create(ReservationInputModel model)
        {
            model.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //TODO calculate bill and set it model.Bills = value

            model.Bills = service.CalculateBill(model);
            
            


            service.Create(model);

            return Redirect("/Reservation/All");
        }

        public IActionResult Edit(string id)
        {
            Reservation reservation = service.GetById(id);
            ReservationEditModel model = new ReservationEditModel
            {
                RoomId = reservation.RoomId,
                UserId = reservation.UserId,
                ClientReservations = reservation.ClientReservations,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                IncludeBreakfast = reservation.IncludeBreakfast,
                AllInclusive = reservation.AllInclusive,
                Bills = reservation.Bills,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ReservationEditModel model)
        {
            service.Edit(model);

            return Redirect("/Reservation/All");
        }

        public IActionResult Delete(string id)
        {
            Reservation reservation = service.GetById(id);
            ReservationDetailsViewModel model = new ReservationDetailsViewModel
            {
                RoomId = reservation.RoomId,
                UserId = reservation.UserId,
                ClientReservations = reservation.ClientReservations,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                IncludeBreakfast = reservation.IncludeBreakfast,
                AllInclusive = reservation.AllInclusive,
                Bills = reservation.Bills,
            };

            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(string id)
        {
            service.Delete(id);

            return Redirect("/Reservation/All");
        }
    }
}