using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class FunctionalDefectStory_Audit
    {
        [Key]
        public int FunctDefectStory_Audit_Id { get; set; }
        public int Defect_Id { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(500)]
        public string Banner { get; set; }
        public int Resolver_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FixDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}