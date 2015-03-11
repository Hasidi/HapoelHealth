using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class CorrespondenceHistory
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

        [Key]
        [Column(Order = 3)]
        [DataType(DataType.Time)]
        public DateTime hour { get; set; }

        public string description { get; set; }

        public bool seen_by_reciever { get; set; }


    }
}