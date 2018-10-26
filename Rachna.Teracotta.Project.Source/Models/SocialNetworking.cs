using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class SocialNetworking
    {
        [Key]
        public int Scl_Ntk_Id { get; set; }
        [MaxLength(50)]
        public string Scl_Ntk_Code { get; set; }
        [MaxLength(300)]
        public string Scl_Ntk_URL { get; set; }
        [MaxLength(300)]
        public string Scl_Ntk_Icon { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Scl_Ntk_CreatedDate { get; set; }
        public DateTime Scl_Ntk_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Scl_Ntk_Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Administrators { get; set; }
    }
}