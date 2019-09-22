using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{
    public class Avganger
    {
        public int Id { get; set; }
        public string ForsteAvgang { get; set; }
        public string SisteAvgang { get; set; }
        public string ReiseTid { get; set; }
        public string Spor { get; set; }
        public string TogNummer { get; set; }

    }

    public class AvgangContext : DbContext
    {
        public AvgangContext() : base("name=Avganger")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Avganger> Avganger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}