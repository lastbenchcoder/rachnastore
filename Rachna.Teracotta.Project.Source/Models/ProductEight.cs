using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class ProductEight
    {
        [Key]
        public int Product_Eight_Id { get; set; }        
        public int Product_Id { get; set; }
        [MaxLength(50)]
        public string Product_Eight_Code { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Product_Eight_CreatedDate { get; set; }
        public DateTime Product_Eight_UpdatedDate { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Admin { get; set; }
        public Product Product { get; set; }
    }
}