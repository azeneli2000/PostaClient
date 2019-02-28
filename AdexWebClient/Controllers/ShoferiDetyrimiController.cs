using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
namespace AdexWebClient.Controllers
{
    public class ShoferiDetyrimiController : Controller
    {
        // GET: ShoferiDetyrimi
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ShoferiDetyrimBusiness shdb = new ShoferiDetyrimBusiness();
                return View(shdb.Shoferet(Convert.ToInt64( Session["idklienti"].ToString())));
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["UserID"] != null)
            {
                ShoferiDetyrimBusiness shdb = new ShoferiDetyrimBusiness();
                ShoferiDetyrim shof = shdb.Shoferet(Convert.ToInt64(Session["idklienti"].ToString())).Single(s => s.id == id);               
                return View(shof);
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }

        }
        [HttpPost]
        public ActionResult Edit(ShoferiDetyrim shof)
        {
            if (Session["UserID"] != null)
            {
                ShoferiDetyrimBusiness shdb = new ShoferiDetyrimBusiness();
                if (ModelState.IsValid)

                {
                    
                    
                        shdb.modifiko(shof);
                        return RedirectToAction("Index", "ShoferiDetyrimi");
                   

                }
                else
                {
                  
                    return View();

                }
            }
            else
            {

                return RedirectToAction("Index", "Hyrje");
            }
        }
    }
}