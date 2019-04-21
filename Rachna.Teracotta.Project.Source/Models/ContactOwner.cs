using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_contactus")]
    public class ContactOwner
    {
        [Key]
        [Column("contact_owner_id")]
        public int Contact_Owner_Id { get; set; }

        [MaxLength(50)]
        [Column("contact_owner_code")]
        public string Contact_Owner_Code { get; set; }

        [MaxLength(300)]
        [Column("title")]
        public string Contact_Title { get; set; }

        [MaxLength(1000)]
        [Column("description")]
        public string Contact_Description { get; set; }

        [MaxLength(300)]
        [Column("address")]
        public string Contact_Address { get; set; }

        [MaxLength(100)]
        [Column("city")]
        public string Contact_City { get; set; }

        [MaxLength(100)]
        [Column("state")]
        public string Contact_State { get; set; }

        [Column("zipcode")]
        public int Contact_ZipCode { get; set; }

        [MaxLength(100)]
        [Column("emailid")]
        public string Contact_EmailId { get; set; }

        [MaxLength(15)]
        [Column("phone")]
        public string Contact_Phone { get; set; }

        [MaxLength(15)]
        [Column("fax")]
        public string Contact_Fax { get; set; }

        [MaxLength(100)]
        [Column("website")]
        public string Contact_WebSite { get; set; }

        [MaxLength(300)]
        [Column("googlemapurl")]
        public string Contact_GoogleMapURL { get; set; }

        [Column("admin_id")]
        public int Administrators_Id { get; set; }

        [Column("datecreated")]
        public DateTime Contact_CreatedDate { get; set; }

        [Column("dateupdated")]
        public DateTime Contact_UpdatedDate { get; set; }

        [MaxLength(15)]
        [Column("status")]
        public string Contact_Status { get; set; }

        [MaxLength(1)]
        [Column("can_submit_query")]
        public string Contact_Query_Submission { get; set; }

        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Administrators { get; set; }
    }
}