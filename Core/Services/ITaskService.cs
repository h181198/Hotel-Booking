using Core.Models;
using System.Data.Entity;

namespace Core.Services
{
    public interface ITaskService
    {
        /** 
         *  Adds the task to the database.
         **/
        void Add(task task);

        /**
         * Get a list of all tasks.
         **/
        DbSet<task> GetAll();

        /**
         * Find a task from id.
         **/
        task Find(int id);

        /**
         * Delete the task from the database.
         **/
        void Delete(task task);

        /**
         * Create a new task from data
         **/
        task CreateTask(string type, int room_id, string description);
    }
}
