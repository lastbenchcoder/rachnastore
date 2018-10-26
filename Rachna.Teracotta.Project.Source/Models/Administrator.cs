
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Administrators
    {

        [Key]
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
