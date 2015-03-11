using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Appointment
    {
        [Key]
        [Column(Order = 0)]
        public int patientID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int therapistID { get; set; }

        public virtual Patient Patients { get; set; }
        public virtual Therapist Therapists { get; set; }

        [Key]
        [Column(Order = 2)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [DataType(DataType.Time)]
        public DateTime hour { get; set; }


        public int branchID { get; set; }

        public int room_number { get; set; }
        public string patient_topic_list { get; set; }
        public string conclusions { get; set; }
        public string patient_servey_results { get; set; }
    }
}