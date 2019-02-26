using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
