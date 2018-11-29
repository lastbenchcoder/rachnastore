using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class AdminActivity
    {
        [Key]
        [Column("activity_id")]
        public int ActivityId { get; set; }
        [Column("admin_id")]
        public int Administrators_Id { get; set; }
        [MaxLength(50)]
        [Column("ip_address")]
        public string Ip_Address { get; set; }
        [MaxLength(50)]
        [Column("category")]
        public string Category { get; set; }
        [MaxLength(500)]
        [Column("description")]
        public string Description { get; set; }
        [Column("datecreated")]
        public DateTime Activity_CreatedDate { get; set; }
        [Column("dateupdated")]
        public DateTime Activity_UpdatedDate { get; set; }
        [NotMapped]
        public string ErrorMessage { get; internal set; }

        public Administrators Administrators { get; set; }
    }
}