using HotelManager.Data.Entities;
using HotelManager.Models.Reservation;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService service;

        public ReservationController(IReservationService service)
        {
            this.service = service;
        }

        public IActionResult ShowDetails(int id)
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationInputModel model)
        {
            service.Create(model);

            return Redirect("/");
        }

        public IActionResult Edit(int id)
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

            return Redirect("/");
        }

        public IActionResult Delete(int id)
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
        public IActionResult DeleteConfirm(int id)
        {
            service.Delete(id);

            return Redirect("/");
        }
    }
}