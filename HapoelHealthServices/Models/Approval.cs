using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Approval
    {
        [Key]
        public int approvalCode { get; set; }

        public int patientID { get; set; }
        public int therapistID { get; set; }

        public virtual Patient Patients { get; set; }
        public virtual Therapist Therapists { get; set; }

        public string description { get; set; }
        public bool was_printed { get; set; }
    }
}