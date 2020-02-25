using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Models.Client
{
    public interface IClientService
    {
        ClientViewModel GetById(string id);
    }
}
