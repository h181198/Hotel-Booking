using Core.Models;
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ReservationViewModel
    {
        List<reservation> Reservations { get; set; }
    }

    public class ReservationModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
