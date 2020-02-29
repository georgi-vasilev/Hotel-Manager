using HotelManager.Data.Entities;
using HotelManager.Models.Room;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public IActionResult ShowDetails(int id)
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

            return Redirect("/");
        }

        public IActionResult Edit(int id)
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

            return Redirect("/");
        }

        public IActionResult Delete(int id)
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
        public IActionResult DeleteConfirm(int id)
        {
            service.Delete(id);

            return Redirect("/");
        }
    }  
}