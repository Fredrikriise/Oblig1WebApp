using Oblig1WebApp.BLL;
using Oblig1WebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Oblig1WebApp.Controllers
{
    public class BrukerController : Controller
    {
        private ILogikk _brukerBBL;

        public BrukerController()
        {
            _brukerBBL = new DBBLL();
        }

        public BrukerController(ILogikk stub)
        {
            _brukerBBL = stub;
        }

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
            //Sjekker om brukeren ble suksessfult innlogget
            if (_brukerBBL.bruker_i_db(innLogget))
            {
                //Brukernavn og passord er godtkjent
                Session["LoggetInn"] = true;
                Session["brukernavn"] = innLogget.brukernavn;
                ViewData["Innlogget"] = true;
                return View("Kontrollpanel");
            }
            else
            {
                //Brukernavn og passord ikke godkjent
                Session["LoggetInn"] = false;
                ViewData["Innlogget"] = false;
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
            Session["nybruker"] = innBruker.brukernavn;

            if (innBruker.brukernavn.Length < 8)
            {
                ModelState.AddModelError("", "Brukernavn er nødt til å bestå av minst 8 tegn");
            }

            if (innBruker.passord.Length < 8)
            {
                ModelState.AddModelError("", "Passordet er nødt til å bestå av minst 8 tegn");
            }

            else
            {

                bool OK = _brukerBBL.lagreBruker(innBruker);

                if (OK)
                {
                    ViewData["RegistrertBruker"] = true;
                    ViewData["Brukernavntatt"] = false;
                    return View();
                }
                else
                {
                    if (_brukerBBL.bruker_i_db(innBruker))
                    {
                        ViewData["Brukernavntatt"] = true;
                    }
                    ViewData["RegistrertBruker"] = false;
                    return View();
                }
            }
            return View();
        }

        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            TempData["LoggetUt"] = true;
            return RedirectToAction("LoggInn");
        }


        public ActionResult listBrukere()
        {
            List<adminBruker> alleBrukere = _brukerBBL.alleBrukere();
            return View(alleBrukere);
        }
    }
}