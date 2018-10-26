using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class AdminChatting
    {
        [Key]
        public int Admin_Chatting_Id { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(450)]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [NotMapped]
        public string ErrorMessage;

        public Administrators Administrators { get; set; }
    }
}