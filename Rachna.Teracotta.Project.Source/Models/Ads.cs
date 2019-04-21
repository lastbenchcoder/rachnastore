﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_ads")]
    public class Ads
    {
        [Key]
        [Column("ads_id")]
        public int Ads_Id { get; set; }

        [MaxLength(50)]
        [Column("ads_code")]
        public string AdsCode { get; set; }

        [MaxLength(100)]
        [Column("type")]
        public string Ads_Type { get; set; }

        [MaxLength(500)]
        [Column("banner_source")]
        public string Ads_Banner_Or_Source { get; set; }

        [MaxLength(500)]
        [Column("redirect_url")]
        public string Ads_RedirectUrl { get; set; }

        [Column("datecreated")]
        public DateTime Ads_CreatedDate { get; set; }


        [Column("dateupdated")]
        public DateTime Ads_UpdatedDate { get; set; }

        [Column("admin_id")]
        public int Administrators_Id { get; set; }

        [NotMapped]
        public string ErrorMessage { get; internal set; }
        
        public Administrators Administrators { get; set; }        
    }
}