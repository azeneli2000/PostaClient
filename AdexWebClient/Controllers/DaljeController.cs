using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AdexWebClient.Controllers
{
    public class DaljeController : Controller
    {
        // GET: Dalje
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ShoferiBusiness shb = new ShoferiBusiness();
                List<Shoferi> p = shb.Shoferet(Convert.ToInt64(Session["idklienti"].ToString()));
                ViewBag.IdShoferi = new SelectList(p, "id", "emri");


                return View();
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }

        [HttpPost]
        public string getOrder(string bcode)
        {

            DaljMagBusinesscs ob = new DaljMagBusinesscs();
            Order o = new Order();
            o = ob.GetOrder(bcode,Convert.ToInt64( Session["idmagazina"].ToString()));
            ViewBag.shoferi = o.DriverIdDorezimi.ToString();
            var json = new JavaScriptSerializer().Serialize(o);
            return (json);


        }
        [HttpPost]

        public void updateOrder(string bcode, Int64 idShoferi,  decimal detyrimi)
        {
            DaljMagBusinesscs dm = new DaljMagBusinesscs();
            dm.update(bcode, idShoferi, detyrimi);




        }
    }
}