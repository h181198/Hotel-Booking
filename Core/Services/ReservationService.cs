using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    class ReservationService : IReservationService
    {
        private BookingEntities db = new BookingEntities();

        public void Add(reservation reservation)
        {
            db.reservations.Add(reservation);
            db.SaveChanges();
        }

        public void Delete(reservation reservation)
        {
            if (reservation == null)
            {
                throw new Exception("Reservation can not be null");
            }
            db.reservations.Remove(reservation);
            db.SaveChanges();
        }

        public reservation Find(int id)
        {
            return db.reservations.Find(id);
        }

        public DbSet<reservation> GetAll()
        {
            return db.reservations;
        }
    }
}
