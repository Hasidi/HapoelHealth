using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Drug
    {
        [Key]
        public int drug_ID { get; set; }
        public string drug_name { get; set; }
        public string description { get; set; }
    }
}