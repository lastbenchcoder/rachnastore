using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class ProdComments
    {
        [Key]
        public int Comment_Id { get; set; }
        public int Customer_Id { get; set; }
        [MaxLength(50)]
        public string CommentCode { get; set; }
        public int Product_Id { get; set; }
        public int Rating { get; set; }
        public int LikeUnlike { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(450)]
        public string Product_Banner { get; set; }
        [MaxLength(200)]
        public string Product_Title { get; set; }
        [MaxLength(100)]
        public string Customer_Name { get; set; }
        [MaxLength(50)]
        public string Comment_Status { get; set; }
        public int Store_Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Customers Customer { get; set; }
        public Product Products { get; set; }
        public Stores Stores { get; set; }
    }
}