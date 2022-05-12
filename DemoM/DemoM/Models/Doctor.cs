using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoM.Models
{
    [Table("Doctor", Schema = "dbo")]
    public class Doctor
    {
        public Doctor()
        {
            this.Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Specialization { get; set; }
        public Nullable<int> Experience { get; set; }
        [ForeignKey("MedicalCenter")]
        public Nullable<int> MedicalCenterId { get; set; }

        [NotMapped]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [NotMapped]
        public virtual MedicalCenter MedicalCenter { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MedicalCentersList { get; set; }
    }
}