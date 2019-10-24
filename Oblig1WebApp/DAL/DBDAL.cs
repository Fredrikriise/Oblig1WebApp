using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace DAL
{
    public class DBDAL : DAL.IRepository
    {
        // Metoder for Bestilling
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        // Metoder for Avganger
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        // Metoder for visAvganger
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
                    sone = a.Sone,
                    pris = a.Pris
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
                    sone = enAvgang.Sone,
                    pris = enAvgang.Pris
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
                    endreObjekt.Sone = innAvgang.sone;
                    endreObjekt.Pris = innAvgang.pris;
                    db.SaveChanges();
                }
                catch (Exception innsettingsFeil)
                {
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
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
                    nyAvgang.Sone = innAvgang.sone;
                    nyAvgang.Pris = innAvgang.pris;

                    db.visAvganger.Add(nyAvgang);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        // Metoder for Alleavgangstid
        public List<alleavgangstid> alleAlleavgangstid()
        {
            using (var db = new AvgangContext())
            {
                List<alleavgangstid> alleAvganger = db.alleavgangstider.Select(a => new alleavgangstid
                {
                    id = a.Id,
                    avgangstid = a.Avgangstid,
                    avgangstidRetur = a.AvgangstidRetur
                }).ToList();
                return alleAvganger;
            }
        }

        public alleavgangstid hentAlleavgangstider(int id)
        {
            using (var db = new AvgangContext())
            {
                alleavgangstider enAvgang = db.alleavgangstider.Find(id);
                var hentetAvgang = new alleavgangstid()
                {
                    id = enAvgang.Id,
                    avgangstid = enAvgang.Avgangstid,
                    avgangstidRetur = enAvgang.AvgangstidRetur
                };
                return hentetAvgang;
            }
        }

        public bool endreAlleavgangstider(alleavgangstid innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var endreObjekt = db.alleavgangstider.Find(innAvgang.id);
                    endreObjekt.Id = innAvgang.id;
                    endreObjekt.Avgangstid = innAvgang.avgangstid;
                    endreObjekt.AvgangstidRetur = innAvgang.avgangstidRetur;
                    db.SaveChanges();
                }
                catch (Exception innsettingsFeil)
                {
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
                return true;
            }
        }

        public bool lagrealleavgangstid(alleavgangstid innAvgang)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var nyAvgang = new alleavgangstider();
                    nyAvgang.Avgangstid = innAvgang.avgangstid;
                    nyAvgang.AvgangstidRetur = innAvgang.avgangstidRetur;

                    db.alleavgangstider.Add(nyAvgang);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        public bool slettalleavgangstid(int id)
        {
            using (var db = new AvgangContext())
            {
                try
                {
                    var slettObjekt = db.alleavgangstider.Find(id);
                    db.alleavgangstider.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        // Metoder for Betaling
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
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        // Metoder for Bruker
        public List<adminBruker> alleBrukere()
        {
            using (var db = new BrukerContext())
            {
                List<adminBruker> alleBrukere = db.AdminBruker.Select(b => new adminBruker
                {
                    brukernavn = b.Brukernavn
                }).ToList();
                return alleBrukere;
            }
        }

        public bool lagreBruker(adminBruker innBruker)
        {
            using (var db = new BrukerContext())
            {
                try
                {
                    var nyBruker = new AdminBruker();
                    byte[] salt = lagSalt();
                    byte[] hash = lagHash(innBruker.passord, salt);
                    nyBruker.Brukernavn = innBruker.brukernavn;
                    nyBruker.Passord = hash;
                    nyBruker.Salt = salt;
                    db.AdminBruker.Add(nyBruker);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception innsettingsFeil)
                {
                    LogDbErrors(innsettingsFeil.GetBaseException().Message.ToString());
                    return false;
                }
            }
        }

        public static byte[] lagHash(string innPassord, byte[] innSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(innPassord, innSalt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }

        public static byte[] lagSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        public bool bruker_i_db(adminBruker innBruker)
        {
            using (var db = new BrukerContext())
            {
                AdminBruker funnetBruker = db.AdminBruker.FirstOrDefault(b => b.Brukernavn == innBruker.brukernavn);
                if (funnetBruker != null)
                {
                    byte[] passordForTest = lagHash(innBruker.passord, funnetBruker.Salt);
                    bool riktigBruker = funnetBruker.Passord.SequenceEqual(passordForTest);
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }

        //Metode for filskriving
        public void LogDbErrors(string feilMelding)
        {
            FileStream outputFileStream = new FileStream(@"C:\Users\Fredrik\source\repos\Oblig1WebApp\Oblig1WebApp\Oblig1WebApp\Error.txt", FileMode.Append, FileAccess.Write);

            StreamWriter error = new StreamWriter(outputFileStream);
            string innSetting = "";
            innSetting += feilMelding + " " + DateTime.Now;
            error.WriteLine(innSetting);
            error.Close();
        }

    }
}