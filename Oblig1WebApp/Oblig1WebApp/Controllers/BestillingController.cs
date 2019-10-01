using Oblig1WebApp.Models;
using System.Collections.Generic;
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
                bool OK = db.lagreBestilling(innBestilling);
                if (OK)
                {
                    Session["data1"] = innBestilling.fraLokasjon;
                    Session["data2"] = "heejejeje";
                    return RedirectToAction("listVisAvganger");
                } else
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

        
    }
}