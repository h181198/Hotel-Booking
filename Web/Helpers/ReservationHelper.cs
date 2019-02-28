using Core.Models;
using System.Collections.Generic;
using Web.Model;

namespace Web.Helpers
{
    public class ReservationHelper
    {
        public static ReservationIndexModel ModelListTo(List<reservation> reservations)
        {
            var reservationList = new List<ReservationModel>();

            foreach (var res in reservations)
            {
                var resModel = new ReservationModel
                {
                    Start = res.start_time,
                    End = res.end_time,
                    Beds = res.room.beds,
                    Quality = res.room.quality
                };

                reservationList.Add(resModel);
            }

            return new ReservationIndexModel { Reservations = reservationList };
        }

    }
}