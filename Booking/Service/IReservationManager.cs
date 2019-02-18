using Booking.Model;
using System.Collections.Generic;

namespace Booking.Service
{
    public interface IReservationManager
    {
        Reservation Create(Room room);

        Reservation Delete(Reservation res);

        List<Reservation> ListByRoom();

        List<Reservation> ListOccupied();

        Reservation Read(int id);

        Reservation Update(Reservation res);

        void AddNote(string content, Task task);
    }
}
