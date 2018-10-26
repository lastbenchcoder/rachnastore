using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Categories_Audit
    {
        [Key]
        public int Categories_Audit_Id { get; set; }
        public int Category_Id { get; set; }
        [MaxLength(50)]
        public string CategoryCode { get; set; }
        [MaxLength(200)]
        public string Category_Title { get; set; }
        [MaxLength(450)]
        public string Category_Description { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Category_CreatedDate { get; set; }
        public DateTime Category_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Category_Status { get; set; }
        public string Action { get; set; }
    }
}
