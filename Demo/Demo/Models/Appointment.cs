//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public string Type { get; set; }
        public System.DateTime Date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
