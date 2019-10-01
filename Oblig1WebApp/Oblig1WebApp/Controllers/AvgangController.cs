using Oblig1WebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Oblig1WebApp.Controllers
{
    public class AvgangController : Controller
    {
        // Metoder for Avganger
        public string hentAlleAvganger()
        {
            var db = new DBContext();
            List<Avgang> alleAvganger = db.alleAvganger();

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
            var db = new DBContext();
            Avgang enAvgang = db.hentAvgang(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registerAvgang(Avgang innAvgang)
        {
            var db = new DBContext();
            db.lagreAvgang(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }


        // Metoder for visAvganger
        public string hentAlleVisAvganger()
        {
            var db = new DBContext();
            List<visAvgang> alleAvganger = db.alleVisAvganger();

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
                enAvgang.avgangstid = a.avgangstid;
                alleStrekninger.Add(enAvgang);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(alleAvganger);
            return json;
        }

        public string hentVisAvgangInfo(int id)
        {
            var db = new DBContext();
            visAvgang enAvgang = db.hentVisAvgang(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registerVisAvgang(visAvgang innAvgang)
        {
            var db = new DBContext();
            db.lagreVisAvgang(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }
    }
}