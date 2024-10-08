﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bodh.Models
{
    public class MicroCaseModel
    {
        public MicroCaseModel()
        {
            ID = 0;
        }
        public int ID { get; set; }
        [Required]
        [Display(Name = "Date")]
        public Nullable<DateTime> Date { get; set; }
        //[Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Case Studies Description")]
        [AllowHtml]
        public string HtmlEditor { get; set; }
        public string PhotoPath { get; set; }
        //[Required]
        [Display(Name = "Upload Image")]
        public HttpPostedFile Photo { get; set; }
       // [Required]
        [Display(Name = "Upload Banner")]
        public HttpPostedFile Banner { get; set; }
        public string BannerPath { get; set; }
        [Display(Name = "Document")]
      
        public string Document { get; set; }
        public string DocumentPath { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        [Required]
        [Display(Name = "Url Link")]
        public string URLLink { get; set; }
        [Required]
        [Display(Name = "Comment")]
        [StringLength(1200, MinimumLength = 3, ErrorMessage = "* Part numbers must be between 3 and 120 character in length.")]
        public string Comment { get; set; }
        //[Required]
        [Display(Name = "Writer By")]
        public string Writerby { get; set; }
    }

    public class CaseDetView
    {
        public int ID { get; set; }
        public string MY { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string Desp { get; set; }
        public string Photo { get; set; }
        public string Banner { get; set; }
    }
}