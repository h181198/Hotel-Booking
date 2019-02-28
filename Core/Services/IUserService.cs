using Core.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Core.Services
{
    public interface IUserService
    {
        /** 
         *  Adds the user to the database.
         **/
        void Add(user user);

        /** 
         *  Adds the user to the database.
         **/
        user Create(string email);

        /**
         * Get a list of all users.
         **/
        DbSet<user> GetAll();

        /**
         * Find a user from id.
         **/
        user Find(int id);

        /**
         * Find a user from email
         **/
        List<user> FindEmail(string email);

        /**
         * Delete the user from the database.
         **/
        void Delete(user user);

        /**
         * If user is not found, it is created.
         **/
        user CreateIfAbsent(string email);
    }
}
