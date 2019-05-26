using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_customer_request_audit")]
    public class CustomerRequest_Audit
    {
        [Key]
        [Column("cus_req_audit_id")]
        public int Customer_Request_Audit_Id { get; set; }

        [Column("cus_req_id")]
        public int Customer_Request_Id { get; set; }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("emailid")]
        public string EmailId { get; set; }

        [Column("subject")]
        public string Subject { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("ipaddress")]
        public string IpAddress { get; set; }

        [Column("datecreated")]
        public DateTime DateCreated { get; set; }

        [Column("dateupdated")]
        public DateTime DateUpdated { get; set; }

        [MaxLength(50)]
        [Column("mode")]
        public string Mode { get; set; }
    }
}