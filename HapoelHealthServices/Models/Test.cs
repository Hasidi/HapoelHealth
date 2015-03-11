using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Test
    {
        [Key]
        public int testCode { get; set; }
        public string test_name { get; set; }
        public string description { get; set; }
    }
}