using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Tickets
    {
        [Key]
        public int Tick_num { set; get; }

        [ForeignKey("Doctor")]
        public int Doc_id { set; get; }
        public virtual Doctors Doctor { get; set; }
        
        [ForeignKey("Reception")]
        public string App_time{ set; get; }
        public virtual Receptions Reception { get; set; }


        public string pat_fnln { set; get; }

        [ForeignKey("Patient")]
        public int Medcard_num { set; get; }
        public virtual Patients Patient { get; set; }
    }
}