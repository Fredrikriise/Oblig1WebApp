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
        // GET: Bestilling
        public ActionResult Bestilling()
        {
            return View();
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
    }
}