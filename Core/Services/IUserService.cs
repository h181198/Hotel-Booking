using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    interface IUserService
    {
        /** 
         *  Adds the user to the database.
         **/
        void Add(user user);

        /**
         * Get a list of all users.
         **/
        DbSet<user> GetAll();

        /**
         * Find a user from id.
         **/
        user Find(int id);

        /**
         * Delete the user from the database.
         **/
        void Delete(user user);
    }
}
