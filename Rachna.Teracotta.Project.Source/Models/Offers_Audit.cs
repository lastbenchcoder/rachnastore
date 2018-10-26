using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Offers_Audit
    {
        [Key]
        public int Offer_Audit_Id { get; set; }
        public int Offer_Id { get; set; }
        public int Category_Id { get; set; }
        public int Store_Id { get; set; }
        public int Product_Id { get; set; }
        public int Administrators_Id { get; set; }
        public int TotNumbers { get; set; }
        [MaxLength(50)]
        public string Offer_On { get; set; }
        [MaxLength(50)]
        public string Offer_Code { get; set; }
        [MaxLength(450)]
        public string Offer_Title { get; set; }
        public string Offer_Description { get; set; }
        [MaxLength(450)]
        public string Offer_Banner { get; set; }
        public DateTime Offer_CreatedDate { get; set; }
        public DateTime Offer_UpdateDate { get; set; }
        public DateTime Offer_StartsDate { get; set; }
        public DateTime Offer_EndDate { get; set; }
    }
}