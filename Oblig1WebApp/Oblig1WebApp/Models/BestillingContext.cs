using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{
    public class Bestillinger
    {
        public int Id { get; set; }
        public string FraLokasjon { get; set; }
        public string TilLokasjon { get; set; }
        public string BilettType { get; set; }
        public string Reisende { get; set; }
        public int AntallReisende { get; set; }
        public string SpesialBehov { get; set; }
        public int KundeId { get; set; }
        public virtual Kunder Kunder { get; set; }
        public object reiseFra { get; internal set; }
    }

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

    public class BestillingContext : DbContext
    {
        public BestillingContext() : base("name=Bestillinger")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Bestillinger> Bestillinger { get; set; }
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}