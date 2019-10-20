using Oblig1WebApp.Models;
using Oblig1WebApp.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Oblig1WebApp.Controllers
{
    public class AvgangController : Controller
    {
        // Metoder for Avganger
        public string hentAlleAvganger()
        {
            var db = new DBDAL();
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
            var db = new DBDAL();
            Avgang enAvgang = db.hentAvgang(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registerAvgang(Avgang innAvgang)
        {
            var db = new DBDAL();
            db.lagreAvgang(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }

        // Metoder for visAvganger
        public string hentAlleVisAvganger()
        {
            var db = new DBDAL();
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
            var db = new DBDAL();
            visAvgang enAvgang = db.hentVisAvgang(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registerVisAvgang(visAvgang innAvgang)
        {
            var db = new DBDAL();
            db.lagreVisAvgang(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }


        //Metoder for alleavgangstid
        public string hentAlleavgangstider()
        {
            var db = new DBDAL();
            List<alleavgangstid> alleAvganger = db.alleAlleavgangstid();

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
            var db = new DBDAL();
            alleavgangstid enAvgang = db.hentAlleavgangstider(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enAvgang);
            return json;
        }

        public string registrerAlleavgangstid(alleavgangstid innAvgang)
        {
            var db = new DBDAL();
            db.lagrealleavgangstid(innAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }
    }
}
