using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Globalization;


namespace AdexWebClient.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                OrderBusiness ob = new OrderBusiness();
                DatePicker d = new DatePicker();
                d.DataFillimi = DateTime.UtcNow;
                d.DataMbarimi = DateTime.UtcNow;

                return View(ob.Orders.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }
        [HttpPost]
        [ActionName ("Index")]
        public ActionResult Index(DatePicker d)
        {
            if (Session["UserID"] != null)
            {
                //var dataF = d.DataFillimi;
                //var dataM = d.DataMbarimi;
                
             
                List<Order> o = new List<Order>();
                OrderBusiness ob = new OrderBusiness();
                DateTime df;
                DateTime dm;
                DateTime.TryParse(d.DataFillimi.ToString(),out df);
                DateTime.TryParse(d.DataMbarimi.ToString(), out dm);

                o = ob.OrdersByDate(df,dm);

                //   o = ob.OrdersByDate(DateTime.ParseExact(d.DataFillimi.ToString(), "mm-dd-yy", CultureInfo.InvariantCulture), DateTime.ParseExact(d.DataMbarimi.ToString(), "mm-dd-yy", CultureInfo.InvariantCulture));
                return View(o.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }

        public ActionResult Create ()
        {
            Utility utility = new Utility();
            ViewBag.IdLloji = new SelectList(utility.GetLlojet(), "id", "emri");
            ViewBag.IdZona = new SelectList(utility.GetZonat(), "id", "emri");
            return View();

        }
        [HttpPost]
        public ActionResult Create(Order o)
        {
            Utility utility = new Utility();

            if (ModelState.IsValid)
            {
                OrderBusiness ob = new OrderBusiness();
                ob.shto(o);
                return RedirectToAction("Index");
            }
            else
            ViewBag.IdLloji = new SelectList(utility.GetLlojet(), "id", "emri",o.IdLloji);
            ViewBag.IdZona = new SelectList(utility.GetZonat(), "id", "emri",o.IdZona);
            return View(o);
            

        }
        public ActionResult Calc(string idLloji,string idZona,string pesha)
        {
            OrderBusiness ob = new OrderBusiness();
            return Content(ob.gjej_cmimin(idLloji,idZona,pesha));


        }


        [HttpGet]
        public ActionResult Detaje(int id)
        {
            if (Session["UserID"] != null)
            {

                OrderBusiness ob = new OrderBusiness();
                Order or = ob.Orders.Single(s => s.idOrder == id);
                ViewBag.Base64String = or.ImageUrl;
                ViewBag.Derguesi = Session["emri"].ToString();
                return View(or);

            }
            else
            {
                return RedirectToAction("Index", "Hyrje");
            }
        }

        public ActionResult PrintDetaje(int id)
        {
            ViewBag.Derguesi = Session["emri"].ToString();
            var q = new Rotativa.ActionAsPdf("Detaje",new {id = id});
            return (q);
        }
    }
}