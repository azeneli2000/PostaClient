using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Web.Script.Serialization;

namespace AdexWebClient.Controllers
{
    public class HyrjeMagController : Controller
    {
        // GET: HyrjeMag
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {

                ViewBag.magazina = Session["idmagazina"].ToString();
                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }
        [HttpPost]
        public ActionResult Index(string bcode)
        {
            if (Session["UserID"] != null)
            {
                HyrjeMagBusiness ob = new HyrjeMagBusiness();
                Order o = new Order();
                o = ob.GetOrder(bcode);
                return View(o);
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }
        [HttpPost]
        public string getOrder(string bcode)
        {
           
                HyrjeMagBusiness ob = new HyrjeMagBusiness();
                Order o = new Order();
                o = ob.GetOrder(bcode);
            ViewBag.shoferi = o.DriverIdDorezimi.ToString();
            var json = new JavaScriptSerializer().Serialize(o);
            return (json);


        }
        [HttpPost]

        public void updateOrder(string bcode,Int64 idShoferi,Int64 idMagazina,decimal detyrimi)
        {
            HyrjeMagBusiness ob = new HyrjeMagBusiness();
            Order o = new Order();
             ob.update(bcode,idShoferi,idMagazina,detyrimi);
            
            


        }
    }
}