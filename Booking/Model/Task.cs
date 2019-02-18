using System.Collections.Generic;

namespace Booking.Model
{
    public class Task
    {
        public Room Room { get; set; }
        public Status Status { get; set; }
        public List<Note> Notes { get; set; }
    }
}
