using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HapoelHealthServices.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HapoelHealthServices.DAL
{
    public class HealthServicesContext : DbContext
    {
        public HealthServicesContext() : base("HealthServicesContext")
        {
        }
        public DbSet<Person> GeneralEmployees { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Perscription> Perscriptions { get; set; }
        public DbSet<PatientPermanentDrugs> PatientsPermanentDrugs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
    
}