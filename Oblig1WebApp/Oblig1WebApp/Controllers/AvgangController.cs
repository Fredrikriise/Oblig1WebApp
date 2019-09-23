using Oblig1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Oblig1WebApp.Controllers
{
    public class AvgangController : Controller
    {
        public ActionResult DynamikkView()
        {
            return View();
        }

        public string hentAlleAvganger()
        {
            var db = new DBContext();
            List<Avgang> alleAvganger = db.alleAvganger();

            var alleStrekninger = new List<jsAvgang>();
            foreach (Avgang a in alleAvganger)
            {
                var enAvgang = new jsAvgang();
                enAvgang.id = a.id;
                enAvgang.avgang = a.forsteAvgang + " " + a.sisteAvgang;
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
    }
}