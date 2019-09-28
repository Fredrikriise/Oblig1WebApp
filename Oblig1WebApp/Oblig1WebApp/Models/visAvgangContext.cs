using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{ 
    public class visAvganger
    {
        public int Id { get; set; }
        public string ForsteAvgang { get; set; }
        public string SisteAvgang { get; set; }
        public string ReiseTid { get; set; }
        public string Spor { get; set; }
        public string TogNummer { get; set; }
        public string Avgangstid { get; set; }
    }

    public class visAvgangContext : DbContext
    {
        public visAvgangContext() : base("name=visAvganger")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<visAvganger> visAvganger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}