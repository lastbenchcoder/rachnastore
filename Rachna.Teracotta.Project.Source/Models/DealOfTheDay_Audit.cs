using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class DealOfTheDay_Audit
    {
        [Key]
        [Column("deal_audit_id")]
        public int Deal_Audit_Id { get; set; }
        [Column("deal_id")]
        public int Deal_Id { get; set; }
        [MaxLength(50)]
        [Column("deal_code")]
        public string Deal_Code { get; set; }
        [Column("product_id")]
        public int Product_Id { get; set; }
        [Column("admin_id")]
        public int Administrators_Id { get; set; }
        [Column("deal_price")]
        public decimal Deal_Price { get; set; }
        [Column("deal_starts_from")]
        public DateTime Deal_Starts_From { get; set; }
        [Column("datecreated")]
        public DateTime Deal_CreatedDate { get; set; }
        [Column("dateupdated")]
        public DateTime Deal_UpdatedDate { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}