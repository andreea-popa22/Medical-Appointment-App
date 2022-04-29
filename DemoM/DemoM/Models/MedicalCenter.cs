using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoM.Models
{
    [Table("MedicalCenter", Schema = "dbo")]
    public class MedicalCenter
    {
        public int MedicalCenterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        [NotMapped]
        public virtual ICollection<Doctor> Doctors { get; set; }

        public MedicalCenter()
        {
            this.Doctors = new HashSet<Doctor>();
        }
    }
}
