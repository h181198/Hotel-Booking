using System;
using System.Collections.Generic;

namespace App
{
    class TaskManager
    {
        public List<Task> Tasks { get; }

        public TaskManager()
        {
            Tasks = new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    RoomId = 100,
                    Type = "Cleaner",
                    Status = "New",
                },
                new Task()
                {
                    Id = 1,
                    RoomId = 105,
                    Type = "Service",
                    Status = "New"
                },
                new Task()
                {
                    Id = 1,
                    RoomId = 203,
                    Type = "Maintainer",
                    Status = "In Progress"
                },
                new Task()
                {
                    Id = 1,
                    RoomId = 301,
                    Type = "Service",
                    Status = "New"
                },
                new Task()
                {
                    Id = 1,
                    RoomId = 104,
                    Type = "Maintainer",
                    Status = "New"
                },
            };
        }

        public Task Find(int roomNumber)
        {
            return Tasks.Find(t => t.RoomId == roomNumber);
        }

        public List<Task> GetTasks()
        {
            return Tasks;
        }

        public void RemoveTask(int id)
        {
            var task = Tasks.Find(t => t.Id == id);
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }
    }
}
