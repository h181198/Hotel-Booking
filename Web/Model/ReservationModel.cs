using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Model
{
    public class ReservationModel
    {
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        public string Email { get; set; }

        public int Beds { get; set; }

        public string Quality { get; set; }
    }

    public class ReservationIndexModel
    {
        public IEnumerable<ReservationModel> Reservations { get; set; }
    }
}