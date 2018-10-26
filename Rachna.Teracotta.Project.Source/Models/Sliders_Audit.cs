using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Sliders_Audit
    {
        [Key]
        public int Slider_Audit_Id { get; set; }
        public int Slider_Id { get; set; }
        [MaxLength(50)]
        public string Slider_Code { get; set; }
        [MaxLength(200)]
        public string Slider_TItle { get; set; }
        [MaxLength(450)]
        public string Slider_Photo { get; set; }
        [MaxLength(450)]
        public string Slider_RedirectUrl { get; set; }
        public DateTime Slider_CreatedDate { get; set; }
        public DateTime Slider_UpdatedDate { get; set; }
        public int Administrators_Id { get; set; }
        public string Action { get; internal set; }
    }
}