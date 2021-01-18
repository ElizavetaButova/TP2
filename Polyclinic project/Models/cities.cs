using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class Cities
    {
        [Key]
        public int City_code { get; set; }
        public string City_name { get; set; }
    }
}