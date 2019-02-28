using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private BookingEntities db = new BookingEntities();


        public user CreateIfAbsent(string email)
        {
            var users = FindEmail(email);
            var user = users.Any() ? users.First() : Create(email);
            return user;
        }

        public user Create(string email)
        {
            var user = new user
            {
                email = email,
                password = ""
            };
            Add(user);
            return user;
        }

        public void Add(user user)
        {
            int newId = db.users.ToList().Last().id + 1;
            user.id = newId;
            db.users.Add(user);
            db.SaveChanges();
        }

        public void Delete(user user)
        {
            if (user == null)
            {
                throw new Exception("User cannot be null");
            }
            db.users.Remove(user);
            db.SaveChanges();
        }

        public user Find(int id)
        {
            return db.users.Find(id);
        }

        public List<user> FindEmail(string email)
        {
            return db.users.Where(u => u.email.Equals(email)).ToList();
        }

        public DbSet<user> GetAll()
        {
            return db.users;
        }
    }
}
