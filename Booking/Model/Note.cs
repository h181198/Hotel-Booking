using System;

namespace Booking.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Task Task { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
