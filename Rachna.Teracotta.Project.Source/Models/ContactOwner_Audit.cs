using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class ContactOwner_Audit
    {
        [Key]
        public int Contact_Owner_Audit_Id { get; set; }
        public int Contact_Owner_Id { get; set; }
        [MaxLength(50)]
        public string Contact_Owner_Code { get; set; }
        [MaxLength(300)]
        public string Contact_Title { get; set; }
        [MaxLength(1000)]
        public string Contact_Description { get; set; }
        [MaxLength(300)]
        public string Contact_Address { get; set; }
        [MaxLength(100)]
        public string Contact_City { get; set; }
        [MaxLength(100)]
        public string Contact_State { get; set; }
        public int Contact_ZipCode { get; set; }
        [MaxLength(100)]
        public string Contact_EmailId { get; set; }
        [MaxLength(15)]
        public string Contact_Phone { get; set; }
        [MaxLength(15)]
        public string Contact_Fax { get; set; }
        [MaxLength(100)]
        public string Contact_WebSite { get; set; }
        [MaxLength(300)]
        public string Contact_GoogleMapURL { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Contact_CreatedDate { get; set; }
        public DateTime Contact_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Contact_Status { get; set; }
        [MaxLength(1)]
        public string Contact_Query_Submission { get; set; }
    }
}