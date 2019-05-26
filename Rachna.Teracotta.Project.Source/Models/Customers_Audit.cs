using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_customer_audit")]
    public class Customers_Audit
    {
        [Key]
        [Column("customer_audit_id")]
        public int Customers_Audit_Id { get; set; }

        [Column("customer_id")]
        public int Customer_Id { get; set; }

        [MaxLength(50)]
        [Column("customer_code")]
        public string CustomerCode { get; set; }

        [MaxLength(50)]
        [Column("type")]
        public string CustomerType { get; set; }

        [MaxLength(200)]
        [Column("fullname")]
        public string Customers_FullName { get; set; }

        [MaxLength(300)]
        [Column("emailid")]
        public string Customers_EmailId { get; set; }

        [MaxLength(15)]
        [Column("phone")]
        public string Customers_Phone { get; set; }

        [MaxLength(450)]
        [Column("description")]
        public string Customers_Description { get; set; }

        [MaxLength(450)]
        [Column("photo")]
        public string Customers_Photo { get; set; }

        [MaxLength(50)]
        [Column("password")]
        public string Customers_Password { get; set; }

        [MaxLength(15)]
        [Column("status")]
        public string Customers_Status { get; set; }

        [Column("datecreated")]
        public DateTime Customers_CreatedDate { get; set; }

        [Column("dateupdated")]
        public DateTime Customers_UpdatedDate { get; set; }

        [Column("login_attempt")]
        public int Customers_Login_Attempt { get; set; }

        [Column("is_mail_verified")]
        public int IsEmailVerified { get; set; }

        [MaxLength(50)]
        [Column("mode")]
        public string Mode { get; set; }
    }
}