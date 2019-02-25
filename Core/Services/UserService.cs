using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    class UserService : IUserService
    {
        private BookingEntities db = new BookingEntities();

        public void Add(user user)
        {
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

        public DbSet<user> GetAll()
        {
            return db.users;
        }
    }
}
