using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bodh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }

        public ActionResult OurWork()
        {
            return View();
        }

        public ActionResult StudiesPaper()
        {
            return View();
        }

        public ActionResult MaleEngagement()
        {
            return View();
        }
        public ActionResult RCCEBihar()
        {
            return View();
        }
        public ActionResult SRHRNeedsInMigrant()
        {
            return View();
        }
        public ActionResult IFAAdherence()
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
        public ActionResult BarrierIdentification()
        {
            return View();
        }
        public ActionResult SolutionDevelopment()
        {
            return View();
        }
        public ActionResult SolutionTesting()
        {
            return View();
        }
        public ActionResult MonitoringAndEvaluation()
        {
            return View();
        }

        public ActionResult BodhWay()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult BodhCredential()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult JTSP()
        {
            return View();
        }
    }
}