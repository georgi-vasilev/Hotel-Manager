using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HotelManager.Models.User;
using HotelManager.Models.Client;
using HotelManager.Models.Room;
using HotelManager.Models.Reservation;

namespace HotelManager.Data
{
    public class HotelManagerDbContext : IdentityDbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Employees { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<ClientReservation> ClientReservations { get; set; }


        public HotelManagerDbContext(DbContextOptions<HotelManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ClientReservation>()
                .HasKey(cr => new { cr.ClientId, cr.ReservationId });

            builder.Entity<ClientReservation>()
                .HasOne(cr => cr.Client)
                .WithMany(c => c.ClientReservations)
                .HasForeignKey(cr => cr.ClientId);

            builder.Entity<ClientReservation>()
                .HasOne(cr => cr.Reservation)
                .WithMany(r => r.ClientReservations)
                .HasForeignKey(cr => cr.ReservationId);

            base.OnModelCreating(builder);
        }
    }
}
