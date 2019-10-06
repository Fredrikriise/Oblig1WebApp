using Oblig1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Oblig1WebApp.Controllers
{
    public class BestillingController : Controller
    {
        // Metoder for Bestilling
        public ActionResult Bestilling()
        {
            return View();
        }

        public ActionResult listBestillinger()
        {
            var db = new DBContext();
            List<Bestilling> alleBestillinger = db.alleBestillinger();
            return View(alleBestillinger);
        }


        [HttpPost]
        public ActionResult regBestilling(Bestilling innBestilling)
        {
            var db = new DBContext();

            var idFra = Int32.Parse(innBestilling.fraLokasjon);
            visAvgang enAvgangFra = db.hentVisAvgang(idFra);
            Session["fraLokasjon"] = enAvgangFra.forsteAvgang;

            var idTil = Int32.Parse(innBestilling.tilLokasjon);
            visAvgang enAvgangTil = db.hentVisAvgang(idTil);
            Session["tilLokasjon"] = enAvgangTil.sisteAvgang;

            Session["billettType"] = innBestilling.billettType;
            Session["utreiseDato"] = innBestilling.utreiseDato;
            //Session["utreiseTid"] = innBestilling.utreiseTid;

            if(innBestilling.returDato != null)
            {
                Session["returDato"] = innBestilling.returDato;
            } else
            {
                Session["returDato"] = null;
            }

            //Session["returTid"] = innBestilling.returTid;
            Session["voksen"] = innBestilling.voksen;
            Session["barn0_5"] = innBestilling.barn0_5;
            Session["student"] = innBestilling.student;
            Session["honnoer"] = innBestilling.honnoer;
            Session["vernepliktig"] = innBestilling.vernepliktig;
            Session["barn6_17"] = innBestilling.barn6_17;
            Session["barnevogn"] = innBestilling.barnevogn;
            Session["sykkel"] = innBestilling.sykkel;
            Session["hundover_40cm"] = innBestilling.hundover_40cm;
            Session["kjaeledyrunder_40cm"] = innBestilling.kjaeledyrunder_40cm;

            return RedirectToAction("visAvganger"); 
        }

        [HttpPost]
        public ActionResult regBestilling3(Bestilling innBestilling)
        {
            var db = new DBContext();

            if (innBestilling.avgangstid != null)
            {
                var avgangstid = Int32.Parse(innBestilling.avgangstid);
                visAvgang enAvgangFra = db.hentVisAvgang(avgangstid);
                Session["avgangstid"] = enAvgangFra.avgangstid;
            }

            if (innBestilling.avgangstidRetur != null)
            {
                var avgangstidRetur = Int32.Parse(innBestilling.avgangstidRetur);
                visAvgang enAvgangRetur = db.hentVisAvgang(avgangstidRetur);
                Session["avgangstidRetur"] = enAvgangRetur.avgangstidRetur;
            }
             
            return RedirectToAction("Betaling");
        }


        public ActionResult hentBestilling(int id)
        {
            var db = new DBContext();
            Bestilling enBestilling = db.hentBestilling(id);
            return View(enBestilling);
        }

        [HttpPost]
        public ActionResult regBestilling2(Bestilling innBestilling)
        {
            var db = new DBContext();

            innBestilling.fraLokasjon = (Session["fraLokasjon"]).ToString();
            innBestilling.tilLokasjon = (Session["tilLokasjon"]).ToString();
            innBestilling.billettType = (Session["billettType"]).ToString();

            var inputUt = Session["utreiseDato"].ToString(); // dd-MM-yyyy   
            DateTime? dtTur = string.IsNullOrEmpty(inputUt) ? (DateTime?)null : DateTime.Parse(inputUt);
            innBestilling.utreiseDato = dtTur;
            innBestilling.avgangstid = Session["avgangstid"].ToString();
            //innBestilling.utreiseTid = (Session["utreiseTid"]).ToString();

            if (Session["returDato"] != null)
            {
                var inputRetur = Session["returDato"].ToString(); // dd-MM-yyyy    
                DateTime? dtRetur = string.IsNullOrEmpty(inputRetur) ? (DateTime?)null : DateTime.Parse(inputRetur);
                innBestilling.returDato = dtRetur;
            }

            if (Session["avgangstidRetur"] != null)
            {
                innBestilling.avgangstidRetur = Session["avgangstidRetur"].ToString();
            }

            //innBestilling.returTid = (Session["returTid"]).ToString();
            innBestilling.voksen = (int?)Session["voksen"];
            innBestilling.barn0_5 = (int?)Session["barn0_5"];
            innBestilling.student = (int?)Session["student"];
            innBestilling.honnoer = (int?)Session["honnoer"];
            innBestilling.vernepliktig = (int?)Session["vernepliktig"];
            innBestilling.barn6_17 = (int?)Session["barn6_17"];
            innBestilling.barnevogn = (int?)Session["barnevogn"];
            innBestilling.sykkel = (int?)Session["sykkel"];
            innBestilling.hundover_40cm = (int?)Session["hundover_40cm"];
            innBestilling.kjaeledyrunder_40cm = (int?)Session["kjaeledyrunder_40cm"];

            bool OK = db.lagreBestilling(innBestilling);
            if (OK)
            {
                return RedirectToAction("Betaling");
            }
            else
            {
                return RedirectToAction("Bestilling");
            }

        }

        // Metoder for Avgang
        public ActionResult listAvganger()
        {
            var db = new DBContext();
            List<Avgang> alleAvganger = db.alleAvganger();
            return View(alleAvganger);
        }

        public ActionResult endreAvgang(int id)
        {
            var db = new DBContext();
            Avgang enAvgang = db.hentAvgang(id);
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult endreAvgang(Avgang innAvgang)
        {
            var db = new DBContext();
            bool OK = db.endreAvgang(innAvgang);
            if (OK)
            {
                RedirectToAction("listAvganger");
            }
            return View();
        }

        public ActionResult slettAvgang(int id)
        {
            var db = new DBContext();
            bool OK = db.slettAvgang(id);
            if (OK)
            {
                RedirectToAction("listAvganger");
            }
            return View();
        }

        public ActionResult regAvgang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult regAvgang(Avgang innAvgang)
        {
            var db = new DBContext();
            bool OK = db.lagreAvgang(innAvgang);
            if (OK)
            {
                return RedirectToAction("listAvganger");
            }
            return View();
        }

        // Metoder for visAvgang
        public ActionResult visAvganger()
        {
            return View();
        }

        public ActionResult listVisAvganger()
        {
            var db = new DBContext();
            List<visAvgang> alleAvganger = db.alleVisAvganger();
            return View(alleAvganger);
        }

        public ActionResult endreVisAvgang(int id)
        {
            var db = new DBContext();
            visAvgang enAvgang = db.hentVisAvgang(id);
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult endreVisAvgang(visAvgang innAvgang)
        {
            var db = new DBContext();
            bool OK = db.endreVisAvgang(innAvgang);
            if (OK)
            {
                RedirectToAction("listVisAvganger");
            }
            return View();
        }

        public ActionResult slettVisAvgang(int id)
        {
            var db = new DBContext();
            bool OK = db.slettVisAvgang(id);
            if (OK)
            {
                RedirectToAction("listVisAvganger");
            }
            return View();
        }

        public ActionResult registrerVisAvgang()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult registrerVisAvgang(visAvgang innAvgang)
        {
            var db = new DBContext();
            bool OK = db.lagreVisAvgang(innAvgang);
            if (OK)
            {
                return RedirectToAction("listAvganger");
            }
            return View();
        }

        //Metoder for betaling
        public ActionResult Betaling()
        {
            return View();
        }

        public ActionResult listBetaling()
        {
            var db = new DBContext();
            List<Betaling> alleBetalinger = db.alleBetalinger();
            return View(alleBetalinger);
        }

        public ActionResult endreBetaling(int id)
        {
            var db = new DBContext();
            Betaling enBetaling = db.hentBetaling(id);
            return View(enBetaling);
        }

        [HttpPost]
        public ActionResult endreBetaling(Betaling innBetaling)
        {
            var db = new DBContext();
            bool OK = db.endreBetaling(innBetaling);
            if (OK)
            {
                RedirectToAction("listBetalinger");
            }
            return View();
        }

        public ActionResult slettBetaling(int id)
        {
            var db = new DBContext();
            bool OK = db.slettBetaling(id);
            if (OK)
            {
                RedirectToAction("listBetaling");
            }
            return View();
        }

        public ActionResult registrerBetaling()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registrerBetaling(Betaling innBetaling)
        {
            var db = new DBContext();
            bool OK = db.lagreBetaling(innBetaling);
            if (OK)
            {
                return RedirectToAction("listBetaling");
            }
            return View();
        }
    }
}