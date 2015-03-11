using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Referring
    {
        [Key]
        public int refferingID { get; set; }
        public int patientID { get; set; }
        public int therapistID { get; set; }
        public int testCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateGiven { get; set; }

        public virtual Patient Patients { get; set; }
        public virtual Therapist Therapists { get; set; }
        public virtual Test Tests { get; set; }
    }
}