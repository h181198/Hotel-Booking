using System;

namespace Booking.Model
{
    public class Reservation
    {
        public Room Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
