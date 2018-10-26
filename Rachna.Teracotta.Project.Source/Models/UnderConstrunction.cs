using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class UnderConstrunction
    {
        [Key]
        public int UnderConst_Id { get; set; }
        [MaxLength(50)]
        public string UnderConstCode { get; set; }
        [MaxLength(300)]
        public string UnderConst_Title { get; set; }
        [MaxLength(1000)]
        public string UnderConst_Description { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime UnderConst_CreatedDate { get; set; }
        public DateTime UnderConst_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string UnderConst_Status { get; set; }
        [MaxLength(15)]
        public string UnderConst_DispInstHmpPage { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Administrators { get; set; }
    }
}