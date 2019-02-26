using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private BookingEntities db = new BookingEntities();

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
