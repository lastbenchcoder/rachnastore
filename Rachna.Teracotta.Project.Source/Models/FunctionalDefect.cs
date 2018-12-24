using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class FunctionalDefect
    {
        [Key]
        public int Defect_Id { get; set; }
        public int Administrators_Id { get; set; }
        public int Function_Id { get; set; }
        [MaxLength(50)]
        public string FunctionalityDefectCode { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Resolver_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FixDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; internal set; }

        public Functionality Functionality { get; set; }
        public Administrators Administrators { get; set; }
        public ICollection<FunctionalDefectStory> FunctionalDefectStory { get; set; }
        [NotMapped]
        public Administrators Resolver { get; set; }
    }
}