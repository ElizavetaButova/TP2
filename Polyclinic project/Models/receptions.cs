using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Receptions
    {
        [Key]
        public string App_time { set; get; }

        [ForeignKey("Doctor")]
        public int Doc_id { set; get; }
        public virtual Doctors Doctor { get; set; }
    }
}