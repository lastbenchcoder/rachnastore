﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Customers
    {
        [Key]
        public int Customer_Id { get; set; }
        [MaxLength(50)]
        public string CustomerCode { get; set; }
        [MaxLength(50)]
        public string CustomerType { get; set; }
        [MaxLength(200)]
        public string Customers_FullName { get; set; }
        [MaxLength(300)]
        public string Customers_EmailId { get; set; }
        [MaxLength(15)]
        public string Customers_Phone { get; set; }
        [MaxLength(450)]
        public string Customers_Description { get; set; }
        [MaxLength(450)]
        public string Customers_Photo { get; set; }
        [MaxLength(15)]
        public string Customers_Password { get; set; }
        [MaxLength(15)]
        public string Customers_Status { get; set; }
        public DateTime Customers_CreatedDate { get; set; }
        public DateTime Customers_UpdatedDate { get; set; }
        public int Customers_Login_Attempt { get; set; }
        public int IsEmailVerified { get; set; }
        [NotMapped]
        public string ErrorMessage { get; internal set; }

        public ICollection<CustomerAddress> CustomerAddress { get; set; }
        public ICollection<Carts> Cart { get; set; }
        public ICollection<Order> Orders { get; set; }       
    }
}