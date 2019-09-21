using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oblig1WebApp.Models;

namespace Oblig1WebApp
{
    public class DBContext
    {
        public List<Bestilling> alleBestillinger()
        {
            using (var db = new BestillingContext())
            {
                List<Bestilling> alleBestillinger = db.Bestillinger.Select(k => new Bestilling
                {
                    id = k.Id,
                    fraLokasjon = k.FraLokasjon,
                    tilLokasjon = k.TilLokasjon,
                    bilettType = k.BilettType,
                    reisende = k.Reisende,
                    reisendeAntall = k.AntallReisende,
                    spesialBehov = k.SpesialBehov,
                    kundeId = k.Kunder.Id
                }).ToList();

                return alleBestillinger;
            }
        }
    }
}