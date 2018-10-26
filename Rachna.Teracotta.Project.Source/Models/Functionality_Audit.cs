using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Functionality_Audit
    {
        [Key]
        public int Function_Audit_Id { get; set; }
        [MaxLength(50)]
        public string FunctionCode { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public int Developer_Id { get; set; }
    }
}