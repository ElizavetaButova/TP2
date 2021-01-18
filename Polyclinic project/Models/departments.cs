using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Departments
    {
        [ForeignKey("Polyclinic")]
        public int Pol_num { set; get; }
        public virtual Polyclinics Polyclinic { get; set; }

        [Key]
        public int Dep_num { set; get; }

        public string Dep_name { set; get; }
    }
}