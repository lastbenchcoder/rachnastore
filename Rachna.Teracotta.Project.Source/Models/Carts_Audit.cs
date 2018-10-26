using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Carts_Audit
    {
        [Key]
        public int Carts_Audit_Id { get; set; }
        public int Cart_Id { get; set; }
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Cart_Qty { get; set; }
        [MaxLength(50)]
        public string CartCode { get; set; }
        [MaxLength(50)]
        public string Ip_Address { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Cart_Price { get; set; }
        [MaxLength(50)]
        public string Cart_Size { get; set; }
        [MaxLength(15)]
        public string Cart_Status { get; set; }
        [MaxLength(450)]
        public string Product_Banner { get; set; }
        [MaxLength(200)]
        public string Product_Title { get; set; }
        [MaxLength(100)]
        public string Customer_Name { get; set; }
        public int Store_Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Action { get; set; }
    }
}