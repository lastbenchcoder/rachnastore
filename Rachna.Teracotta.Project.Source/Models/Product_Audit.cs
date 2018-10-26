
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Product_Audit
    {
        [Key]
        public int Product_Audit_Id { get; set; }
        public int Product_Id { get; set; }
        public int Store_Id { get; set; }
        public int SubCategory_Id { get; set; }
        [MaxLength(50)]
        public string ProductCode { get; set; }
        [MaxLength(200)]
        public string Product_Title { get; set; }
        public string Product_Description { get; set; }
        public string Product_Specification { get; set; }
        public int Product_Qty { get; set; }
        public int Product_Qty_Alert { get; set; }
        public decimal Product_Mkt_Price { get; set; }
        public decimal Product_Our_Price { get; set; }
        public decimal Product_ShippingCharge { get; set; }
        public decimal Product_Discount { get; set; }
        public int Product_Delivery_Time { get; set; }
        public int Product_Max_Purchase { get; set; }
        public Boolean Product_Has_Size { get; set; }
        [MaxLength(100)]
        public string Product_Size { get; set; }
        [MaxLength(450)]
        public string Product_Avail_ZipCode { get; set; }
        public int Administrators_Id { get; set; }
        public DateTime Product_CreatedDate { get; set; }
        public DateTime Product_UpdatedDate { get; set; }
        [MaxLength(15)]
        public string Product_Status { get; set; }
        public string Action { get; set; }
    }
}
