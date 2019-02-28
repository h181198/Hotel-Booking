using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class RoomService : IRoomService
    {
        private BookingEntities db = new BookingEntities();

        public void Add(room room)
        {
            db.rooms.Add(room);
            db.SaveChanges();
        }

        public void Delete(room room)
        {
            if (room == null)
            {
                throw new Exception("Room can not be null");
            }
            db.rooms.Remove(room);
            db.SaveChanges();
        }

        public room Find(int id)
        {
            return db.rooms.Find(id);
        }

        public List<room> FindRoomsFromBeds(int beds)
        {
            return db.rooms.Where(r => r.beds == beds).ToList();
        }

        public List<room> FindAvailable(DateTime startTime, DateTime endTime)
        {
            var reservations = db.reservations.Where(res => (res.start_time < startTime && res.end_time > startTime) || 
                                                  res.start_time < endTime && res.end_time > endTime).ToList();
            List<room> rooms = db.rooms.ToList();

            foreach (reservation res in reservations)
            {
                rooms.Remove(res.room);
            }

            return rooms;
        }

        public DbSet<room> GetAll()
        {
            return db.rooms;
        }

        public void UpdateStatus(string status, room room)
        {
            var updatedRoom = Find(room.id);
            updatedRoom.status = "Unclean";

            db.SaveChanges();
            
        }

        public room CreateRoom(int beds, int roomNumber, string quality, string status)
        {
            room r = new room();
            r.beds = beds;
            r.id = roomNumber;
            r.status = status;
            r.quality = quality;

            return r;
        }
    }
}
