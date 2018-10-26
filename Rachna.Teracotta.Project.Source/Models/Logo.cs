using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Logo
    {
        [Key]
        public int Logo_Id { get; set; }
        [MaxLength(50)]
        public string LogoCode { get; set; }
        [MaxLength(300)]
        public string Logo_Title { get; set; }
        [MaxLength(1000)]
        public string Logo_Description { get; set; }
        [MaxLength(300)]
        public string Logo_Banner { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Logo_CreatedDate { get; set; }
        public DateTime Logo_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Logo_Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Administrators { get; set; }
    }
}