//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestFix.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class reservation
    {
        public int id { get; set; }
        public int room_id { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime start_time { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime end_time { get; set; }
    
        public virtual room room { get; set; }
    }
}
