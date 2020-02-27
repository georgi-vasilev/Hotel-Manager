using AutoMapper;
using HotelManager.Data;
using HotelManager.Data.Entities;
using HotelManager.Models.Room;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService service;
        //private readonly HotelManagerDbContext context;
        //private readonly IMapper mapper;

        // public RoomController(IRoomService service,HotelManagerDbContext context, IMapper mapper)
        // {
        //     this.service = service;
        //     this.context = context;
        //     this.mapper = mapper;
        // }

        public RoomController(IRoomService service)
        {
            this.service = service;
        }
        //public RoomViewModel GetById(string id)
        //{
        //    Room room = context.Rooms.Find(id);
        //
        //    RoomViewModel model = mapper.Map<RoomViewModel>(room);
        //    return model;
        //}
        public IActionResult ShowDetails(int id)
        {
            Room room = service.GetById(id);

            RoomDetailsViewModel model = new RoomDetailsViewModel
            {
                RoomId = room.RoomId,
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
                RoomId = room.RoomId,
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
                RoomId = room.RoomId,
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