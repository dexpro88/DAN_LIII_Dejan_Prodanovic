//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_LIII_Dejan_Prodanovic.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManager
    {
        public int ID { get; set; }
        public string HotelFloor { get; set; }
        public Nullable<int> Experience { get; set; }
        public string QualificationsLevel { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}