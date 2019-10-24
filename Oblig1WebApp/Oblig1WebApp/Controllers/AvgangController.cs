using BLL;
using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Oblig1WebApp.Controllers
{
    public class AvgangController : Controller
    {
        private ILogikk _avgangBBL;

        public AvgangController()
        {
            _avgangBBL = new DBBLL();
        }

        public AvgangController(ILogikk stub)
        {
            _avgangBBL = stub;
        }

        // Metoder for Avganger
        public string hentAlleAvganger()
        {
            List<Avgang> alleAvganger = _avgangBBL.alleAvganger();

            var alleStrekninger = new List<jsAvgang>();
            foreach (Avgang a in alleAvganger)
            {
                var enAvgang = new jsAvgang();
                enAvgang.id = a.id;
                enAvgang._forsteAvgang = a._forsteAvgang;
                enAvgang._sisteAvgang = a._sisteAvgang;
                alleStrekninger.Add(enAvgang);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(alleAvganger);
            return json;
        }

        public string hentAvgangInfo(int id)
        {
            Avgang enAvgang = _avgangBBL.hentAvgang(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registerAvgang(Avgang innAvgang)
        {
            _avgangBBL.lagreAvgang(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }

        // Metoder for visAvganger
        public string hentAlleVisAvganger()
        {
            List<visAvgang> alleAvganger = _avgangBBL.alleVisAvganger();

            var alleStrekninger = new List<jsVisAvgang>();
            foreach (visAvgang a in alleAvganger)
            {
                var enAvgang = new jsVisAvgang();
                enAvgang.id = a.id;
                enAvgang.forsteAvgang = a.forsteAvgang;
                enAvgang.sisteAvgang = a.sisteAvgang;
                enAvgang.reiseTid = a.reiseTid;
                enAvgang.spor = a.spor;
                enAvgang.togNummer = a.togNummer;
                enAvgang.sone = a.sone;
                enAvgang.pris = a.pris;
                alleStrekninger.Add(enAvgang);
            }

            var test = Session["fraLokasjon"].ToString();
            var test2 = Session["tilLokasjon"].ToString();
            List<visAvgang> alleAvgangerNy = new List<visAvgang>(alleAvganger.FindAll(item => (item.forsteAvgang == test) && (item.sisteAvgang == test2)));
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(alleAvgangerNy);
            return json;
        }

        public string hentVisAvgangInfo(int id)
        {
            visAvgang enAvgang = _avgangBBL.hentVisAvgang(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registerVisAvgang(visAvgang innAvgang)
        {
            _avgangBBL.lagreVisAvgang(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }


        //Metoder for alleavgangstid
        public string hentAlleavgangstider()
        {
            List<alleavgangstid> alleAvganger = _avgangBBL.alleAlleavgangstid();

            var alleStrekninger = new List<jsAlleavgangstid>();
            foreach (alleavgangstid a in alleAvganger)
            {
                var enAvgang = new jsAlleavgangstid();
                enAvgang.id = a.id;
                enAvgang.avgangstid = a.avgangstid;
                enAvgang.avgangstidRetur = a.avgangstidRetur;
                alleStrekninger.Add(enAvgang);
            }

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(alleAvganger);
            return json;
        }

        public string hentAlleavgangstid(int id)
        {
            alleavgangstid enAvgang = _avgangBBL.hentAlleavgangstider(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registrerAlleavgangstid(alleavgangstid innAvgang)
        {
            _avgangBBL.lagrealleavgangstid(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }
    }
}
