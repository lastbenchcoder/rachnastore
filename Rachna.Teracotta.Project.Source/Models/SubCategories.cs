using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class SubCategories
    {
        [Key]
        public int SubCategory_Id { get; set; }
        [MaxLength(50)]
        public string SubCategoryCode { get; set; }
        [MaxLength(200)]
        public string SubCategory_Title { get; set; }
        public int Administrators_Id { get; set; }
        public int Category_Id { get; set; }
        public DateTime SubCategory_CreatedDate { get; set; }
        public DateTime SubCategory_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string SubCategory_Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Categories Category { get; set; }
        public Administrators Admin { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
