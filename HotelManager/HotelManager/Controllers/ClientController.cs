using HotelManager.Data.Entities;
using HotelManager.Models.Client;
using HotelManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelManager.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        public IActionResult All()
        {
            IEnumerable<ClientViewModel> model = service.All();
            return View(model);
        }
        public IActionResult ShowDetails(string id)
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientInputViewModel model)
        {
            service.Create(model);

            return Redirect("/Client/All");
        }

        public IActionResult Edit(string id)
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

            return Redirect("/Client/All");
        }

        public IActionResult Delete(string id)
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
        public IActionResult DeleteConfirm(string id)
        {
            service.Delete(id);

            return Redirect("/Client/All");
        }
    }
}