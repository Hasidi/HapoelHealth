using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HapoelHealthServices.Models
{
    public abstract class Person
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ScaffoldColumn(true)]
        public int ID { get; set; }
        [Display(Name = "first name ")]
        public string f_name { get; set; }
        [Display(Name = "last name ")]
        public string l_name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime birth_date { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}