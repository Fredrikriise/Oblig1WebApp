using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TrackerEnabledDbContext;

namespace Oblig1WebApp.DAL
{
    [TrackChanges]
    public class AdminBruker
    {
        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
    }


    public class BrukerContext : TrackerContext
    {
        public BrukerContext() : base("name=Brukere")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<AdminBruker> AdminBruker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}