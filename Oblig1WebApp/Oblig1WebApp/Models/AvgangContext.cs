using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Oblig1WebApp.Models
{
    public class Avganger
    {
        public int Id { get; set; }
        public string _ForsteAvgang { get; set; }
        public string _SisteAvgang { get; set; }
    }

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

    public class alleavgangstider
    {
        public int Id { get; set; }
        public string Avgangstid { get; set; }
        public string AvgangstidRetur { get; set; }
    }



    public class AvgangContext : DbContext
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