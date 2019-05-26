using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_customer_address_audit")]
    public class CustomerAddress_Audit
    {
        [Key]
        [Column("customer_address_audit_id")]
        public int CustomerAddress_Audit_Id { get; set; }

        [Column("customer_address_id")]
        public int CustomerAddress_Id { get; set; }

        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [MaxLength(50)]
        [Column("customer_address_code")]
        public string CustomerAddress_Code { get; set; }

        [MaxLength(450)]
        [Column("address_line1")]
        public string Customer_AddressLine1 { get; set; }

        [MaxLength(450)]
        [Column("address_line2")]
        public string Customer_AddressLine2 { get; set; }

        [MaxLength(250)]
        [Column("land_mark")]
        public string CustomerAddress_LandMark { get; set; }

        [MaxLength(250)]
        [Column("city")]
        public string CustomerAddress_City { get; set; }

        [MaxLength(250)]
        [Column("state")]
        public string CustomerAddress_State { get; set; }

        [MaxLength(250)]
        [Column("country")]
        public string CustomerAddress_Country { get; set; }

        [MaxLength(50)]
        [Column("zipcode")]
        public string CustomerAddress_ZipCode { get; set; }

        [Column("datecreated")]
        public DateTime CustomerAddress_DateCreated { get; set; }

        [Column("dateupdated")]
        public DateTime CustomerAddress_DateUpdated { get; set; }

        [MaxLength(50)]
        [Column("status")]
        public string CustomerAddress_Status { get; set; }

        [MaxLength(50)]
        [Column("mode")]
        public string Mode { get; set; }
    }
}