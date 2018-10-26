using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class DeliveryMethod
    {
        [Key]
        public int DeliveryMethod_Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; internal set; }

    }
}