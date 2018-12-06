using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class CustomerRequest
    {
        [Key]
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
    }
}