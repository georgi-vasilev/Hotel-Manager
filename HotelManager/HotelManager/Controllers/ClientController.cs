using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        public IActionResult ShowDetails(int id)
        {
            Client client = service.GetById(id);

            ClientDetailsViewModel model = new ClientDetailsViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Adult = client.Adult,
                ClientReservations = client.ClientReservations,
            };

            return View(model);
        }

        public IActionResult Craete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientInputViewModel model)
        {
            service.Create(model);

            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            Client client = service.GetById(id);
            ClientEditViewModel model = new ClientEditViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Adult = client.Adult,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ClientEditViewModel model)
        {
            service.Edit(model);

            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            Client client = service.GetById(id);
            ClientDetailsViewModel model = new ClientDetailsViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Adult = client.Adult,
                ClientReservations = client.ClientReservations,
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