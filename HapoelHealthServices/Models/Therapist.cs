using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Therapist : Person
    {
        [Required]
        public string specialization { get; set; }
        [Required]
        public string password { get; set; }
    }
}