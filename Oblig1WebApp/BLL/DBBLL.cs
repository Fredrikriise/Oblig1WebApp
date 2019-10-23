using Oblig1WebApp.DAL;
using Oblig1WebApp.Models;
using System.Collections.Generic;

namespace Oblig1WebApp.BLL
{
    public class DBBLL : BLL.ILogikk
    {
        // Enhetstesting
        private IRepository _repository;

        public DBBLL()
        {
            _repository = new DBDAL();
        }

        public DBBLL(IRepository stub)
        {
            _repository = stub;
        }

        // Bestilling
        public List<Bestilling> alleBestillinger()
        {
            List<Bestilling> alleBestillinger = _repository.alleBestillinger();
            return alleBestillinger;
        }

        public Bestilling hentBestilling(int id)
        {
            return _repository.hentBestilling(id);
        }

        public bool lagreBestilling(Bestilling innBestilling)
        {
            return _repository.lagreBestilling(innBestilling);
        }

        // Avganger
        public List<Avgang> alleAvganger()
        {
            List<Avgang> alleAvganger = _repository.alleAvganger();
            return alleAvganger;
        }

        public Avgang hentAvgang(int id)
        {
            return _repository.hentAvgang(id);
        }

        public bool endreAvgang(Avgang innAvgang)
        {
            return _repository.endreAvgang(innAvgang);
        }

        public bool lagreAvgang(Avgang innAvgang)
        {
            return _repository.lagreAvgang(innAvgang);
        }

        public bool slettAvgang(int id)
        {
            return _repository.slettAvgang(id);
        }

        // visAvganger
        public List<visAvgang> alleVisAvganger()
        {
            List<visAvgang> alleVisAvganger = _repository.alleVisAvganger();
            return alleVisAvganger;
        }

        public visAvgang hentVisAvgang(int id)
        {
            return _repository.hentVisAvgang(id);
        }

        public bool endreVisAvgang(visAvgang innAvgang)
        {
            return _repository.endreVisAvgang(innAvgang);
        }

        public bool lagreVisAvgang(visAvgang innAvgang)
        {
            return _repository.lagreVisAvgang(innAvgang);
        }

        public bool slettVisAvgang(int id)
        {
            return _repository.slettVisAvgang(id);
        }

        //Alleavgangstid
        public List<alleavgangstid> alleAlleavgangstid()
        {
            List<alleavgangstid> alleAlleavgangstid = _repository.alleAlleavgangstid();
            return alleAlleavgangstid;
        }

        public alleavgangstid hentAlleavgangstider(int id)
        {
            return _repository.hentAlleavgangstider(id);
        }

        public bool endreAlleavgangstider(alleavgangstid innAvgang)
        {
            return _repository.endreAlleavgangstider(innAvgang);
        }

        public bool lagrealleavgangstid(alleavgangstid innAvgang)
        {
            return _repository.lagrealleavgangstid(innAvgang);
        }

        public bool slettalleavgangstid(int id)
        {
            return _repository.slettalleavgangstid(id);
        }

        // Betaling
        public List<Betaling> alleBetalinger()
        {
            List<Betaling> alleBetalinger = _repository.alleBetalinger();
            return alleBetalinger;
        }

        public Betaling hentBetaling(int id)
        {
            return _repository.hentBetaling(id);
        }

        public bool lagreBetaling(Betaling innBetaling)
        {
            return _repository.lagreBetaling(innBetaling);
        }

        // Bruker
        public List<adminBruker> alleBrukere()
        {
            List<adminBruker> alleBrukere = _repository.alleBrukere();
            return alleBrukere;
        }

        public bool lagreBruker(adminBruker innBruker)
        {
            return _repository.lagreBruker(innBruker);
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
            return _repository.bruker_i_db(innBruker);
        }
    }
}