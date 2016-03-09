using BackgroundProofConcept.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BackgroundProofConcept.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slow()
        {            
            return View();
        }

        public ActionResult SendOrder(Order order)
        {
            Thread.Sleep(5000);
            return Json(new{IsCorrect=true});
        }        
    }
}