using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{ 
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