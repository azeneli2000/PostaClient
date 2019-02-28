using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdexWebClient.Controllers
{
    public class HyrjeController : Controller
    {
        // GET: Hyrje
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Perdoruesi perdoruesiObject)
        {
            PerdoruesiBusiness pb = new PerdoruesiBusiness();

            Perdoruesi perd = pb.Perdoruesit.Where(s => s.perdoruesi.Equals(perdoruesiObject.perdoruesi) && s.password.Equals(perdoruesiObject.password)).FirstOrDefault();
            //gjej username dhe password nga database
            if (perd != null)
            {
                Session["userID"] = perd.perdoruesi.ToString();
                Session["emri"] = perd.emri.ToString();
                Session["adresa"] = perd.adresa.ToString();
                Session["idklienti"] = perd.id;
                Session["agjensi"] = perd.agjensi.ToString();
                Session["idmagazina"] = perd.idMagazina;
                Session["balanca"] = perd.detyrimi.ToString();
                return RedirectToAction("Index", "Blank");
            }
            else

                return View();
        }


    }
}