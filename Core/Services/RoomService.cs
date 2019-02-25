using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    class RoomService : IRoomService
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

        public List<room> FindAvailable(DateTime startTime, DateTime endTime)
        {
            List<room> availableRooms = null;
            bool isAvailable;

            foreach (room r in db.rooms)
            {
                isAvailable = true;
                foreach(reservation res in db.reservations)
                {
                    bool startInterval = res.start_time < startTime && res.end_time > startTime;
                    bool endInterval = res.start_time < endTime && res.end_time > endTime;

                    if(res.room.Equals(r) && !startInterval || !endInterval)
                    {
                        isAvailable = false;
                        break;
                    }
                }

                if (isAvailable)
                {
                    availableRooms.Add(r);
                }
            }

            return availableRooms;
        }

        public DbSet<room> GetAll()
        {
            return db.rooms;
        }
    }
}
