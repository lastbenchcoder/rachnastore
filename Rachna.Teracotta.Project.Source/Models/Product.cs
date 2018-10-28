
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Product_Id { get; set; }
        [Column("store_id")]
        public int Store_Id { get; set; }
        [Column("subcategory_id")]
        public int SubCategory_Id { get; set; }
        [MaxLength(50)]
        [Column("product_code")]
        public string ProductCode { get; set; }
        [MaxLength(200)]
        [Column("title")]
        public string Product_Title { get; set; }
        [Column("description")]
        public string Product_Description { get; set; }
        [Column("specification")]
        public string Product_Specification { get; set; }
        [Column("qty")]
        public int Product_Qty { get; set; }
        [Column("alert_qty")]
        public int Product_Qty_Alert { get; set; }
        [Column("mkt_price")]
        public decimal Product_Mkt_Price { get; set; }
        [Column("our_price")]
        public decimal Product_Our_Price { get; set; }
        [Column("shipping_charge")]
        public decimal Product_ShippingCharge { get; set; }
        [Column("discount")]
        public decimal Product_Discount { get; set; }
        [Column("delievered_on")]
        public int Product_Delivery_Time { get; set; }
        [Column("max_purchase")]
        public int Product_Max_Purchase { get; set; }
        [Column("has_sizes")]
        public bool Product_Has_Size { get; set; }
        [MaxLength(100)]
        [Column("sizes")]
        public string Product_Size { get; set; }
        [MaxLength(450)]
        [Column("zipcodes")]
        public string Product_Avail_ZipCode { get; set; }
        [Column("store_rating")]
        public int Store_Rating { get; set; }
        [Column("admin_id")]
        public int Administrators_Id { get; set; }
        [Column("datecreated")]
        public DateTime Product_CreatedDate { get; set; }
        [Column("dateupdated")]
        public DateTime Product_UpdatedDate { get; set; }
        [MaxLength(15)]
        [Column("status")]
        public string Product_Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Stores Store { get; set; }
        public SubCategories SubCategory { get; set; }        
        public Administrators Admin { get; set; }
        public ICollection<ProductBanners> ProductBanner { get; set; }
        public ICollection<ProductFlow> ProductFlow { get; set; }
        public ICollection<Carts> Cart { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<ProdComments> ProdComments { get; set; }
    }
}
