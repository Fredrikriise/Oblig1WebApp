using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TrackerEnabledDbContext;

namespace Oblig1WebApp.DAL
{
    [TrackChanges]
    public class Avganger
    {
        public int Id { get; set; }
        public string _ForsteAvgang { get; set; }
        public string _SisteAvgang { get; set; }
    }

    [TrackChanges]
    public class visAvganger
    {
        public int Id { get; set; }
        public string ForsteAvgang { get; set; }
        public string SisteAvgang { get; set; }
        public string ReiseTid { get; set; }
        public string Spor { get; set; }
        public string TogNummer { get; set; }
        public int Sone { get; set; }
        public int Pris { get; set; }
    }

    [TrackChanges]
    public class alleavgangstider
    {
        public int Id { get; set; }
        public string Avgangstid { get; set; }
        public string AvgangstidRetur { get; set; }
    }

    public class AvgangContext : TrackerContext
    {
        public AvgangContext() : base("name=Avganger")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Avganger> Avganger { get; set; }
        public DbSet<visAvganger> visAvganger { get; set; }
        public DbSet<alleavgangstider> alleavgangstider { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}