﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodh.Controllers;
using Bodh.Models;
using static Bodh.Models.CommonModel;

namespace Bodh.Controllers
{
    [Authorize]
    public class ResourceController : BaseController
    {
        Bodh_DBEntities db = new Bodh_DBEntities();
        // GET: Resource
        public ActionResult Index()
        {
            var x = db.Tbl_FileResource.ToList();
            return View(x);
        }
        public ActionResult ResourceUpload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult ResourceUpload(FileResourceModel model)
        {
            Bodh_DBEntities _db = new Bodh_DBEntities();
            try
            {
                if (string.IsNullOrWhiteSpace(model.DocumentType) || model.DocumentType=="0")
                {
                    Warning("Please Document Type fields.", true);
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    var count= _db.Tbl_FileResource.ToList().Count; 

                    var getid = count!=0? _db.Tbl_FileResource?.Max(x => x.FileId_pk):count;
                    getid = getid == 0 ? 1 : (getid + 1);
                    Tbl_FileResource tbl = new Tbl_FileResource();
                    tbl.FileGuid = Guid.NewGuid().ToString();
                    tbl.DocumentType = model.DocumentType;
                    tbl.Subject = model.Subject;
                    //tbl.Description = model.Description;
                    tbl.LetterNo = model.LetterNo;
                    tbl.DateofIssue = model.DateofIssue;
                    tbl.IsActive = true;
                    tbl.CreatedOn = DateTime.Now;
                    tbl.Description = !string.IsNullOrEmpty(model.Description) ? model.Description.Trim() : null;
                    tbl.Writerby = !string.IsNullOrEmpty(model.Writerby) ? model.Writerby.Trim() : null;
                    if (model.file!=null)
                    {
                        tbl.FileName = model.file.FileName;
                    }
                    if (model.Image!=null)
                    {
                        tbl.FileImage = model.Image.FileName;
                    }
                    
                    tbl.CreatedBy = User.Identity.Name;
                    FileModel fileModels =new FileModel();
                    if (model.file!=null)
                    {
                        fileModels = saveFile(model.file, getid + "DocumentType", "", "");
                        if (fileModels.FilePathFull != "")
                        {
                            tbl.AttachmentFile = fileModels.FilePathFull;
                        }
                    }
                    
                    if (model.Image!=null)
                    {
                        FileModel fileModelimage = saveFile(model.Image, "", fileModels.FolderPath, "");
                        if (fileModelimage.FilePathFull != "")
                        {
                            tbl.AttachmentImage = fileModelimage.FilePathFull;
                        }
                    }
                   

                    db.Tbl_FileResource.Add(tbl);
                    db.SaveChanges();
                    Success("File Saved successfully !", true);
                    return RedirectToAction("ResourceUpload");
                }
                else
                {
                    Warning("please fill all mandatory fields.", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Danger("Something went wrong..", true);
            }
            return View(model);
        }
        public FileModel saveFile(HttpPostedFileBase item, string Requestby, string Fldpath, string FileName = "")
        {
            FileModel fileModel = new FileModel();
            string URL = "";
            string filepath = string.Empty;
            if (item != null && item.ContentLength > 0)
            {
                if (Fldpath!= URL)
                {
                    URL = Fldpath;
                }
                if (Requestby!="")
                { URL = "/Uploads/" + Requestby + "/" + CommonModel.GetRandomNumber() + "/"; }   
                string folderPath = Server.MapPath("~" + URL);

                var supportedTypes = new[] { "pdf", "xls", "xlsx", "jpeg", "png", "jpg" };

                var fileName = Path.GetFileName(item.FileName);
                // var rondom = Guid.NewGuid() + fileName;

                // var fileExt = System.IO.Path.GetExtension(rondom).Substring(1).ToLower();

                //if (!supportedTypes.Contains(fileExt.ToLower()))
                //{
                //   // Danger("File Extension Is InValid - Upload Only PDF/EXCEL/JPEG/PNG/JPG File");
                //   // return RedirectToAction("VendorDetails", new { id = d.guid });
                //}

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // string Document = Path.Combine("~/Uploads/VendorDoc/" + rondom);

                item.SaveAs(folderPath + fileName);
                filepath = URL + fileName;
                fileModel.FolderPath = URL;
            }
            fileModel.FilePathFull = filepath;
            return fileModel;

        }

        public class FileModel
        {
            public string FilePathFull { get; set; }
            public string FolderPath { get; set; }
        }

    }
}