using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Core.Services
{
    public interface IRoomService
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
         * Find room(s) from number of beds.
         **/
        List<room> FindRoomsFromBeds(int beds);

        /**
         * Update a rooms status
         **/
        void UpdateStatus(string status, room room);

        /**
         * Delete the room from the database.
         **/
        void Delete(room room);

        /**
         * Find all available rooms in a timeinterval.
         **/
        List<room> FindAvailable(DateTime startTime, DateTime endTime);

        /**
         * Create a new room
         **/
        room CreateRoom(int beds, int roomNumber, string quality, string status);
    }
}
