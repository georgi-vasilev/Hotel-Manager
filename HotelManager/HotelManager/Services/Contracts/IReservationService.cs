using HotelManager.Data.Entities;
using HotelManager.Models.Reservation;
using System.Collections.Generic;

namespace HotelManager.Services.Contracts
{
    public interface IReservationService
    {
        IEnumerable<ReservationViewModel> All();

        void Create(ReservationInputModel model);

        void Edit(ReservationEditModel model);

        void Delete(string id);

        Reservation GetById(string id);
        double CalculateBill(ReservationInputModel model);
    }
}
