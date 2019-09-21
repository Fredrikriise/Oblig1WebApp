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
        /* 
         [HttpPost]
         public ActionResult Bestilling (Bestilling innBestilling)
         {
             var db = new DBContext();
             bool OK = db.lagreBestilling(innBestilling);
             if(OK)
             {
                 return RedirectToAction("Bestilling");
             }
             return View();
         } */
    }
}