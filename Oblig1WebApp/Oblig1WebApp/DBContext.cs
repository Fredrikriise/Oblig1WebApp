using Oblig1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oblig1WebApp
{
    public class DBContext
    {
        // Bestilling
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
                    avgangstid = b.Avgangstid,
                    returDato = b.ReturDato,
                    avgangstidRetur = b.AvgangstidRetur,
                    voksen = b.Voksen,
                    barn0_5 = b.Barn0_5,
                    student = b.Student,
                    honnoer = b.Honnoer,
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

        public Bestilling hentBestilling(int id)
        {
            using (var db = new BestillingContext())
            {
                Bestillinger enBestilling = db.Bestillinger.Find(id);
                var hentetBestilling = new Bestilling()
                {
                    id = enBestilling.Id,
                    fraLokasjon = enBestilling.FraLokasjon,
                    tilLokasjon = enBestilling.TilLokasjon,
                    billettType = enBestilling.BillettType,
                    utreiseDato = enBestilling.UtreiseDato,
                    avgangstid = enBestilling.Avgangstid,
                    returDato = enBestilling.ReturDato,
                    avgangstidRetur = enBestilling.AvgangstidRetur,
                    voksen = enBestilling.Voksen,
                    barn0_5 = enBestilling.Barn0_5,
                    student = enBestilling.Student,
                    honnoer = enBestilling.Honnoer,
                    vernepliktig = enBestilling.Vernepliktig,
                    barn6_17 = enBestilling.Barn6_17,
                    barnevogn = enBestilling.Barnevogn,
                    sykkel = enBestilling.Sykkel,
                    hundover_40cm = enBestilling.Hundover_40cm,
                    kjaeledyrunder_40cm = enBestilling.Kjaeledyrunder_40cm,
                };
                return hentetBestilling;
            }
        }

        public bool lagreBestilling(Bestilling innBestilling)
        {
            using (var db = new BestillingContext())
            {
                try
                {
                    var nyBestilling = new Bestillinger();
                    nyBestilling.FraLokasjon = innBestilling.fraLokasjon;
                    nyBestilling.TilLokasjon = innBestilling.tilLokasjon;
                    nyBestilling.BillettType = innBestilling.billettType;
                    nyBestilling.UtreiseDato = innBestilling.utreiseDato;
                    nyBestilling.Avgangstid = innBestilling.avgangstid;
                    nyBestilling.ReturDato = innBestilling.returDato;
                    nyBestilling.AvgangstidRetur = innBestilling.avgangstidRetur;

                    if (innBestilling.voksen == 0)
                    {
                        innBestilling.voksen = null;
                    }
                    nyBestilling.Voksen = innBestilling.voksen;

                    if (innBestilling.barn0_5 == 0)
                    {
                        innBestilling.barn0_5 = null;
                    }
                    nyBestilling.Barn0_5 = innBestilling.barn0_5;

                    if (innBestilling.student == 0)
                    {
                        innBestilling.student = null;
                    }
                    nyBestilling.Student = innBestilling.student;

                    if (innBestilling.honnoer == 0)
                    {
                        innBestilling.honnoer = null;
                    }
                    nyBestilling.Honnoer = innBestilling.honnoer;

                    if (innBestilling.vernepliktig == 0)
                    {
                        innBestilling.vernepliktig = null;
                    }
                    nyBestilling.Vernepliktig = innBestilling.vernepliktig;

                    if (innBestilling.barn6_17 == 0)
                    {
                        innBestilling.barn6_17 = null;
                    }
                    nyBestilling.Barn6_17 = innBestilling.barn6_17;

                    if (innBestilling.barnevogn == 0)
                    {
                        innBestilling.barnevogn = null;
                    }
                    nyBestilling.Barnevogn = innBestilling.barnevogn;

                    if (innBestilling.sykkel == 0)
                    {
                        innBestilling.sykkel = null;
                    }
                    nyBestilling.Sykkel = innBestilling.sykkel;

                    if (innBestilling.hundover_40cm == 0)
                    {
                        innBestilling.hundover_40cm = null;
                    }
                    nyBestilling.Hundover_40cm = innBestilling.hundover_40cm;

                    if (innBestilling.kjaeledyrunder_40cm == 0)
                    {
                        innBestilling.kjaeledyrunder_40cm = null;
                    }
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

        public bool slettBestilling(int id)
        {
            using (var db = new BestillingContext())
            {
                try
                {
                    var slettObjekt = db.Bestillinger.Find(id);
                    db.Bestillinger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved sletting av data i databasen", innsettingsFeil);
                }
            }

        }

        // Avganger
        public List<Avgang> alleAvganger()
        {
            using (var db = new AvgangContext())
            {
                List<Avgang> alleAvganger = db.Avganger.Select(a => new Avgang
                {
                    id = a.Id,
                    _forsteAvgang = a._ForsteAvgang,
                    _sisteAvgang = a._SisteAvgang
                }).ToList();

                return alleAvganger;
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
                    _forsteAvgang = enAvgang._ForsteAvgang,
                    _sisteAvgang = enAvgang._SisteAvgang
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
                    endreObjekt._ForsteAvgang = innAvgang._forsteAvgang;
                    endreObjekt._SisteAvgang = innAvgang._sisteAvgang;
                    db.SaveChanges();
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved endring av data i databasen", innsettingsFeil);
                }
                return true;
            }
        }

        public bool lagreAvgang(Avgang innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var nyAvgang = new Avganger();
                    nyAvgang._ForsteAvgang = innAvgang._forsteAvgang;
                    nyAvgang._SisteAvgang = innAvgang._sisteAvgang;

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
                        "Feil ved sletting av data i databasen", innsettingsFeil);
                }
            }
        }

        // visAvganger
        public List<visAvgang> alleVisAvganger()
        {
            using (var db = new AvgangContext())
            {
                List<visAvgang> alleAvganger = db.visAvganger.Select(a => new visAvgang
                {
                    id = a.Id,
                    forsteAvgang = a.ForsteAvgang,
                    sisteAvgang = a.SisteAvgang,
                    reiseTid = a.ReiseTid,
                    spor = a.Spor,
                    togNummer = a.TogNummer,
                    avgangstid = a.Avgangstid,
                    avgangstidRetur = a.AvgangstidRetur
                }).ToList();
                return alleAvganger;
            }
        }

        public visAvgang hentVisAvgang(int id)
        {
            using (var db = new AvgangContext())
            {
                visAvganger enAvgang = db.visAvganger.Find(id);
                var hentetAvgang = new visAvgang()
                {
                    id = enAvgang.Id,
                    forsteAvgang = enAvgang.ForsteAvgang,
                    sisteAvgang = enAvgang.SisteAvgang,
                    reiseTid = enAvgang.ReiseTid,
                    spor = enAvgang.Spor,
                    togNummer = enAvgang.TogNummer,
                    avgangstid = enAvgang.Avgangstid,
                    avgangstidRetur = enAvgang.AvgangstidRetur
                };
                return hentetAvgang;
            }
        }

        public bool endreVisAvgang(visAvgang innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var endreObjekt = db.visAvganger.Find(innAvgang.id);
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
                        "Feil ved endring av data i databasen", innsettingsFeil);
                }
                return true;
            }
        }

        public bool lagreVisAvgang(visAvgang innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var nyAvgang = new visAvganger();
                    nyAvgang.ForsteAvgang = innAvgang.forsteAvgang;
                    nyAvgang.SisteAvgang = innAvgang.sisteAvgang;
                    nyAvgang.ReiseTid = innAvgang.reiseTid;
                    nyAvgang.Spor = innAvgang.spor;
                    nyAvgang.TogNummer = innAvgang.togNummer;
                    nyAvgang.Avgangstid = innAvgang.avgangstid;
                    nyAvgang.AvgangstidRetur = innAvgang.avgangstidRetur;

                    db.visAvganger.Add(nyAvgang);
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

        public bool slettVisAvgang(int id)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var slettObjekt = db.visAvganger.Find(id);
                    db.visAvganger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved sletting av data i databasen", innsettingsFeil);
                }
            }
        }

        // Betaling
        public List<Betaling> alleBetalinger()
        {
            using (var db = new BestillingContext())
            {
                List<Betaling> alleBetalinger = db.Betalinger.Select(a => new Betaling
                {
                    id = a.Id,
                    fornavn = a.Fornavn,
                    etternavn = a.Etternavn,
                    email = a.Email,
                    kortnummer = a.Kortnummer,
                    utløpsDato = a.UtløpsDato,
                    CVC = a.CvC
                }).ToList();
                return alleBetalinger;
            }
        }

        public Betaling hentBetaling(int id)
        {
            using (var db = new BestillingContext())
            {
                Betalinger enBetaling = db.Betalinger.Find(id);
                var hentetBetaling = new Betaling()
                {
                    id = enBetaling.Id,
                    fornavn = enBetaling.Fornavn,
                    etternavn = enBetaling.Etternavn,
                    email = enBetaling.Email,
                    kortnummer = enBetaling.Kortnummer,
                    utløpsDato = enBetaling.UtløpsDato,
                    CVC = enBetaling.CvC
                };
                return hentetBetaling;
            }
        }

        public bool endreBetaling(Betaling innBetaling)
        {
            using (var db = new BestillingContext())
            {
                try
                {
                    var endreObjekt = db.Betalinger.Find(innBetaling.id);
                    endreObjekt.Id = innBetaling.id;
                    endreObjekt.Fornavn = innBetaling.fornavn;
                    endreObjekt.Etternavn = innBetaling.etternavn;
                    endreObjekt.Email = innBetaling.email;
                    endreObjekt.Kortnummer = innBetaling.kortnummer;
                    endreObjekt.UtløpsDato = innBetaling.utløpsDato;
                    db.SaveChanges();
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved endring av data i databasen", innsettingsFeil);
                }
                return true;
            }
        }

        public bool lagreBetaling(Betaling innBetaling)
        {
            using (var db = new BestillingContext())
            {
                try
                {
                    var nyBetaling = new Betalinger();
                    nyBetaling.Fornavn = innBetaling.fornavn;
                    nyBetaling.Etternavn = innBetaling.etternavn;
                    nyBetaling.Email = innBetaling.email;
                    nyBetaling.Kortnummer = innBetaling.kortnummer;
                    nyBetaling.UtløpsDato = innBetaling.utløpsDato;
                    nyBetaling.CvC = innBetaling.CVC;

                    db.Betalinger.Add(nyBetaling);
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

        public bool slettBetaling(int id)
        {
            using (var db = new BestillingContext())
            {
                try
                {
                    var slettObjekt = db.Betalinger.Find(id);
                    db.Betalinger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    return false;
                    throw new Exception(
                        "Feil ved sletting av data i databasen", innsettingsFeil);
                }
            }
        }

    }
}