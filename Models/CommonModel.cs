using SubSonic.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Bodh.Models
{
    public class CommonModel
    {
        private static Bodh_DBEntities dbe = new Bodh_DBEntities();

        #region BaseUrl
        public static string GetBaseUrl()
        {
            var str = HttpContext.Current.Request.Url.Host;
            //return str;
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            string host = HttpContext.Current.Request.Url.Host;
            if (host == "localhost")
            {
                host = HttpContext.Current.Request.Url.Authority;
                return HttpContext.Current.Request.Url.Scheme + "://" + host;
            }
            //return urlHelper.Content("~/");
            return HttpContext.Current.Request.Url.Scheme + "://" + str;
        }
        public static string GetWebUrl()
        {
            return ConfigurationManager.AppSettings["WebUrl"];
        }

        public static bool IsEmailConfiguredToLive()
        {
            var isLive = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEmailSetLive"].ToString());
            return isLive;
        }
        public static string GetLocalEmailAddress()
        {
            var emailAddr = ConfigurationManager.AppSettings["LocalEmailAddress"].ToString();
            return emailAddr;
        }

        public static string GetFileUrl(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return CommonModel.GetBaseUrl() + filePath.ToString().Replace("~", "");
            else
                return string.Empty;
        }

        public static string GetMultipleFileUrlFromComma(string filePaths)
        {
            //string filePath = string.Empty;
            //var filePathArray = filePaths.Split(',');
            List<string> filePathList = new List<string>();
            foreach (var path in filePaths.Split(','))
            {
                if (!string.IsNullOrEmpty(path))
                {
                    //return CommonModel.GetBaseUrl() + path.ToString().Replace("~", "");
                    filePathList.Add(CommonModel.GetBaseUrl() + path.Trim().ToString().Replace("~", ""));
                }
                //else
                //    return string.Empty;

            }
            //filePathList=.Join(',');
            return string.Join(",", filePathList);
        }

        public static string GetHeaderUSLogo(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return filePath.ToString().Replace("src=\"..//Content/images/USAID_Template.png\"", "src=\"" + CommonModel.GetWebUrl() + "/Content/images/USAID_Template.png\"");
            else
                return string.Empty;
        }
        public static string GetHeaderCareLogo(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return filePath.ToString().Replace("src=\"..//Content/images/Care_Template.png\"", "src=\"" + CommonModel.GetWebUrl() + "/Content/images/Care_Template.png\"");
            else
                return string.Empty;
        }
        public static int GetRandomNumber()
        {
            Random rnd = new Random();
            int rnd_num = rnd.Next(10000, 99999);
            return rnd_num;
        }
        #endregion

        #region Date Formats Functions
        public static DateTime FormateDt(DateTime date)
        {
            return date.Date;
        }
        public static DateTime? TruncateTime(DateTime? original)
        {
            if (!original.HasValue) return null;
            return original.Value.Date;
        }
        public static string FormateDtMDY(string date)
        {
            string dt = "";
            if (!string.IsNullOrEmpty(date))
            {
                dt = Convert.ToDateTime(date).ToString("MM-dd-yyyy");
            }
            return dt;
        }
        public static string FormateDtDMY(string date)
        {
            string dt = "";
            if (!string.IsNullOrEmpty(date))
            {
                dt = Convert.ToDateTime(date).ToString("dd-MMM-yyyy");
            }
            return dt;
        }
        public static string FormateDtMY(DateTime date)
        {
            string dt = "";
            if (date != null)
            {
                string m = date.Month.ToString();
                string y = date.Year.ToString();
                dt = Convert.ToDateTime(date).ToString("MMM-yyyy");
            }
            return dt;
        }
        #endregion
        #region Sending Email
        //public static string SendMail(string To, string Subject, string Body, string ReceiverName, string SenderName)
        //{
        //    try
        //    {
        //        string bodydata = string.Empty;
        //        string bodyTemplate = string.Empty;
        //        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Views/Shared/MailTemplate.html")))
        //        {
        //            bodyTemplate = reader.ReadToEnd();
        //        }

        //        MailMessage mail = new MailMessage();
        //        //mail.To.Add("bindu@careindia.org");
        //        mail.To.Add(To);
        //        mail.From = new MailAddress("careindiabtsp@gmail.com");
        //        mail.Subject = Subject + " ( " + SenderName + " )";
        //        //mail.Body = Body;
        //        bodydata = bodyTemplate.Replace("{Dearusername}", ReceiverName).Replace("{bodytext}", Body).Replace("{newusername}", SenderName);
        //        //bodydata = bodyTemplate.Replace("{bodytext}", Body);
        //        mail.Body = bodydata;
        //        mail.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new System.Net.NetworkCredential("careindiabtsp@gmail.com", "gupczsbvzinhivzw");//Pasw-Care@321 // Enter seders User name and password       
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        tbl_SendMail tbl = new tbl_SendMail();
        //        tbl.Id = Guid.NewGuid();
        //        tbl.MTo = To;
        //        tbl.MFrom = "careindiabtsp@gmail.com";
        //        tbl.Subject = Subject + " ( " + SenderName + " )";
        //        tbl.Boby = bodydata;
        //        tbl.ReceiverName = ReceiverName;
        //        tbl.SenderName = SenderName;
        //        tbl.IsSented = true;
        //        tbl.CreatedBy = CommonModel.User.Id;
        //        tbl.CreatedOn = DateTime.Now;
        //        dbe.tbl_SendMail.Add(tbl);
        //        dbe.SaveChanges();
        //        return "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        tbl_SendMail tbl = new tbl_SendMail();
        //        tbl.Id = Guid.NewGuid();
        //        tbl.MTo = To;
        //        tbl.MFrom = "careindiabtsp@gmail.com";
        //        tbl.Subject = Subject + " ( " + SenderName + " )";
        //        tbl.Boby = Body;
        //        tbl.ReceiverName = ReceiverName;
        //        tbl.SenderName = SenderName;
        //        tbl.IsSented = false;
        //        dbe.tbl_SendMail.Add(tbl);
        //        dbe.SaveChanges();
        //        return "Error :" + ex.Message;
        //    }
        //}

        #endregion

        #region Get User Role 
        public static string GetUserRoleLogin()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Consultant"))
                {
                    return "Consultant";
                }
                if (HttpContext.Current.User.IsInRole("Teacher"))
                {
                    return "Teacher";
                }
            }
            return "All";
        }
        public static string GetUserRoleConsultantDist()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Consultant"))
                {
                    return "Consultant";
                }
            }
            return "All";
        }
        public static string GetUserRole()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //if (HttpContext.Current.User.IsInRole("Admin"))
                //{
                //    return "Admin";
                //}
                //else if (HttpContext.Current.User.IsInRole("State"))
                //{
                //    return "State";
                //}
                if (HttpContext.Current.User.IsInRole("Teacher"))
                {
                    return "Teacher";
                }
                //else if (HttpContext.Current.User.IsInRole("PCI_Representative"))
                //{
                //    return "PCI_Representative";
                //}
                //else if (HttpContext.Current.User.IsInRole("Viewer"))
                //{
                //    return "Viewer";
                //}
            }
            return "All";
        }
        public class ConstUserRoles
        {
            public const string Admin = "Admin";
            public const string Viewer = "Viewer";
        }
        public class ConstUserRolesId
        {
            public const string Admin = "1";
            public const string Viewer = "2";
        }
        //public static UserViewModel Get_IsRole()
        //{
        //    var un = dbe.AspNetRoles.Where(x=>x.Name == CUser.Role);
        //    return role;
        //}



        //public static class SessionLog
        //{
        //    public static int EmployeeId { get { return MvcApplication.Emplog().EmpId_pk; } }
        //    public static int SchoolId_fk { get { return MvcApplication.Emplog().SchoolId_fk == null ? 0 : MvcApplication.Emplog().SchoolId_fk.Value; } }
        //    public static int DistrictId { get { return MvcApplication.Emplog().DistrictId_fk ?? 0; } }
        //    public static int BlockId { get { return MvcApplication.Emplog().BlockId_fk ?? 0; } }
        //    //public static int? EmployeeCode { get { return MvcApplication.Emplog().EmpCode; } }
        //    public static string Name { get { return MvcApplication.Emplog().Name; } }
        //    public static string Email { get { return MvcApplication.Emplog().Email; } }
        //    public static string EmpGuid { get { return MvcApplication.Emplog().EmpGuid; } }
        //    //  public static int Hubid { get { return MvcApplication.Emplog().Hubid_fk.Value; } }

        //    // public static int? SupervisorId { get { return MvcApplication.Emplog().SupervisorId; } }
        //    public static int? StateId { get { return MvcApplication.Emplog().StateId_fk; } }
        //    //  public static string SupervisorName { get { return MvcApplication.Emplog().SupervisorName; } }
        //    //public static string SupervisorEmail { get { return MvcApplication.Emplog().SupervisorEmail; } }
        //}
        //public static List<SelectListItem> GetRole()
        //{
        //    try
        //    {
        //        var dis = new SelectList(dbe.AspNetRoles, "Name", "Name").ToList();
        //        return dis.OrderBy(x => x.Text).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        //DO To
        //        throw;
        //    }
        //}
        //public static string GetLeadRoleName()
        //{
        //    string str = string.Empty;
        //    if (HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        if (CommonModel.User.Role == "SPMU-Member")
        //        {
        //            str = "SPMU-Lead";
        //        }
        //        if (CommonModel.User.Role == "SPMU-Lead")
        //        {
        //            str = "CPMU";
        //        }
        //    }
        //    return str;
        //}




        //public static DataTable GetSPUserDetail()
        //{
        //    StoredProcedure sp = new StoredProcedure("SP_UserDetail");
        //    sp.Command.AddParameter("@User", HttpContext.Current.User.Identity.Name, DbType.String);
        //    DataTable dt = sp.ExecuteDataSet().Tables[0];
        //    return dt;
        //}
        public static DataTable GetSPCutUserlist()
        {
            StoredProcedure sp = new StoredProcedure("SPGetCutUserlist");
            sp.Command.AddParameter("@User", HttpContext.Current.User.Identity.Name, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataSet GetSPCourselist(string Parame)
        {
            StoredProcedure sp = new StoredProcedure("SP_Courselist");
            sp.Command.AddParameter("@Parame", Parame, DbType.String);
            DataSet ds = sp.ExecuteDataSet();
            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            return ds;
        }
        public class User_Model
        {
            public int StateId { get; set; }
            public int DistrictId { get; set; }
            public int BlockId { get; set; }
            public int ClusterId { get; set; }
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string DistrictName { get; set; }
            public string BlockName { get; set; }
            public string ClusterName { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string RoleId { get; set; }
            public string RoleName { get; set; }
            public bool IsStatus { get; set; }
        }
        public class UserName_Model
        {
            public int StateId { get; set; }
            public int DistrictId { get; set; }
            public int BlockId { get; set; }
            public int ClusterId { get; set; }
            public string DistrictName { get; set; }
            public string BlockName { get; set; }
            public string ClusterName { get; set; }
            public string UserName { get; set; }
        }

        #endregion

        #region Document Upload
        public static string GetFilePath(HttpPostedFileBase file, string Module, string RegNo, string Ques_fk, string Folder)
        {
            var url = string.Empty;
            try
            {
                string file_extension = Path.GetExtension(file.FileName).ToLower();
                Stream strmStream = file.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                {
                    url = "~/Uploads/" + Module + "/" + RegNo + "/" + Folder + "/";
                    string extension = Path.GetExtension(file.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(url)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(url));
                    }
                    int index = 1;
                    string filenamewithoutext = Path.GetFileNameWithoutExtension(file.FileName);
                    string fname = filenamewithoutext + extension;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(url, fname))))
                    {
                        index++;
                        fname = file.FileName + "(" + index.ToString() + ")" + extension;
                    }
                    //url = HttpContext.Current.Server.MapPath(url + Ques_fk + "_" + fname);
                    url = url + Ques_fk + "_" + fname;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return url;
        }
        public static string SaveFileDynamically(HttpPostedFileBase[] files, string Module, string RegNo, string Ques_fk, string Folder)
        {
            string URL = "";
            try
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string file_extension = Path.GetExtension(file.FileName).ToLower();
                        Stream strmStream = file.InputStream;
                        if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                        {
                            URL = "~/Uploads/" + Module + "/" + RegNo + "/" + Folder + "/";
                            string extension = Path.GetExtension(file.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                            }
                            int index = 1;
                            string filenamewithoutext = Path.GetFileNameWithoutExtension(file.FileName);
                            string fname = filenamewithoutext + extension;
                            while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                            {
                                index++;
                                fname = file.FileName + "(" + index.ToString() + ")" + extension;
                            }
                            file.SaveAs(HttpContext.Current.Server.MapPath(URL + Ques_fk + "_" + fname));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return URL;
        }
        public static string SaveFile(HttpPostedFileBase[] files, string Module, string RegNo, string Folder)
        {
            string URL = "";
            try
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string file_extension = Path.GetExtension(file.FileName).ToLower();
                        Stream strmStream = file.InputStream;
                        if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                        {
                            //URL = "~/Uploads/" + Module + "/" + RegNo + "/" + Folder + "/";
                            URL = "~/Uploads/" + RegNo + " / ";
                            string extension = Path.GetExtension(file.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                            }
                            int index = 1;
                            string filenamewithoutext = Path.GetFileNameWithoutExtension(file.FileName);
                            string fname = filenamewithoutext + extension;
                            while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                            {
                                index++;
                                fname = file.FileName + "(" + index.ToString() + ")" + extension;
                            }
                            file.SaveAs(HttpContext.Current.Server.MapPath(URL + fname));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return URL;
        }
        public static string SaveSingleFile(HttpPostedFileBase files, string Module, string RegNo)
        {
            string URL = "";
            string filepath = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".doc" || file_extension == ".dotx" || file_extension == ".dot" || file_extension == ".pptx" || file_extension == ".ppt" || file_extension == ".rar" || file_extension == ".zip" || file_extension == ".xls" || file_extension == ".xlsx" || file_extension == ".jpeg" || file_extension == ".png" || file_extension == ".jpg")
                {
                    //URL = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + Module + "/" + RegNo + "/"));
                    URL = "~/Uploads/" + RegNo + "/";
                    string extension = Path.GetExtension(files.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = files.FileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    }
                    files.SaveAs(HttpContext.Current.Server.MapPath(URL + (Module + "-" + fname)));
                    filepath = URL + (Module + "-" + fname);
                }
            }

            return filepath;
        }
        public static string SaveGroupCounsellingModelSessionFile(HttpPostedFileBase files, string ModuleId, string FolderName)
        {
            string URL = "";
            string filepath = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".jpeg" || file_extension == ".png" || file_extension == ".jpg")
                {
                    //URL = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + Module + "/" + RegNo + "/"));
                    URL = "~/ImageUploads/" + FolderName + "/";
                    string extension = Path.GetExtension(files.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = files.FileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    }
                    files.SaveAs(HttpContext.Current.Server.MapPath(URL + (ModuleId + "-" + fname)));
                    filepath = URL + (ModuleId + "-" + fname);
                }
            }

            return filepath;
        }
        public static string DeleteSingleFile(HttpPostedFileBase files, string Module, string RegNo)
        {
            //ToDo: Add code to delete single file from directory
            string URL = "";
            string filepath = string.Empty;



            return filepath;
        }
        public static string SaveSingleFile(HttpPostedFileBase files, string Module, string RegNo, string CustomFileName)
        {
            string URL = "";
            string filepath = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                {
                    //URL = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + Module + "/" + RegNo + "/"));
                    URL = "~/Uploads/" + RegNo + "/";
                    string extension = Path.GetExtension(files.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = CustomFileName + extension; // files.FileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    }
                    files.SaveAs(HttpContext.Current.Server.MapPath(URL + (Module + "-" + fname)));
                    filepath = URL + (Module + "-" + fname);
                }
            }

            return filepath;
        }
        public static string GetFileName(HttpPostedFileBase files)
        {
            string filename = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                {
                    string extension = Path.GetExtension(files.FileName);
                    int index = 1;
                    string fname = files.FileName;
                    fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    filename = fname;
                }
            }
            return filename;
        }
        public static bool IsValidImage(Stream stream)
        {
            try
            {
                //Read an image from the stream...
                var i = Image.FromStream(stream);
                //Move the pointer back to the beginning of the stream
                stream.Seek(0, SeekOrigin.Begin);

                if (ImageFormat.Jpeg.Equals(i.RawFormat))
                    return true;
                return ImageFormat.Png.Equals(i.RawFormat) || ImageFormat.Gif.Equals(i.RawFormat);
            }
            catch
            {
                return false;
            }
        }
        //public static Binary BinarySaveSingleFile(HttpPostedFileBase files)
        //{
        //    byte[] Databytes;
        //    //try
        //    //{
        //    string empFilename = Path.GetFileName(files.FileName);
        //    string FilecontentType = files.ContentType;
        //    using (var reader = new BinaryReader(files.InputStream))
        //    {
        //        Databytes = reader.ReadBytes(files.ContentLength);
        //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    string error = ex.Message;
        //    //}
        //    return Databytes;
        //}
        public static string GetFileExt(string filename)
        {
            string myFilePath = filename;
            string ext = Path.GetExtension(myFilePath);
            return ext;
        }
        #endregion

        #region Monthly,Year
        public static List<SelectListItem> GetTypeOfDateList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "1", Text = "DOB" });
            list.Add(new SelectListItem { Value = "2", Text = "Age in Year,Month" });
            return list.OrderBy(x => x.Text).ToList();
        }
        public static string CalculateAgeFromDOB(DateTime p_Dob)
        {
            // Method to Calculate age from Date of Birth in C#
            DateTime Today = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(p_Dob).Ticks).Year - 1;
            DateTime PastYearDate = p_Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Today)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Today)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Today.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Today.Subtract(PastYearDate).Hours;
            int Minutes = Today.Subtract(PastYearDate).Minutes;
            int Seconds = Today.Subtract(PastYearDate).Seconds;
            return Years + "_" + Months;
            //    String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            //Years, Months, Days, Hours, Seconds);
        }
        public static List<SelectListItem> GetMonthList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            for (int i = 0; i <= 11; i++)
            {
                list.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            return list.ToList();
        }
        public static List<SelectListItem> GetYearList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            DateTime dt = DateTime.Now;
            for (int i = 0; i <= 19; i++) //ToDo: Sunil - Change to 17 years after all backlog entry
            {
                // dt = dt.AddYears(-1);
                var year = i; //dt.Year;
                list.Add(new SelectListItem { Value = year.ToString(), Text = year.ToString() });
            }
            return list.ToList();
        }
        //public static List<SelectListItem> GetFinYear(bool isAddedSelect = true)
        //{
        //    List<SelectListItem> listItems = new List<SelectListItem>();
        //    try
        //    {
        //        if (HttpContext.Current.User.Identity.IsAuthenticated)
        //        {
        //            if (DateTime.Now.Month == 1 || DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
        //                listItems = new SelectList(dbe.Year_Master, "Year", "FinYear", DateTime.Now.Year - 1).OrderBy(x => x.Text).ToList();
        //            else
        //                listItems = new SelectList(dbe.Year_Master, "Year", "FinYear", DateTime.Now.Year).OrderBy(x => x.Text).ToList();
        //            if (isAddedSelect)
        //            {
        //                listItems.Insert(0, new SelectListItem { Value = "-1", Text = "Select" });
        //            }
        //            return listItems;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return listItems;
        //}
        #endregion

        public static List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "0", Text = "Select" });
            list.Add(new SelectListItem { Value = "1", Text = "Bodh Credential" });
            list.Add(new SelectListItem { Value = "2", Text = "Studies and Papers" });
            return list.OrderBy(x => Convert.ToInt16(x.Value)).ToList();
        }

        public static int SendMailForUser(ContactModel model)
        {
            Bodh_DBEntities _db = new Bodh_DBEntities();
            string To = "abhanot@pciadvisory.com", Subject = "BODH Inquiry";
            string OtherEmailID = "";
            string bodydata = string.Empty;
            string bodyTemplate = string.Empty;
            Guid AssessmentScheduleId_pk = Guid.Empty;
            Guid ParticipantId = Guid.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Views/Shared/MailTemplate.html")))
            {
                bodyTemplate = reader.ReadToEnd();
            }
            try
            {
                bodydata = bodyTemplate.Replace("{Dearusername}", "Bodh Inquiry")
                    .Replace("{bodytext}", model.Comment)
                    .Replace("{Name}", model.Name)
                    .Replace("{MobileNo}", model.MobileNo)
                    .Replace("{EmailID}", model.EmailId);
                MailMessage mail = new MailMessage();
                //mail.To.Add("bindu@careindia.org");
                OtherEmailID = !string.IsNullOrWhiteSpace(OtherEmailID) ? "," + OtherEmailID : null;
                mail.To.Add(To + OtherEmailID);
                mail.From = new MailAddress("bodh.pci@gmail.com", "BODH Inquiry");
                mail.Subject = Subject;// + " ( " + SenderName + " )";

                //bodydata = bodyTemplate.Replace("{bodytext}", Body);
                mail.Body = bodydata;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("bodh.pci@gmail.com", "nhsizqldyzssklpv");// yklz eazk tmkn vcbu//Pasw-Care@321 // Enter seders User name and password       
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return 1;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;    
                return 0;
            }
        }

        //public static List<SelectListItem> GetModularMaster1112(bool isAddedSelect = true)
        //{
        //    List<SelectListItem> listItems = new List<SelectListItem>();
        //    try
        //    {
        //        if (HttpContext.Current.User.Identity.IsAuthenticated)
        //        {
        //            listItems = new SelectList(dbe.ModularSessionMasters.Where(x => x.Cohort == 3 && x.IsActive == true), "ID", "COHORT_Session_Hindi").OrderBy(x => Convert.ToInt32(x.Value)).ToList();
        //            if (listItems != null)
        //            {
        //                if (isAddedSelect)
        //                {
        //                    listItems.Insert(0, new SelectListItem { Value = "-1", Text = "Select" });
        //                }
        //            }
        //            return listItems;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return listItems;
        //}
    }
}