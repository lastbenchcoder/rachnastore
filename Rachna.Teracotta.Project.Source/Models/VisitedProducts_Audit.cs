using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class VisitedProducts_Audit
    {
        [Key]
        public int VisitedProducts_Audit_Id { get; set; }
        public int VisitedProductsId { get; set; }
        public int Product_Id { get; set; }
        public int Store_Id { get; set; }
        [MaxLength(300)]
        public string ProductTitle { get; set; }
        [MaxLength(500)]
        public string ProductBanner { get; set; }
        [MaxLength(100)]
        public string IpAddress { get; set; }
        public int VisitedCount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}