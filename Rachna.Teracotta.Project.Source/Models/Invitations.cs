﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Invitations
    {
        [Key]
        public int Invitation_Id { get; set; }        
        [MaxLength(15)]
        public string Role { get; set; }
        public int Store_Id { get; set; }
        [MaxLength(50)]
        public string Invitation_Code { get; set; }
        [MaxLength(300)]
        public string Invitation_EmailId { get; set; }
        [MaxLength(15)]
        public string Invitation_Status { get; set; }
        public DateTime Invitation_CreatedDate { get; set; }
        public DateTime Invitation_UpdatedDate { get; set; }
        [NotMapped]
        public string Action { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Stores Store { get; set; }
    }
}