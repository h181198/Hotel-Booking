using Core.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace Core.Services
{
    public class ReservationService : IReservationService
    {
        private BookingEntities db = new BookingEntities();

        public void Add(reservation reservation)
        {
            int newId = db.reservations.ToList().Last().id + 1;
            reservation.id = newId;
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

        public List<reservation> FindRoomReservations(int roomId)
        {
            return db.reservations.Where(res => res.room_id == roomId).ToList();
        }

        public List<reservation> FindReservationInterval(DateTime startDate, DateTime endDate)
        {
            return db.reservations.Where(res => res.start_time > startDate && res.end_time < endDate).ToList();
        }

        public List<reservation> FindReservationUser(int userId)
        {
            return db.reservations.Where(res => res.user_id == userId).ToList();
        }

        public DbSet<reservation> GetAll()
        {
            return db.reservations;
        }

        public reservation CreateReservation(DateTime startTime, DateTime endTime, int userId, int roomId)
        {
            var res = new reservation();
            res.end_time = endTime;
            res.start_time = startTime;
            res.user_id = userId;
            res.room_id = roomId;
            return res;
        }
    }
}
