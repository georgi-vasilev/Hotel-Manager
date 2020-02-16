using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HotelManager.Data
{
    public class HotelManagerDbContext : IdentityDbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Employees { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }


        public HotelManagerDbContext(DbContextOptions<HotelManagerDbContext> options)
            : base(options)
        {

        }
    }
}
