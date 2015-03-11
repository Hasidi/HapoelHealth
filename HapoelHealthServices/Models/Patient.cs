using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Patient : Person
    {
        public string insurance_type { get; set; }
        public string payerID { get; set; }
        [Required]
        public string password { get; set; }
        public string is_mikur_hutz { get; set; }
    }
}