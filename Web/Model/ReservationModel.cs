using Core.Models;
using System;
using System.Collections.Generic;

namespace Web.Model
{
    public class ReservationModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class ReservationIndexModel
    {
        public IEnumerable<reservation> Reservations { get; set; }
    }
}