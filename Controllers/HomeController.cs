using Bodh.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using static Bodh.Models.Enums;

namespace Bodh.Controllers
{
    public class HomeController : Controller
    {
        JsonResponseData response = new JsonResponseData();
        int result = 0; bool CheckStatus = false;
        string MSG = string.Empty;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult domainexpert()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }

        public ActionResult OurTeam()
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
            ContactModel model = new ContactModel();
            return View(model);
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
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Contact(ContactModel model)
        {
            Bodh_DBEntities db_ = new Bodh_DBEntities();
            JsonResponseData response = new JsonResponseData();
            result = 0;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = "All fields required !!", Data = null };
                    var resResponse1 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse1.MaxJsonLength = int.MaxValue;
                    return resResponse1;
                }
                var tbl = model.Id != Guid.Empty ? db_.tbl_Inquiry.Find(model.Id) : new tbl_Inquiry();
                if (tbl != null)
                {
                    tbl.Name = !(string.IsNullOrWhiteSpace(model.Name)) ? model.Name.Trim() : null;
                    tbl.MobileNo = !(string.IsNullOrWhiteSpace(model.MobileNo)) ? model.MobileNo.Trim() : null;
                    tbl.EmailId = !(string.IsNullOrWhiteSpace(model.EmailId)) ? model.EmailId.Trim() : null;
                    tbl.Comment = !string.IsNullOrEmpty(model.Comment) ? model.Comment.Trim() : null;
                    tbl.IsActive = true;
                    if (model.Id == Guid.Empty)
                    {
                        tbl.Id = Guid.NewGuid();
                        tbl.CreatedOn = DateTime.Now;
                        db_.tbl_Inquiry.Add(tbl);
                    }
                    result = db_.SaveChanges();
                }
                if (result > 0)
                {
                    CommonModel.SendMailForUser(model);
                    response = new JsonResponseData { StatusType = eAlertType.success.ToString(), Message = "Inquiry Data Submitted " + " Successfully.....", Data = null };
                    var resResponse1 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse1.MaxJsonLength = int.MaxValue;
                    return resResponse1;
                }
            }
            catch (Exception)
            {
                response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = "There was a communication error.", Data = null };
                var resResponse1 = Json(response, JsonRequestBehavior.AllowGet);
                resResponse1.MaxJsonLength = int.MaxValue;
                return resResponse1;
            }
            return View();
        }
    }
}