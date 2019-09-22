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

        public List<Avgang> alleAvganger()
        {
            using (var db = new AvgangContext())
            {
                List<Avgang> alleAvganger = db.Avganger.Select(k => new Avgang
                {
                    id = k.Id,
                    forsteAvgang = k.ForsteAvgang,
                    sisteAvgang = k.SisteAvgang,
                    reiseTid = k.ReiseTid,
                    spor = k.Spor,
                    togNummer = k.TogNummer,
                }).ToList();

                return alleAvganger;
            }
        }

        public bool lagreAvgang(Avgang innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var nyAvgang = new Avganger();
                    nyAvgang.ForsteAvgang = innAvgang.forsteAvgang;
                    nyAvgang.SisteAvgang = innAvgang.sisteAvgang;
                    nyAvgang.ReiseTid = innAvgang.reiseTid;
                    nyAvgang.Spor = innAvgang.spor;
                    nyAvgang.TogNummer = innAvgang.togNummer;

                    db.Avganger.Add(nyAvgang);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    throw new Exception(
                        "Feil ved insetting av data i databasen", innsettingsFeil);
                }
            }
        }

        public Avgang hentAvgang(string forsteAvgang, string sisteAvgang)
        {
            using (var db = new AvgangContext())
            {
                Avganger enAvgang = db.Avganger.Find(forsteAvgang, sisteAvgang);
                var hentetAvgang = new Avgang()
                {
                    forsteAvgang = enAvgang.ForsteAvgang,
                    sisteAvgang = enAvgang.SisteAvgang,
                    reiseTid = enAvgang.ReiseTid,
                    spor = enAvgang.Spor,
                    togNummer = enAvgang.TogNummer,
                };
                return hentetAvgang;
            }
        }
    }
}