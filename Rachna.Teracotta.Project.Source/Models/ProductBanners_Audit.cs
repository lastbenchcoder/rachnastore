using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class ProductBanners_Audit
    {
        [Key]
        public int Product_Banner_Audit_Id { get; set; }
        public int Product_Banner_Id { get; set; }
        public int Product_Id { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(50)]
        public string Product_BannerCode { get; set; }
        public int Product_Banner_Default { get; set; }
        [MaxLength(450)]
        public string Product_Banner_Photo { get; set; }
        public DateTime Product_Banner_CreatedDate { get; set; }
        public DateTime Product_Banner_UpdatedDate { get; set; }
    }
}
