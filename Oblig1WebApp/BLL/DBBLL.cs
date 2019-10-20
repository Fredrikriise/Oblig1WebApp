using Oblig1WebApp.DAL;
using Oblig1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Oblig1WebApp.BLL
{
    public class DBBLL
    {
        // Bestilling
        public List<Bestilling> alleBestillinger()
        {
            var DBDAL = new DBDAL();
            return DBDAL.alleBestillinger();
        }

        public Bestilling hentBestilling(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.hentBestilling(id);
        }

        public bool lagreBestilling(Bestilling innBestilling)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagreBestilling(innBestilling);
        }
        public bool slettBestilling(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.slettBestilling(id);
        }

        // Avganger
        public List<Avgang> alleAvganger()
        {
            var DBDAL = new DBDAL();
            return DBDAL.alleAvganger();
        }

        public Avgang hentAvgang(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.hentAvgang(id);
        }

        public bool endreAvgang(Avgang innAvgang)
        {
            var DBDAL = new DBDAL();
            return DBDAL.endreAvgang(innAvgang);
        }

        public bool lagreAvgang(Avgang innAvgang)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagreAvgang(innAvgang);
        }

        public bool slettAvgang(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.slettAvgang(id);
        }

        // visAvganger
        public List<visAvgang> alleVisAvganger()
        {
            var DBDAL = new DBDAL();
            return DBDAL.alleVisAvganger();
        }

        public visAvgang hentVisAvgang(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.hentVisAvgang(id);
        }

        public bool endreVisAvgang(visAvgang innAvgang)
        {
            var DBDAL = new DBDAL();
            return DBDAL.endreVisAvgang(innAvgang);
        }

        public bool lagreVisAvgang(visAvgang innAvgang)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagreVisAvgang(innAvgang);
        }

        public bool slettVisAvgang(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.slettVisAvgang(id);
        }

        //Alleavgangstid
        public List<alleavgangstid> alleAlleavgangstid()
        {
            var DBDAL = new DBDAL();
            return DBDAL.alleAlleavgangstid();
        }

        public alleavgangstid hentAlleavgangstider(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.hentAlleavgangstider(id);
        }

        public bool endreAlleavgangstider(alleavgangstid innAvgang)
        {
            var DBDAL = new DBDAL();
            return DBDAL.endreAlleavgangstider(innAvgang);
        }

        public bool lagrealleavgangstid(alleavgangstid innAvgang)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagrealleavgangstid(innAvgang);
        }

        public bool slettalleavgangstid(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.slettalleavgangstid(id);
        }

        // Betaling
        public List<Betaling> alleBetalinger()
        {
            var DBDAL = new DBDAL();
            return DBDAL.alleBetalinger();
        }

        public Betaling hentBetaling(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.hentBetaling(id);
        }

        public bool endreBetaling(Betaling innBetaling)
        {
            var DBDAL = new DBDAL();
            return DBDAL.endreBetaling(innBetaling);
        }

        public bool lagreBetaling(Betaling innBetaling)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagreBetaling(innBetaling);
        }

        public bool slettBetaling(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.slettBetaling(id);
        }


        //Metoder for bruker
        public bool lagreBruker(adminBruker innBruker)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagreBruker(innBruker);
        }

        private static byte[] lagHash(string innPassord, byte[] innSalt)
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagHash(innPassord, innSalt);
        }

        private static byte[] lagSalt()
        {
            var DBDAL = new DBDAL();
            return DBDAL.lagSalt();
        }

        public bool bruker_i_db(adminBruker innBruker)
        {
            var DBDAL = new DBDAL();
            return DBDAL.bruker_i_db(innBruker);
        }

        public List<adminBruker> alleBrukere()
        {
            var DBDAL = new DBDAL();
            return DBDAL.alleBrukere();
        }

        public bool slettBruker(int id)
        {
            var DBDAL = new DBDAL();
            return DBDAL.slettBruker(id);
        }
    }
}