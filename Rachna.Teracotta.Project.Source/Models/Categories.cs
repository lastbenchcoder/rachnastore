using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_category")]
    public class Categories
    {
        [Key]
        [Column("category_id")]
        public int Category_Id { get; set; }

        [MaxLength(50)]
        [Column("category_code")]
        public string CategoryCode { get; set; }

        [MaxLength(200)]
        [Column("title")]
        public string Category_Title { get; set; }

        [MaxLength(450)]
        [Column("banner")]
        public string Category_Photo { get; set; }

        [Column("admin_id")]
        public int Administrators_Id { get; set; }

        [Column("datecreated")]
        public DateTime Category_CreatedDate { get; set; }

        [Column("dateupdated")]
        public DateTime Category_UpdatedDate { get; set; }

        [MaxLength(15)]
        [Column("status")]
        public string Category_Status { get; set; }

        [NotMapped]
        public int TotalProducts { get; set; }

        [NotMapped]
        public string ErrorMessage { get; set; }


        public Administrators Admin { get; set; }
        public ICollection<SubCategories> SubCategory { get; set; }
    }
}
