using DemoM.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.IO;

namespace DemoM.Data
{
    public class PopaaDbContext : DbContext
    {
        public PopaaDbContext() { }
        public PopaaDbContext(DbContextOptions<PopaaDbContext> options) : base(options)
        {
        }

        [NotMapped]
        public virtual DbSet<Appointment> Appointments { get; set; }
        [NotMapped]
        public virtual DbSet<Doctor> Doctors { get; set; }
        [NotMapped]
        public virtual DbSet<MedicalCenter> MedicalCenters { get; set; }
        [NotMapped]
        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("popaadb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Doctor>().ToTable("popaadb.Doctor");
        //    modelBuilder.Entity<Patient>().ToTable("popaadb.dbo.Patient");
        //    modelBuilder.Entity<Appointment>().ToTable("popaadb.dbo.Appointment");
        //    modelBuilder.Entity<MedicalCenter>().ToTable("popaadb.dbo.MedicalCenter");
        //}
    }
}
