using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Oblig1WebApp.Models;

namespace Oblig1WebApp.Controllers
{
    public class BrukerController : Controller
    {
        public ActionResult Kontrollpanel()
        {
            if(Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            } else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }
            return View();
        }

        public ActionResult LoggInn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggInn(adminBruker innLogget)
        {
            var db = new DBContext();
            //Sjekker om brukeren ble suksessfult innlogget
            if (db.bruker_i_db(innLogget))
            {
                //Brukernavn og passord er godtkjent
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View("Kontrollpanel");
            } else
            {
                //Brukernavn og passord ikke godkjent
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View("loggInn");
            }
        } 

        public ActionResult RegistrerBruker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrerBruker(adminBruker innBruker)
        {
            var db = new DBContext();
            bool OK = db.lagreBruker(innBruker);
            if(OK)
            {
                return View("Kontrollpanel");
            } else
            {
                return View();
            }
           
        }

        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("LoggInn");
        }
    }
}