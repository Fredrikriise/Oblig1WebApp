using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Oblig1WebApp.Controllers
{
    public class BestillingController : Controller
    {
        private ILogikk _bestillingBBL;

        public BestillingController()
        {
            _bestillingBBL = new DBBLL();
        }

        public BestillingController(ILogikk stub)
        {
            _bestillingBBL = stub;
        }
        // Metoder for Bestilling
        public ActionResult Bestilling()
        {
            return View();
        }

        public ActionResult listBestillinger()
        {
            List<Bestilling> alleBestillinger = _bestillingBBL.alleBestillinger();
            return View(alleBestillinger);
        }

        [HttpPost]
        public ActionResult regBestilling(Bestilling innBestilling)
        {
            if (innBestilling.fraLokasjon == null)
            {
                ModelState.AddModelError("fraLokasjon", "Du er nødt til å velge hvor du ønsker å reise fra");
            }
            else
            {
                var idFra = Int32.Parse(innBestilling.fraLokasjon);
                visAvgang enAvgangFra = _bestillingBBL.hentVisAvgang(idFra);
                Session["fraLokasjon"] = enAvgangFra.forsteAvgang;
            }

            if (innBestilling.fraLokasjon == null)
            {
                ModelState.AddModelError("tilLokasjon", "Du er nødt til å velge hvor du ønsker å reise til");
            }
            else
            {
                var idTil = Int32.Parse(innBestilling.tilLokasjon);
                visAvgang enAvgangTil = _bestillingBBL.hentVisAvgang(idTil);
                Session["tilLokasjon"] = enAvgangTil.sisteAvgang;
            }

            Session["billettType"] = innBestilling.billettType;

            if (innBestilling.utreiseDato == null)
            {
                ModelState.AddModelError("utreisedato", "Du er nødt til å velge hvilke dato du ønsker å reise");

            }
            else
            {
                Session["utreiseDato"] = innBestilling.utreiseDato;
            }

            if (innBestilling.billettType == "Tur retur")
            {
                if (innBestilling.returDato == null)
                {
                    ModelState.AddModelError("returdato", "Du er nødt til å velge hvilken dato du ønsker å returnere");
                }
                else
                {
                    Session["returDato"] = innBestilling.returDato;
                }
            }
            else
            {
                Session["returDato"] = null;
            }

            if (innBestilling.voksen < 0 && innBestilling.barn0_5 < 0 && innBestilling.student < 0 && innBestilling.honnoer < 0 && innBestilling.vernepliktig < 0 && innBestilling.barn6_17 < 0)
            {
                ModelState.AddModelError("reisende", "Du er nødt til å velge reisende");
            }
            else
            {
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
            }

            if (!ModelState.IsValid)
            {
                return View("Bestilling");
            }
            return RedirectToAction("visAvganger");
        }

        [HttpPost]
        public ActionResult regBestilling3(Bestilling innBestilling)
        {
            if (innBestilling.avgangstid != null)
            {
                Session["avgangstid"] = innBestilling.avgangstid;
            }

            if (innBestilling.avgangstidRetur != null)
            {
                Session["avgangstidRetur"] = innBestilling.avgangstidRetur;
            }
            return RedirectToAction("Betaling");
        }

        public ActionResult hentBestilling(int id)
        {
            Bestilling enBestilling = _bestillingBBL.hentBestilling(id);
            return View(enBestilling);
        }

        [HttpPost]
        public ActionResult regBestilling2(Bestilling innBestilling, Betaling innBetaling)
        {
            innBestilling.fraLokasjon = (Session["fraLokasjon"]).ToString();
            innBestilling.tilLokasjon = (Session["tilLokasjon"]).ToString();
            innBestilling.billettType = (Session["billettType"]).ToString();
            var inputUt = Session["utreiseDato"].ToString(); // dd-MM-yyyy
            DateTime? dtTur = string.IsNullOrEmpty(inputUt) ? (DateTime?)null : DateTime.Parse(inputUt);
            innBestilling.utreiseDato = dtTur;
            innBestilling.avgangstid = Session["avgangstid"].ToString();

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

            bool OK = _bestillingBBL.lagreBestilling(innBestilling);
            bool OKBetaling = _bestillingBBL.lagreBetaling(innBetaling);

            if (OK && OKBetaling)
            {
                TempData["Bestilt"] = true;
                return RedirectToAction("Bestilling");
            }
            else
            {
                return View();
            }
        }

        public ActionResult slettBestilling(int id)
        {
            Bestilling enBestilling = _bestillingBBL.hentBestilling(id);
            return View(enBestilling);
        }

        [HttpPost]
        public ActionResult slettBestilling(int id, Bestilling innBestilling)
        {
            bool OK = _bestillingBBL.slettBestilling(id) && _bestillingBBL.slettBetaling(id);
            if (OK)
            {
                TempData["Slettet"] = true;
                return RedirectToAction("listBestillinger");
            }
            return View();
        }

        // Metoder for Avgang
        public ActionResult listAvganger()
        {
            List<Avgang> alleAvganger = _bestillingBBL.alleAvganger();
            return View(alleAvganger);
        }

        public ActionResult endreAvgang(int id)
        {
            Avgang enAvgang = _bestillingBBL.hentAvgang(id);
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult endreAvgang(Avgang innAvgang)
        {
            bool OK = _bestillingBBL.endreAvgang(innAvgang);
            if (OK)
            {
                TempData["Endret"] = true;
                return RedirectToAction("listAvganger");
            }
            return View();
        }

        public ActionResult slettAvgang(int id)
        {
            Avgang enAvgang = _bestillingBBL.hentAvgang(id);
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult slettAvgang(int id, Avgang innAvgang)
        {
            bool OK = _bestillingBBL.slettAvgang(id);
            if (OK)
            {
                TempData["Slettet"] = true;
                return RedirectToAction("listAvganger");
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
            bool OK = _bestillingBBL.lagreAvgang(innAvgang);
            if (OK)
            {
                TempData["Registrert"] = true;
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
            List<visAvgang> alleAvganger = _bestillingBBL.alleVisAvganger();
            return View(alleAvganger);
        }

        public ActionResult endreVisAvgang(int id)
        {
            visAvgang enAvgang = _bestillingBBL.hentVisAvgang(id);
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult endreVisAvgang(visAvgang innAvgangtid)
        {
            bool OK = _bestillingBBL.endreVisAvgang(innAvgangtid);
            if (OK)
            {
                TempData["Endret"] = true;
                return RedirectToAction("listVisAvganger");
            }
            return View();
        }


        public ActionResult slettVisAvgang(int id)
        {
            visAvgang enAvgang = _bestillingBBL.hentVisAvgang(id);
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult slettVisAvgang(int id, visAvgang innAvgang)
        {
            bool OK = _bestillingBBL.slettVisAvgang(id);
            if (OK)
            {
                TempData["Slettet"] = true;
                return RedirectToAction("listVisAvganger");
            }
            return View();
        }

        public ActionResult registrerVisAvgang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registrerVisAvgang(visAvgang innAvgangtid)
        {
            bool OK = _bestillingBBL.lagreVisAvgang(innAvgangtid);
            if (OK)
            {
                TempData["Registrert"] = true;
                return RedirectToAction("listVisAvganger");
            }
            return View();
        }

        // Metoder for alleavgangstider
        public ActionResult visAlleavgangstider()
        {
            return View();
        }

        public ActionResult listAlleavgangstider()
        {
            List<alleavgangstid> alleAvgangTider = _bestillingBBL.alleAlleavgangstid();
            return View(alleAvgangTider);
        }

        public ActionResult endreAlleavgangstider(int id)
        {
            alleavgangstid enAvgangTid = _bestillingBBL.hentAlleavgangstider(id);
            return View(enAvgangTid);
        }

        [HttpPost]
        public ActionResult endreAlleavgangstider(alleavgangstid innAvgangtid)
        {
            bool OK = _bestillingBBL.endreAlleavgangstider(innAvgangtid);
            if (OK)
            {
                TempData["Endret"] = true;
                return RedirectToAction("listAlleavgangstider");
            }
            return View();
        }

        public ActionResult slettalleavgangstid(int id)
        {
            alleavgangstid enAvgangsTid = _bestillingBBL.hentAlleavgangstider(id);
            return View(enAvgangsTid);
        }

        [HttpPost]
        public ActionResult slettalleavgangstid(int id, alleavgangstid innAlleavgangstid)
        {
            bool OK = _bestillingBBL.slettalleavgangstid(id);
            if (OK)
            {
                TempData["Slettet"] = true;
                return RedirectToAction("/Bestilling/listAlleavgangstider");
            }
            return View();
        }

        public ActionResult registreralleavgangstid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registreralleavgangstid(alleavgangstid innAvgangtid)
        {
            bool OK = _bestillingBBL.lagrealleavgangstid(innAvgangtid);
            if (OK)
            {
                TempData["Registrert"] = true;
                return RedirectToAction("listAlleavgangstider");
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
            List<Betaling> alleBetalinger = _bestillingBBL.alleBetalinger();
            return View(alleBetalinger);
        }

        public ActionResult betalingDetaljer (int id)
        {
            Betaling enBetaling = _bestillingBBL.hentBetaling(id);
            return View(enBetaling);
        }
    }
}