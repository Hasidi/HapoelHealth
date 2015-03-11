using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Perscription : IValidatableObject
    {
        [Key]
        public int perID { get; set; }

        public int patientID { get; set; }
        public int therapistID { get; set; }
        public int drug_ID { get; set; }

        public virtual Patient Patients { get; set; }
        public virtual Therapist Therapists { get; set; }
        public virtual Drug Drugs { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime expiration_date { get; set; }

        public int dosage { get; set; }
        public bool was_printed { get; set; }


        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if (expiration_date < date)
            {
                ValidationResult mss = new ValidationResult("expiration_date must be greater then the current date");
                res.Add(mss);

            }
            return res;
        }

    

    }
}