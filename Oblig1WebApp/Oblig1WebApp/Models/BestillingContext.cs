using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Oblig1WebApp.Models
{
    public class Bestillinger
    {
        public int Id { get; set; }
        public string FraLokasjon { get; set; }
        public string TilLokasjon { get; set; }
        public string BillettType { get; set; }

        public DateTime? UtreiseDato { get; set; }
        public string UtreiseTid { get; set; }
        public DateTime? ReturDato { get; set; }
        public string ReturTid { get; set; }

        public int Voksen { get; set; }
        public int Barn0_5 { get; set; }
        public int Student { get; set; }
        public int Honnoer { get; set; }
        public int Vernepliktig { get; set; }
        public int Barn6_17 { get; set; }
        public bool Barnevogn { get; set; }
        public bool Sykkel { get; set; }
        public bool Hundover_40cm { get; set; }
        public bool Kjaeledyrunder_40cm { get; set; }
    }
    /*
        public class Kunder
        {
            public int Id { get; set; }
            public string Fornavn { get; set; }
            public string Etternavn { get; set; }
            public string Adresse { get; set; }
            public virtual Poststeder Poststeder { get; set; }
            public virtual Bestillinger Bestillinger { get; set; }
        }

        public class Poststeder
        {
            [Key]
            public string Postnr { get; set; }
            public string Poststed { get; set; }
            public virtual List<Kunder> Kunder { get; set; }
        }
            */

    public class BestillingContext : DbContext
    {
        public BestillingContext() : base("name=Bestillinger")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Bestillinger> Bestillinger { get; set; }
        /*
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}