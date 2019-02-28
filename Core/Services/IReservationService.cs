using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Core.Services
{
    public interface IReservationService
    {
        /** 
         *  Adds the reservation to the database.
         **/
        void Add(reservation reservation);

        /**
         * Get a list of all reservations.
         **/
        DbSet<reservation> GetAll();

        /**
         * Find a reservation from id.
         **/
        reservation Find(int id);

        /**
         * Find all reservation with a room id.
         */
        List<reservation> FindRoomReservations(int roomId);

        /**
         * Find all reservations in an interval
         */
        List<reservation> FindReservationInterval(DateTime startDate, DateTime endDate);

        /**
         * Find reservaitons for a user id
         */
        List<reservation> FindReservationUser(int userId);

        /**
         * Delete the reservation from the database.
         **/
        void Delete(reservation reservation);

        /**
         * Create a new reservation
         **/
        reservation CreateReservation(DateTime startTime, DateTime endTime, int userId, int roomId);
    }
}
