using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_cart")]
    public class Carts
    {
        [Key]
        [Column("cart_id")]
        public int Cart_Id { get; set; }

        [MaxLength(50)]
        [Column("cart_code")]
        public string CartCode { get; set; }

        [Column("store_id")]
        public int Store_Id { get; set; }

        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [MaxLength(100)]
        [Column("customer_name")]
        public string Customer_Name { get; set; }

        [MaxLength(50)]
        [Column("customer_ip_address")]
        public string Ip_Address { get; set; }

        [Column("product_id")]
        public int Product_Id { get; set; }

        [MaxLength(200)]
        [Column("product_title")]
        public string Product_Title { get; set; }

        [MaxLength(450)]
        [Column("product_banner")]
        public string Product_Banner { get; set; }

        [Column("product_price")]
        public decimal Product_Price { get; set; }

        [Column("cart_qty")]
        public int Cart_Qty { get; set; }

        [Column("cart_price")]
        public decimal Cart_Price { get; set; }

        [Column("shipping_charge")]
        public decimal Shipping_Charge { get; set; }

        [Column("cart_total_price")]
        public decimal Cart_Total_Price { get; set; }

        [MaxLength(50)]
        [Column("cart_size")]
        public string Cart_Size { get; set; }

        [MaxLength(15)]
        [Column("status")]
        public string Cart_Status { get; set; }

        [Column("datecreated")]
        public DateTime DateCreated { get; set; }

        [Column("dateupdated")]
        public DateTime DateUpdated { get; set; }

        [NotMapped]
        public string ErrorMessage { get; set; }

        public Customers Customer { get; set; }
        public Administrators Administrators { get; set; }
        public Product Products { get; set; }
    }
}