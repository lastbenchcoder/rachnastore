using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class SubCategories_Audit
    {
        [Key]
        public int SubCategories_Audit_Id { get; set; }
        public int SubCategory_Id { get; set; }
        [MaxLength(50)]
        public string SubCategoryCode { get; set; }
        [MaxLength(200)]
        public string SubCategory_Title { get; set; }
        [MaxLength(450)]
        public string SubCategory_Description { get; set; }
        public int Administrators_Id { get; set; }
        public int Category_Id { get; set; }
        public DateTime SubCategory_CreatedDate { get; set; }
        public DateTime SubCategory_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string SubCategory_Status { get; set; }
        public string Action { get; set; }
    }
}
