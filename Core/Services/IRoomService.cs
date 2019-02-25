using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    interface IRoomService
    {
        /** 
         *  Adds the room to the database.
         **/
        void Add(room room);

        /**
         * Get a list of all rooms.
         **/
        DbSet<room> GetAll();

        /**
         * Find a room from id.
         **/
        room Find(int id);

        /**
         * Delete the room from the database.
         **/
        void Delete(room room);

        /**
         * Find all available rooms in a timeinterval.
         **/
        List<room> FindAvailable(DateTime startTime, DateTime endTime);
    }
}
