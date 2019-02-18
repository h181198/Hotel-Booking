using Booking.Model;
using System.Collections.Generic;

namespace Booking.Service
{
    public interface IRoomManager
    {
        List<Room> FilterRooms(object filter);

        Room CreateRoom(Room room);
    }
}
