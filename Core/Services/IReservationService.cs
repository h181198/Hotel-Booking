using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    interface IReservationService
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
         * Delete the reservation from the database.
         **/
        void Delete(reservation reservation);
    }
}
