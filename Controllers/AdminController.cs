using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodh.Models;
using Microsoft.Ajax.Utilities;
using static Bodh.Models.Enums;


namespace Bodh.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        JsonResponseData response = new JsonResponseData();
        int result = 0; bool CheckStatus = false;
        string MSG = string.Empty;
        Bodh_DBEntities db=new Bodh_DBEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InqueryList()
        {
            Bodh_DBEntities db_ = new Bodh_DBEntities();
            var tbl= db_.tbl_Inquiry.OrderByDescending(x=>x.CreatedOn).ToList();  
            return View(tbl);
        }
        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }
        #region
        public ActionResult GetMicroCase()
        {
            try
            {
                bool IsCheck = false;
                var tbllist = db.tbl_MicroCase.ToList(); //CommonModel.GetSPCutUserlist();
                if (tbllist != null)
                {
                    IsCheck = true;
                }
                var html = ConvertViewToString("_MicroCaseData", tbllist);
                var res = Json(new { IsSuccess = IsCheck, Data = html }, JsonRequestBehavior.AllowGet);
                res.MaxJsonLength = int.MaxValue;
                return res;
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return Json(new { IsSuccess = false, Data = "" }, JsonRequestBehavior.AllowGet); throw;
            }
        }
        public ActionResult MicroCase(int Id = 0)
        {
            MicroCaseModel model = new MicroCaseModel();
            if (Id > 0)
            {
                var tbl = db.tbl_MicroCase.Find(Id);
                if (tbl != null)
                {
                    model.ID = tbl.ID;
                    model.Date = tbl.Date.Value;
                    model.Title = tbl.Title;
                    model.Subject = tbl.Subject;
                    model.Category = tbl.Category;
                    model.DocumentPath = tbl.DocumentPath;
                    model.HtmlEditor = tbl.HtmlEditor;
                    model.PhotoPath = tbl.PhotoPath;
                    model.BannerPath = tbl.BannerPath;
                    model.URLLink = tbl.URLLink;
                    model.Comment = tbl.Comment;
                    model.Writerby = tbl.Writerby;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult MicroCase(MicroCaseModel model)
        {
            JsonResponseData response = new JsonResponseData();
            result = 0;
            try
            {
                var tbl = model.ID != 0 ? db.tbl_MicroCase.Find(model.ID) : new tbl_MicroCase();
                if (tbl != null)
                {
                    tbl.Date = model.Date.Value;
                    tbl.Title = !(string.IsNullOrWhiteSpace(model.Title)) ? model.Title.Trim() : null;
                    tbl.Subject = !(string.IsNullOrWhiteSpace(model.Subject)) ? model.Subject.Trim() : null;
                    tbl.Category = !(string.IsNullOrWhiteSpace(model.Category)) ? model.Category.Trim() : null;
                    tbl.HtmlEditor = !string.IsNullOrEmpty(model.HtmlEditor) ? model.HtmlEditor.Trim() : null;
                    tbl.URLLink = !string.IsNullOrEmpty(model.URLLink) ? model.URLLink.Trim() : null;
                    tbl.Comment = !string.IsNullOrEmpty(model.Comment) ? model.Comment.Trim() : null;
                    tbl.Writerby = !string.IsNullOrEmpty(model.Writerby) ? model.Writerby.Trim() : null;
                    tbl.IsActive = true;
                    if (model.ID == 0)
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            tbl.CreatedBy = User.Identity.Name;
                            tbl.CreatedOn = DateTime.Now;
                        }
                        db.tbl_MicroCase.Add(tbl);
                    }
                    else
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            tbl.UpdatedOn = DateTime.Now;
                            tbl.UpdatedBy = User.Identity.Name;
                        }
                    }
                    result = db.SaveChanges();
                    if (Request.Files != null && Request.Files.Count > 0)
                    {
                        var multiLinkPic = string.Empty;
                        foreach (var item in Request.Files.AllKeys)
                        {
                            var postedFile = Request.Files[item];
                            string extension = Path.GetExtension(postedFile.FileName);
                            if (extension.ToUpper() == ".JPEG" || extension.ToUpper() == ".JPG"
                                        || extension.ToUpper() == ".PNG" || extension.ToUpper() == ".GIF" || extension.ToUpper() == ".PDF" || extension.ToUpper() == ".DOC" || extension.ToUpper() == ".DOCX")
                            {
                                if (item == "Document")
                                {
                                    tbl.DocumentPath = !string.IsNullOrWhiteSpace(postedFile.FileName) ? CommonModel.SaveSingleFile(postedFile, "CaseStudyDocument", tbl.ID.ToString()) : null;
                                }
                                if (item == "Banner")
                                {
                                    tbl.BannerPath = !string.IsNullOrWhiteSpace(postedFile.FileName) ? CommonModel.SaveSingleFile(postedFile, "CaseStudy", tbl.ID.ToString()) : null;
                                }
                                if (item == "Photo")
                                {
                                    tbl.PhotoPath = !string.IsNullOrWhiteSpace(postedFile.FileName) ? CommonModel.SaveSingleFile(postedFile, "CaseStudy", tbl.ID.ToString()) : null;
                                }
                            }
                        }
                        result = db.SaveChanges();
                    }
                }
                if (result > 0)
                {
                    response = new JsonResponseData { StatusType = eAlertType.success.ToString(), Message = "Data Submitted " + " Successfully.....", Data = tbl.ID };
                    var resResponse1 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse1.MaxJsonLength = int.MaxValue;
                    return resResponse1;
                }
                //}
                //else
                //{
                //    response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = "All Record Required !!", Data = null };
                //    var resResponse1 = Json(response, JsonRequestBehavior.AllowGet);
                //    resResponse1.MaxJsonLength = int.MaxValue;
                //    return resResponse1;
                //};
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
        #endregion

    }
}