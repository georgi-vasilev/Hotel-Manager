using HotelManager.Data.Entities;
using HotelManager.Models.Room;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelManager.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService service;

        public RoomController(IRoomService service)
        {
            this.service = service;
        }
        public IActionResult All()
        {
            IEnumerable<RoomViewModel> model = service.All();
            return View(model);
        }

        public IActionResult ShowDetails(string id)
        {
            Room room = service.GetById(id);

            RoomDetailsViewModel model = new RoomDetailsViewModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                PricePerAdult = room.PricePerAdult,
                PricePerKid = room.PricePerKid,
                RoomNumber = room.RoomNumber,
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomInputModel model)
        {
            service.Create(model);

            return Redirect("/Room/All");
        }

        public IActionResult Edit(string id)
        {
            Room room = service.GetById(id);
            RoomEditModel model = new RoomEditModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                PricePerAdult = room.PricePerAdult,
                PricePerKid = room.PricePerKid,
                RoomNumber = room.RoomNumber,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(RoomEditModel model)
        {
            service.Edit(model);

            return Redirect("/Room/All");
        }

        public IActionResult Delete(string id)
        {
            Room room = service.GetById(id);
            RoomDetailsViewModel model = new RoomDetailsViewModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                PricePerAdult = room.PricePerAdult,
                PricePerKid = room.PricePerKid,
                RoomNumber = room.RoomNumber,
            };

            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(string id)
        {
            service.Delete(id);

            return Redirect("/Room/All");
        }
    }  
}