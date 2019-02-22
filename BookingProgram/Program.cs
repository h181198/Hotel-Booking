using System;

namespace BookingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Booking.Model.BookingEntities())
            {
                /*
                Console.WriteLine("Write number of beds:");
                var beds = int.Parse(Console.ReadLine());
                Console.WriteLine("Write quality:");
                var quality = Console.ReadLine();
                Console.WriteLine("Write status:");
                var status = Console.ReadLine();

                room room = new room();
                room.beds = beds;
                room.quality = quality;
                room.status = status;

                db.rooms.Add(room);
                db.SaveChanges();
                */
                var test = db.rooms;

                Console.Write(test);
            }
        }
    }
}
