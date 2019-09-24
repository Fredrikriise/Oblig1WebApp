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
                List<Bestilling> alleBestillinger = db.Bestillinger.Select(b => new Bestilling
                {
                    id = b.Id,
                    fraLokasjon = b.FraLokasjon,
                    tilLokasjon = b.TilLokasjon,
                    billettType = b.BillettType,
                    utreiseDato = b.UtreiseDato,
                    utreiseTid = b.UtreiseTid,
                    returDato = b.ReturDato,
                    returTid = b.ReturTid,
                    voksen = b.Voksen,
                    barn0_5 = b.Barn0_5,
                    student = b.Student,
                    honnør = b.Honnør,
                    vernepliktig = b.Vernepliktig,
                    barn6_17 = b.Barn6_17,
                    barnevogn = b.Barnevogn,
                    sykkel = b.Sykkel,
                    hundover_40cm = b.Hundover_40cm,
                    kjaeledyrunder_40cm = b.Kjaeledyrunder_40cm
                }).ToList();

                return alleBestillinger;
            }
        }

        public bool lagreBestilling(Bestilling innBestilling)
        {
            using (var db = new BestillingContext())
            {
                try
                {
                    var nyBestilling = new Bestillinger();
                    nyBestilling.Id = innBestilling.id;
                    nyBestilling.FraLokasjon = innBestilling.fraLokasjon;
                    nyBestilling.TilLokasjon = innBestilling.tilLokasjon;
                    nyBestilling.BillettType = innBestilling.billettType;
                    nyBestilling.UtreiseDato = innBestilling.utreiseDato;
                    nyBestilling.UtreiseTid = innBestilling.utreiseTid;
                    nyBestilling.ReturDato = innBestilling.returDato;
                    nyBestilling.ReturTid = innBestilling.returTid;
                    nyBestilling.Voksen = innBestilling.voksen;
                    nyBestilling.Barn0_5 = innBestilling.barn0_5;
                    nyBestilling.Student = innBestilling.student;
                    nyBestilling.Honnør = innBestilling.honnør;
                    nyBestilling.Vernepliktig = innBestilling.vernepliktig;
                    nyBestilling.Barn6_17 = innBestilling.barn6_17;
                    nyBestilling.Barnevogn = innBestilling.barnevogn;
                    nyBestilling.Sykkel = innBestilling.sykkel;
                    nyBestilling.Hundover_40cm = innBestilling.hundover_40cm;
                    nyBestilling.Kjaeledyrunder_40cm = innBestilling.kjaeledyrunder_40cm;

                    db.Bestillinger.Add(nyBestilling);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved insetting av data i databasen", innsettingsFeil);
                }
            }
        }

        public List<Avgang> alleAvganger()
        {
            using (var db = new AvgangContext())
            {
                List<Avgang> alleAvganger = db.Avganger.Select(a => new Avgang
                {
                    id = a.Id,
                    forsteAvgang = a.ForsteAvgang,
                    sisteAvgang = a.SisteAvgang,
                    reiseTid = a.ReiseTid,
                    spor = a.Spor,
                    togNummer = a.TogNummer,
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
                    return false;
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

        public bool endreAvgang(Avgang innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var endreObjekt = db.Avganger.Find(innAvgang.id);
                                        endreObjekt.Id = innAvgang.id;
                    endreObjekt.ForsteAvgang = innAvgang.forsteAvgang;
                    endreObjekt.SisteAvgang = innAvgang.sisteAvgang;
                    endreObjekt.ReiseTid = innAvgang.reiseTid;
                    endreObjekt.Spor = innAvgang.spor;
                    endreObjekt.TogNummer = innAvgang.togNummer;
                    db.SaveChanges();
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved insetting av data i databasen", innsettingsFeil);
                }
                return true;
            }
        }

        public Avgang hentAvgang(int id)
        {
            using (var db = new AvgangContext())
            {
                Avganger enAvgang = db.Avganger.Find(id);
                var hentetAvgang = new Avgang()
                {
                    id = enAvgang.Id,
                    forsteAvgang = enAvgang.ForsteAvgang,
                    sisteAvgang = enAvgang.SisteAvgang,
                    reiseTid = enAvgang.ReiseTid,
                    spor = enAvgang.Spor,
                    togNummer = enAvgang.TogNummer
                };
                return hentetAvgang;
            }
        }

        public bool slettAvgang(int id)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var slettObjekt = db.Avganger.Find(id);
                    db.Avganger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved insetting av data i databasen", innsettingsFeil);
                }
            }

        }
    }
}