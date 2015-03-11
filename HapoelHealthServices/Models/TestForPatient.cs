using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class TestForPatient
    {
        [Key]
        [Column(Order = 0)]
        public int patientID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int testCode { get; set; }

        public virtual Patient Patients { get; set; }
        public virtual Test Tests { get; set; }

        [Key]
        [Column(Order = 2)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        public string results_file_path { get; set; }
    }
}