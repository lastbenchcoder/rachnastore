using System;
using System.ComponentModel.DataAnnotations;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Administrators_Audit
    {
        [Key]
        public int Audit_Administrators_Id { get; set; }
        public int Administrators_Id { get; set; }
        public int Invitation_Id { get; set; }
        public int Store_Id { get; set; }
        [MaxLength(50)]
        public string AdminCode { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(300)]
        public string EmailId { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        [MaxLength(450)]
        public string Photo { get; set; }
        [MaxLength(15)]
        public string Password { get; set; }
        [MaxLength(15)]
        public string Admin_Status { get; set; }
        public string Admin_Role { get; set; }
        public DateTime Admin_CreatedDate { get; set; }
        public DateTime Admin_UpdatedDate { get; set; }
        public int Admin_Login_Attempt { get; set; }
        public string Action { get; set; }
        [MaxLength(500)]
        public string DataUser { get; set; }
    }
}
