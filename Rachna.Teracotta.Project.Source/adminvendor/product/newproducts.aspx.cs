﻿using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.adminvendor.product
{
    public partial class newproducts : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public newproducts()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : New Product";
            List<SubCategories> _subCategoryList = context.SubCategory.Include("Category").Where(m => m.SubCategory_Status == eStatus.Active.ToString()).ToList();
            foreach (var item in _subCategoryList)
            {
                ddlCategory.Items.Add(new ListItem { Text = item.SubCategory_Title + "(" + item.Category.Category_Title + ")", Value = item.SubCategory_Id.ToString() });
            }
        }

        protected void btnProceedToSubmit_Click(object sender, EventArgs e)
        {
            int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString());
            Administrators _admin = context.Administrator.ToList().Where(m => m.Administrators_Id == AdminId).FirstOrDefault();

            Product Product = new Product()
            {
                Store_Id = _admin.Store_Id,
                Product_Title = txtTitle.Text,
                Product_Description = txtDescription.Content,
                Product_Specification = txtSpecification.Content,
                Administrators_Id = _admin.Administrators_Id,
                Product_Qty = Convert.ToInt32(txtQuantity.Text),
                Product_Qty_Alert = Convert.ToInt32(txtAlert.Text),
                Product_Delivery_Time = Convert.ToInt32(txtProductDelieveredIn.Text),
                Product_Max_Purchase = Convert.ToInt32(txtMaxPurchase.Text),
                Product_Mkt_Price = Convert.ToDecimal(txtMarketPrice.Text),
                Product_Our_Price = Convert.ToDecimal(txtOurPrice.Text),
                Product_ShippingCharge = Convert.ToDecimal(txtShippingCharge.Text),
                Product_Has_Size = (rdbHasSize.SelectedValue == "Yes") ? true : false,
                Product_Size = (rdbHasSize.SelectedValue == "Yes") ? txtSize.Text : "No Size",
                Product_Avail_ZipCode = (txtZipcode.Text != "") ? txtZipcode.Text : "0",
                Product_Discount = Convert.ToDecimal(txtDiscount.Text),
                SubCategory_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                Product_CreatedDate = DateTime.Now,
                Product_UpdatedDate = DateTime.Now,
                Product_Status = eProductStatus.ReviewPending.ToString(),
                Store_Rating = (txtRating.Text != "") ? Convert.ToInt32(txtRating.Text) : 1
            };

            int maxAdminId = 1;
            if (context.Product.ToList().Count > 0)
                maxAdminId = context.Product.Max(m => m.Product_Id);
            maxAdminId = (maxAdminId == 1 && context.Product.ToList().Count > 0) ? (maxAdminId + 1) : maxAdminId;
            Product.ProductCode = "PRDTRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
            context.Product.Add(Product);
            context.SaveChanges();

            ProductHelper.CreateProductFlow(Product.Product_Id, Product.Product_Title, _admin.Administrators_Id, _admin.FullName, "New Product Created and Pending for Review", Product.Product_Status);

            ProductBanners ProductBanner = new ProductBanners()
            {
                Product_Id = Product.Product_Id,
                Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString()),
                Product_Banner_Default = 1,
                Product_Banner_Photo = "content/noimage.png",
                Product_Banner_CreatedDate = DateTime.Now,
                Product_Banner_UpdatedDate = DateTime.Now
            };

            int maxBnrAdminId = 1;
            if (context.ProductBanner.ToList().Count > 0)
                maxAdminId = context.ProductBanner.Max(m => m.Product_Id);
            Product.ProductCode = "PRDBNRTRACH" + maxBnrAdminId + "TERA" + (maxBnrAdminId + 1);
            context.ProductBanner.Add(ProductBanner);
            context.SaveChanges();

            Response.Redirect("/adminvendor/product/productsdetailstatic.aspx?SavePrdId=1000&Productid=" + Product.Product_Id);
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal discGiven = Convert.ToDecimal(txtDiscount.Text);
            if (discGiven == 0)
            {
                txtOurPrice.Text = txtMarketPrice.Text;
            }
            else
            {
                if (discGiven >= 100 && discGiven < 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Discount value should be 0 - 100)');", true);
                }
                else
                {
                    int discount = (Convert.ToInt32(txtMarketPrice.Text) * Convert.ToInt32(txtDiscount.Text)) / 100;
                    decimal ourprice = Convert.ToInt32(txtMarketPrice.Text) - discount;
                    txtOurPrice.Text = ourprice.ToString();
                }
            }
        }

        protected void rdbHasSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbHasSize.SelectedValue == "Yes")
            {
                pnlSize.Visible = true;
            }
            else
            {
                pnlSize.Visible = false;
            }
        }
    }
}