using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        [MaxLength(50)]
        public string Order_Code { get; set; }
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Payment_Method_Id { get; set; }
        public int CustomerAddress_Id { get; set; }
        public int Order_Qty { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Order_Price { get; set; }
        [MaxLength(50)]
        public string Order_Size { get; set; }
        [MaxLength(50)]
        public string Order_Status { get; set; }
        [MaxLength(450)]
        public string Product_Banner { get; set; }
        [MaxLength(200)]
        public string Product_Title { get; set; }
        [MaxLength(100)]
        public string Customer_Name { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Order_UpdateDate { get; set; }
        public DateTime Order_Delievery_Date { get; set; }
        public int Store_Id { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Customers Customer { get; set; }
        public Stores Stores { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public Product Products { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<OrderHistory> OrderHistory { get; set; }
    }
}