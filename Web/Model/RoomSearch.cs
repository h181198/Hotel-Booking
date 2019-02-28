using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Model
{
    public class RoomSearchIndexModel
    {
        public IEnumerable<room> Results { get; set; }
        public RoomSearch Search { get; set; }
    }

    public class RoomSearch
    {
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        public int Beds { get; set; }
        public string Quality { get; set; }
    }
}