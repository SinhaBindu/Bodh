//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bodh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_MicroCase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string HtmlEditor { get; set; }
        public string PhotoPath { get; set; }
        public string BannerPath { get; set; }
        public string DocumentPath { get; set; }
        public string Comment { get; set; }
        public string Writerby { get; set; }
        public string URLLink { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
