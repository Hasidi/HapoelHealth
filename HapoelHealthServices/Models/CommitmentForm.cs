using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class CommitmentForm
    {
        [Key]
        public int commitmentCode { get; set; }

        public int patientID { get; set; }
        public virtual Patient Patients { get; set; }

        public string hospital_name { get; set; }

        public int testCode { get; set; }
        public virtual Test Tests { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        public bool was_printed { get; set; }
    }
}