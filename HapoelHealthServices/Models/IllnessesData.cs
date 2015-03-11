using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class IllnessesData
    {
        [Key]
        public string illnessName { get; set; }
        public string body_area { get; set; }
        public string symptoms { get; set; }
        public string causes { get; set; }
        public string treatments { get; set; }
    }
}