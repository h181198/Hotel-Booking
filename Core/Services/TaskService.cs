using System;
using System.Data.Entity;
using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class TaskService : ITaskService
    {
        private BookingEntities db = new BookingEntities();

        public void Add(task task)
        {
            int newId = db.tasks.ToList().Last().id + 1;
            
            task.id = newId;
            db.tasks.Add(task);
            db.SaveChanges();
        }

        public task CreateTask(string type, int room_id, string description)
        {
            task task = new task();
            task.room_id = room_id;
            task.created_at = DateTime.Today;
            task.type = type + ": " + description;
            return task;
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
