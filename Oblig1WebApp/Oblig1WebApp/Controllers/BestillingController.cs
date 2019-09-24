using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1WebApp.Models;

namespace Oblig1WebApp.Controllers
{
    public class BestillingController : Controller
    {
        public ActionResult Bestilling()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bestilling(Bestilling innBestilling)
        {

            var db = new DBContext();
            bool OK = db.lagreBestilling(innBestilling);
            if (OK)
            {
                return RedirectToAction("listBestillinger");
            }
            return View();
        }

        [HttpPost]
        public ActionResult regBestilling(Avgang innAvgang)
        {

            var db = new DBContext();
            bool OK = db.lagreAvgang(innAvgang);
            if (OK)
            {
                return RedirectToAction("DynamikkView");
            }
            return View();
        }

        public ActionResult listBestillinger()
        {
            var db = new DBContext();
            List<Bestilling> alleBestillinger = db.alleBestillinger();
            return View(alleBestillinger);
        }

        public ActionResult regAvgang()
        {
            return View();
        }

        [HttpPost]
         public ActionResult regAvgang (Avgang innAvgang)
         {
             var db = new DBContext();
             bool OK = db.lagreAvgang(innAvgang);
             if(OK)
             {
                 return RedirectToAction("listAvganger");
             }
             return View();
         }

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
    }
}