
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_admin")]
    public class Administrators
    {
        [Key]
        [Column("admin_id")]
        public int Administrators_Id { get; set; }

        [Column("invitation_id")]
        public int Invitation_Id { get; set; }

        [Column("store_id")]
        public int Store_Id { get; set; }

        [MaxLength(50)]
        [Column("admin_code")]
        public string AdminCode { get; set; }

        [MaxLength(100)]
        [Column("fullname")]
        public string FullName { get; set; }

        [MaxLength(300)]
        [Column("emailid")]
        public string EmailId { get; set; }

        [MaxLength(50)]
        [Column("phone")]
        public string Phone { get; set; }

        [MaxLength(450)]
        [Column("description")]
        public string Description { get; set; }

        [MaxLength(450)]
        [Column("photo")]
        public string Photo { get; set; }

        [MaxLength(50)]
        [Column("password")]
        public string Password { get; set; }

        [MaxLength(15)]
        [Column("status")]
        public string Admin_Status { get; set; }

        [Column("role")]
        public string Admin_Role { get; set; }

        [Column("datecreated")]
        public DateTime Admin_CreatedDate { get; set; }

        [Column("dateupdated")]
        public DateTime Admin_UpdatedDate { get; set; }

        [Column("login_attempt")]
        public int Admin_Login_Attempt { get; set; }

        [Column("activity_mail")]
        public int Send_Activity_Mail{ get; set; }

        [NotMapped]
        public string ErrorMessage;

        public Invitations Invitations { get; set; }
        public Stores Store { get; set; }
        public ICollection<Categories> Category { get; set; }
        public ICollection<SubCategories> SubCategory { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<ProductBanners> ProductBanner { get; set; }
        public ICollection<Sliders> Slider { get; set; }
        public ICollection<ProductFlow> ProductFlow { get; set; }
        public ICollection<Functionality> Functionality { get; set; }
        public ICollection<FunctionalDefect> FunctionalDefect { get; set; }
        public ICollection<FunctionalDefectStory> FunctionalDefectStory { get; set; }
        public ICollection<AdminChatting> AdminChatting { get; set; }
    }
}
