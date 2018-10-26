using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class CustomerAddress_Audit
    {
        [Key]
        public int CustomerAddress_Audit_Id { get; set; }
        public int CustomerAddress_Id { get; set; }
        public int Customer_Id { get; set; }
        [MaxLength(50)]
        public string CustomerAddress_Code { get; set; }
        [MaxLength(450)]
        public string Customer_AddressLine1 { get; set; }
        [MaxLength(450)]
        public string Customer_AddressLine2 { get; set; }
        [MaxLength(250)]
        public string CustomerAddress_LandMark { get; set; }
        [MaxLength(250)]
        public string CustomerAddress_City { get; set; }
        [MaxLength(250)]
        public string CustomerAddress_State { get; set; }
        [MaxLength(250)]
        public string CustomerAddress_Country { get; set; }
        [MaxLength(50)]
        public string CustomerAddress_ZipCode { get; set; }
        public DateTime CustomerAddress_DateCreated { get; set; }
        public DateTime CustomerAddress_DateUpdated { get; set; }
        [MaxLength(50)]
        public string CustomerAddress_Status { get; set; }
        [MaxLength(50)]
        public string Action { get; set; }
    }
}