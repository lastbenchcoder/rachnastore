using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class OrderDelivery_Audit
    {
        [Key]
        public int Order_Delivery_Audit_Id { get; set; }
        public int Order_Delivery_Id { get; set; }
        public int Order_Id { get; set; }
        public int TeamId { get; set; }
        public int Administrators_Id { get; set; }
        public int Store_Id { get; set; }
        public int Customer_Id { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public Order Order { get; set; }
        public Stores Stores { get; set; }
        public Customers Customers { get; set; }
        public Administrators Administrators { get; set; }
        public DeleveryTeam DeleveryTeam { get; set; }
    }
}