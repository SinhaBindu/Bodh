using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bodh.Models
{
    public class ContactModel
    {
        public ContactModel()
        {
            Id = Guid.Empty;
        }
        public System.Guid Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("EmailID")]
        public string EmailId { get; set; }
        [Required]
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        [Required]
        [DisplayName("Comment")]
        public string Comment { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsSentMail { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}