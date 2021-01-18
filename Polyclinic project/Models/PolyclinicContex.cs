using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Polyclinic_project.Models
{
    public class PolyclinicContext : DbContext
    {
        public DbSet<Cities> City { get; set; }
        public DbSet<Polyclinics> Polyclinic { get; set; }
        public DbSet<Departments> Department { get; set; }
        public DbSet<Doctors> Doctor { get; set; }
        public DbSet<Patients> Patient { get; set; }
        public DbSet<Tickets> Ticket { get; set; }
        public DbSet<Receptions> Reception { get; set; }
    }
}