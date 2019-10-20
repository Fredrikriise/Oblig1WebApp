using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Oblig1WebApp.DAL
{
    public class Bestillinger
    {
        public int Id { get; set; }
        public string FraLokasjon { get; set; }
        public string TilLokasjon { get; set; }
        public string BillettType { get; set; }
        public DateTime? UtreiseDato { get; set; }
        public string Avgangstid { get; set; }
        public DateTime? ReturDato { get; set; }
        public string AvgangstidRetur { get; set; }
        public int? Voksen { get; set; }
        public int? Barn0_5 { get; set; }
        public int? Student { get; set; }
        public int? Honnoer { get; set; }
        public int? Vernepliktig { get; set; }
        public int? Barn6_17 { get; set; }
        public int? Barnevogn { get; set; }
        public int? Sykkel { get; set; }
        public int? Hundover_40cm { get; set; }
        public int? Kjaeledyrunder_40cm { get; set; }
    }

    public class Betalinger
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Email { get; set; }
        public string Kortnummer { get; set; }
        public string UtløpsDato { get; set; }
        public string CvC { get; set; }
    }

    public class BestillingContext : DbContext
    {
        public BestillingContext() : base("name=Bestillinger")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Bestillinger> Bestillinger { get; set; }
        public DbSet<Betalinger> Betalinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}