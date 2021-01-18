using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Polyclinics
    {
        [ForeignKey("City")]
        public int City_code { set; get; }
        public virtual Cities City { get; set; }

        [Key]
        public int Pol_num { set; get; }

        public string Pol_name { set; get; }
  
    }
}