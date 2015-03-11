using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public class Branch
    {
        [Key]
        public int branchID { get; set; }
        public int managerID { get; set; }

        public virtual GeneralEmployee GeneralEmployees { get; set; }

        public string city { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        
    }
}