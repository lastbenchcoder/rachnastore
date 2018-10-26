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
        public int Audit_Store_Id { get; set; }
        public int Store_Id { get; set; }
        [MaxLength(50)]
        public string StoreCode { get; set; }
        [MaxLength(200)]
        public string Store_Name { get; set; }
        [MaxLength(450)]
        public string Store_Url { get; set; }
        [MaxLength(450)]
        public string Store_Logo { get; set; }
        public DateTime Store_CreatedDate { get; set; }
        public DateTime Store_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Store_Status { get; set; }
        public string Action { get; set; }
        public string DataUser { get; set; }
    }
}