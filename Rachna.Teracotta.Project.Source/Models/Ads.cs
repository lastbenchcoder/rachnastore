using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Ads
    {
        [Key]
        public int Ads_Id { get; set; }
        [MaxLength(50)]
        public string AdsCode { get; set; }
        [MaxLength(100)]
        public string Ads_Type { get; set; }
        [MaxLength(500)]
        public string Ads_Banner_Or_Source { get; set; }
        [MaxLength(500)]
        public string Ads_RedirectUrl { get; set; }
        public DateTime Ads_CreatedDate { get; set; }
        public DateTime Ads_UpdatedDate { get; set; }
        public int Administrators_Id { get; set; }
        [NotMapped]
        public string ErrorMessage { get; internal set; }

        public Administrators Administrators { get; set; }        
    }
}