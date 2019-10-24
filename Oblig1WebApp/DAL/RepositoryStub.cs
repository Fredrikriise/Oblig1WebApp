using Model;
using System.Collections.Generic;

namespace DAL
{
    public class RepositoryStub : DAL.IRepository
    {
        // Bestilling
        public List<Bestilling> alleBestillinger()
        {
            var bestillingListe = new List<Bestilling>();
            var bestilling = new Bestilling()
            {
                id = 1,
                fraLokasjon = "Langhus",
                tilLokasjon = "Holmlia",
                billettType = "En vei",
                utreiseDato = null,
                avgangstid = "14:00",
                returDato = null,
                avgangstidRetur = "15:15",
                voksen = 1,
                barn0_5 = 0,
                student = 0,
                honnoer = 0,
                vernepliktig = 0,
                barn6_17 = 0,
                barnevogn = 0,
                sykkel = 0,
                hundover_40cm = 0,
                kjaeledyrunder_40cm = 0
            };
            bestillingListe.Add(bestilling);
            bestillingListe.Add(bestilling);
            bestillingListe.Add(bestilling);
            return bestillingListe;
        }

        public Bestilling hentBestilling(int id)
        {
            if (id == 0)
            {
                var bestilling = new Bestilling();
                bestilling.id = 0;
                return bestilling;
            }
            else
            {
                var bestilling = new Bestilling()
                {
                    id = 1,
                    fraLokasjon = "Langhus",
                    tilLokasjon = "Holmlia",
                    billettType = "En vei",
                    utreiseDato = null,
                    avgangstid = "14:00",
                    returDato = null,
                    avgangstidRetur = "15:15",
                    voksen = 1,
                    barn0_5 = 0,
                    student = 0,
                    honnoer = 0,
                    vernepliktig = 0,
                    barn6_17 = 0,
                    barnevogn = 0,
                    sykkel = 0,
                    hundover_40cm = 0,
                    kjaeledyrunder_40cm = 0
                };
                return bestilling;
            }
        }

        public bool lagreBestilling(Bestilling innBestilling)
        {
            if (innBestilling.fraLokasjon == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Avganger
        public List<Avgang> alleAvganger()
        {
            var avgangListe = new List<Avgang>();
            var avgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };
            avgangListe.Add(avgang);
            avgangListe.Add(avgang);
            avgangListe.Add(avgang);
            return avgangListe;
        }

        public Avgang hentAvgang(int id)
        {
            if (id == 0)
            {
                var avgang = new Avgang();
                avgang.id = 0;
                return avgang;
            }
            else
            {
                var avgang = new Avgang()
                {
                    id = 1,
                    _forsteAvgang = "Langhus",
                    _sisteAvgang = "Holmlia"
                };
                return avgang;
            }
        }

        public bool endreAvgang(Avgang innAvgang)
        {
            if (innAvgang.id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool lagreAvgang(Avgang innAvgang)
        {
            if (innAvgang._forsteAvgang == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool slettAvgang(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // visAvganger
        public List<visAvgang> alleVisAvganger()
        {
            var visAvgangListe = new List<visAvgang>();
            var visAvgang = new visAvgang()
            {
                id = 1,
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };
            visAvgangListe.Add(visAvgang);
            visAvgangListe.Add(visAvgang);
            visAvgangListe.Add(visAvgang);
            return visAvgangListe;
        }

        public visAvgang hentVisAvgang(int id)
        {
            if (id == 0)
            {
                var visAvgang = new visAvgang();
                visAvgang.id = 0;
                return visAvgang;
            }
            else
            {
                var visAvgang = new visAvgang()
                {
                    id = 1,
                    forsteAvgang = "Langhus",
                    sisteAvgang = "Holmlia",
                    reiseTid = "15 minutter",
                    spor = "Spor 1",
                    togNummer = "L22",
                    sone = 1,
                    pris = 35
                };
                return visAvgang;
            }
        }

        public bool endreVisAvgang(visAvgang innAvgang)
        {
            if (innAvgang.id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool lagreVisAvgang(visAvgang innAvgang)
        {
            if (innAvgang.forsteAvgang == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool slettVisAvgang(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Alleavgangstid
        public List<alleavgangstid> alleAlleavgangstid()
        {
            var alleavgangstidListe = new List<alleavgangstid>();
            var alleavgangstid = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };
            alleavgangstidListe.Add(alleavgangstid);
            alleavgangstidListe.Add(alleavgangstid);
            alleavgangstidListe.Add(alleavgangstid);
            return alleavgangstidListe;
        }

        public alleavgangstid hentAlleavgangstider(int id)
        {
            if (id == 0)
            {
                var alleavgangstid = new alleavgangstid();
                alleavgangstid.id = 0;
                return alleavgangstid;
            }
            else
            {
                var alleavgangstid = new alleavgangstid()
                {
                    id = 1,
                    avgangstid = "14:00",
                    avgangstidRetur = "15:15"
                };
                return alleavgangstid;
            }
        }

        public bool endreAlleavgangstider(alleavgangstid innAvgang)
        {
            if (innAvgang.id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool lagrealleavgangstid(alleavgangstid innAvgang)
        {
            if (innAvgang.id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool slettalleavgangstid(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Betaling
        public List<Betaling> alleBetalinger()
        {
            var betalingListe = new List<Betaling>();
            var betaling = new Betaling()
            {
                id = 1,
                fornavn = "Frank",
                etternavn = "Loke",
                email = "floke@hotmail.com",
                kortnummer = "764637872354",
                utløpsDato = "05/33",
                CVC = "654"
            };
            betalingListe.Add(betaling);
            betalingListe.Add(betaling);
            betalingListe.Add(betaling);
            return betalingListe;
        }

        public Betaling hentBetaling(int id)
        {
            if (id == 0)
            {
                var betaling = new Betaling();
                betaling.id = 0;
                return betaling;
            }
            else
            {
                var betaling = new Betaling()
                {
                    id = 1,
                    fornavn = "Frank",
                    etternavn = "Loke",
                    email = "floke@hotmail.com",
                    kortnummer = "764637872354",
                    utløpsDato = "05/33",
                    CVC = "654"
                };
                return betaling;
            }
        }

        public bool lagreBetaling(Betaling innBetaling)
        {
            if (innBetaling.id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        // Bruker
        public List<adminBruker> alleBrukere()
        {
            var brukerListe = new List<adminBruker>();
            var bruker = new adminBruker()
            {
                brukernavn = "johnny",
                passord = "hfshf"
            };
            brukerListe.Add(bruker);
            brukerListe.Add(bruker);
            brukerListe.Add(bruker);
            return brukerListe;
        }

        public bool lagreBruker(adminBruker innBruker)
        {
            if (innBruker.brukernavn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool bruker_i_db(adminBruker innBruker)
        {
            if (innBruker.brukernavn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
