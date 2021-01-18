using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Doctors
    {
        [ForeignKey("Department")]
        public int Dep_num { set; get; }

        public virtual Departments Department { get; set; }

        [Key]
        public int Doc_id { set; get; }

        public string Doc_fnln { set; get; }
        public string Doc_spec { set; get; }
        public int Doc_office { set; get; }
    }
}