using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class CustomerSearchKey_Audit
    {
        [Key]
        public int SearchKey_Audit_Id { get; set; }
        public int SearchKeyId { get; set; }
        [MaxLength(500)]
        public string SearchKey { get; set; }
        [MaxLength(100)]
        public string IpAddress { get; set; }
        public DateTime DateCreated { get; set; }
    }
}