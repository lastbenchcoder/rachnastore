using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Stores_Audit
    {
        [Key]
        [Column("store_audit_id")]
        public int Audit_Store_Id { get; set; }
        [Column("store_id")]
        public int Store_Id { get; set; }
        [MaxLength(50)]
        [Column("store_code")]
        public string StoreCode { get; set; }
        [MaxLength(200)]
        [Column("name")]
        public string Store_Name { get; set; }
        [MaxLength(450)]
        [Column("description")]
        public string Store_Description { get; set; }
        [MaxLength(450)]
        [Column("url")]
        public string Store_Url { get; set; }
        [MaxLength(450)]
        [Column("banner")]
        public string Store_Logo { get; set; }
        [Column("datecreated")]
        public DateTime Store_CreatedDate { get; set; }
        [Column("dateupdated")]
        public DateTime Store_UpdatedDate { get; set; }
        [MaxLength(15)]
        [Column("status")]
        public string Store_Status { get; set; }
    }
}