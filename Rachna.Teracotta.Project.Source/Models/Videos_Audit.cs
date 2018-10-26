using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Videos_Audit
    {
        [Key]
        public int Video_Audit_Id { get; set; }
        public int Video_Id { get; set; }
        public int Product_Id { get; set; }
        public int SubCategory_Id { get; set; }
        [MaxLength(200)]
        public string Video_Title { get; set; }
        [MaxLength(450)]
        public string Video_Description { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Video_CreatedDate { get; set; }
        public DateTime Video_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Video_Status { get; set; }
    }
}