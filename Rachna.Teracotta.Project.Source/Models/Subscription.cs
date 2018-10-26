using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Subscription
    {
        [Key]
        [Column(Order = 0)]
        public int Subscription_Id { get; set; }
        [MaxLength(500)]
        [Column(Order = 1)]
        public string Subscription_EmailId { get; set; }
        [MaxLength(50)]
        [Column(Order = 2)]
        public string Subscription_Status { get; set; }
        [Column(Order = 3)]
        public DateTime Subscription_CreatedDate { get; set; }
        [Column(Order = 4)]
        public DateTime Subscription_UpdatedDate { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}