//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EASYGO._2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public int Car_Id { get; set; }
        public System.DateTime Start_time { get; set; }
        public System.DateTime End_time { get; set; }
        public string Customer_Id { get; set; }
    
        public virtual Car Car { get; set; }
    }
}