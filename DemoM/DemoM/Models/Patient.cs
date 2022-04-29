using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoM.Models
{
    [Table("Patient", Schema = "dbo")]
    public partial class Patient
    {
        public Patient()
        {
            this.Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<bool> Gender { get; set; }
        public System.DateTime BirthDate { get; set; }

        [NotMapped]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}