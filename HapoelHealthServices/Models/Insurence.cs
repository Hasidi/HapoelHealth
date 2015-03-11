using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Insurence
    {
        [Key]
        public int insuranceCode { get; set; }
        public string insurance_name { get; set; }
        public string policy { get; set; }
    }
}