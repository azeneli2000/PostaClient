using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdexWebClient.Controllers
{
    public class BlankController : Controller
    {
        // GET: Blank
        public ActionResult Index(Perdoruesi p)
        {
            return View(p);
        }
    }
}