using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class MetaInformation
    {
        [Key]
        public int Meta_Id { get; set; }
        [MaxLength(50)]
        public string Meta_Code { get; set; }
        [MaxLength(200)]
        public string Meta_Title { get; set; }
        [MaxLength(300)]
        public string Meta_Description { get; set; }
        [MaxLength(300)]
        public string Meta_KeyWords { get; set; }
        public DateTime Meta_CreatedDate { get; set; }
        public DateTime Meta_UpdatedDate { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(15)]
        public string Meta_Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; internal set; }

        public Administrators Administrators { get; set; }
    }
}