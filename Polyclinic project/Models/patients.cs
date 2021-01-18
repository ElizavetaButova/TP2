using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Patients
    {

        [Key]
        public int Medcard_num { set; get; }

        public string Pat_fnln { set; get; }
        public int Age { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Insur_num { set; get; }
        public string Passport { set; get; }

    }
}