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
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
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
                Session["brukernavn"] = innLogget.brukernavn;
                ViewBag.Innlogget = true;
                return View("Kontrollpanel");
            } else
            {
                //Brukernavn og passord ikke godkjent
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                ModelState.AddModelError("", "Innlogging feilet, feil brukernavn eller passord!");
                return View();
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
            Session["nybruker"] = innBruker.brukernavn;
            if (OK)
            {
                ViewBag.RegistrertBruker = true;
                return View();
            } else
            {
                ViewBag.RegistrertBruker = false;
                return View();
            }
        }

        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("LoggInn");
        }


        public ActionResult listBrukere()
        {
            var db = new DBContext();
            List<adminBruker> alleBrukere = db.alleBrukere();
            return View(alleBrukere);
        }
    }
}