using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class ProductFlow
    {
        [Key]
        public int Product_Flow_Id { get; set; }
        public int Product_Id { get; set; }
        [MaxLength(50)]
        public string ProductFlowCode { get; set; }
        [MaxLength(450)]
        public string Product_Title { get; set; }
        [MaxLength(450)]
        public string Product_Flow_Detail { get; set; }
        public DateTime Product_Flow_CreatedDate { get; set; }
        [MaxLength(50)]
        public string Product_Status { get; set; }
        [MaxLength(450)]
        public string Product_Flow_CreatedBy { get; set; }
        public int Administrators_Id { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Admin { get; set; }
        public Product Product { get; set; }
    }
}