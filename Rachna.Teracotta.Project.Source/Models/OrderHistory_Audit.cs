using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class OrderHistory_Audit
    {
        [Key]
        public int OrderHistory_Audit_Id { get; set; }
        public int OrderHistory_Id { get; set; }
        public int Order_Id { get; set; }
        public string OrderHistory_Status { get; set; }
        public string OrderHistory_Description { get; set; }
        public DateTime OrderHistory_CreatedDate { get; set; }
        public DateTime OrderHistory_UpdatedDate { get; set; }
        public int Administrators_Id { get; set; }
        public int Store_Id { get; set; }
    }
}