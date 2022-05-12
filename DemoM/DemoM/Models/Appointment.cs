using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoM.Models
{
    [Table("Appointment", Schema = "dbo")]
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public string Type { get; set; }

        [Required(ErrorMessage = "The appointment date is required!")]
        public System.DateTime Date { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [NotMapped]
        public virtual Doctor Doctor { get; set; }
        [NotMapped]
        public virtual Patient Patient { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> PatientsList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DoctorsList { get; set; }
    }
}