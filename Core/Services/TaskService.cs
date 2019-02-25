using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    class TaskService : ITaskService
    {
        private BookingEntities db = new BookingEntities();

        public void Add(task task)
        {
            db.tasks.Add(task);
            db.SaveChanges();
        }

        public void Delete(task task)
        {
            if (task == null)
            {
                throw new Exception("Task can not be null");
            }
            db.tasks.Remove(task);
            db.SaveChanges();
        }

        public task Find(int id)
        {
            return db.tasks.Find(id);
        }

        public DbSet<task> GetAll()
        {
            return db.tasks;
        }
    }
}
