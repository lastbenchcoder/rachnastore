using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
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

namespace Rachna.Teracotta.Project.Source.administration.product
{
    public partial class productsdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Productid"] != null)
            {
                if (!IsPostBack)
                {
                    string id = Request["Productid"].ToString();

                    hdnProductId.Value = id;
                    List<SubCategories> _subCategoryList = bSubCategory.List().Where(m => m.SubCategory_Status == eStatus.Active.ToString()).ToList();
                    foreach (var item in _subCategoryList)
                    {
                        ddlCategory.Items.Add(new ListItem { Text = item.SubCategory_Title + "(" + item.Category.Category_Title + ")", Value = item.SubCategory_Id.ToString() });
                    }
                    Product Product = bProduct.List().Where(m => m.Product_Id == Convert.ToInt32(id)).FirstOrDefault();
                    txtTitle.Text = Product.Product_Title;
                    ddlCategory.SelectedValue = Product.SubCategory_Id.ToString();
                    lblStatus.Text = Product.Product_Status;
                    txtDescription.Content = Product.Product_Description;
                    txtSpecification.Content = Product.Product_Specification;
                    txtQuantity.Text = Product.Product_Qty.ToString();
                    txtAlert.Text = Product.Product_Qty_Alert.ToString();
                    txtMarketPrice.Text = Math.Round(Product.Product_Mkt_Price).ToString();
                    txtOurPrice.Text = Math.Round(Product.Product_Our_Price).ToString();
                    txtShippingCharge.Text = Math.Round(Product.Product_ShippingCharge).ToString();
                    txtProductDelieveredIn.Text = Product.Product_Delivery_Time.ToString();
                    txtMaxPurchase.Text = Product.Product_Max_Purchase.ToString();
                    txtSize.Text = Product.Product_Size.ToString();
                    txtZipcode.Text = Product.Product_Avail_ZipCode.ToString();
                    txtDiscount.Text = Math.Round(Product.Product_Discount).ToString();
                    rdbHasSize.SelectedValue = (txtSize.Text != "No Size") ? "Yes" : "No";
                    lblBcTitle.Text = Product.Product_Title;
                    txtRating.Text = Product.Store_Rating.ToString();
                    if (Product.Product_Status == eProductStatus.Published.ToString())
                    {
                        lblStatus.Attributes.Remove("class");
                        lblStatus.Attributes["class"] = "label label-success";
                    }
                    else
                    {
                        lblStatus.Attributes.Remove("class");
                        lblStatus.Attributes["class"] = "label label-danger";
                    }
                    pnlSize.Visible = (txtSize.Text != "No Size") ? true : false;
                }
            }
            else
            {
                Response.Redirect("/administration/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
            }
        }

        protected void btnProceedToSubmit_Click(object sender, EventArgs e)
        {
            int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            Administrators _admin = bAdministrator.List().ToList().Where(m => m.Administrators_Id == AdminId).FirstOrDefault();

            int prdId = Convert.ToInt32(hdnProductId.Value);
            Product Product = bProduct.List().ToList().Where(m => m.Product_Id == prdId).FirstOrDefault();

            Product.Store_Id = _admin.Store_Id;
            if (Product.Product_Title != txtTitle.Text || Product.Product_Description != txtDescription.Content || Product.Product_Specification != txtSpecification.Content)
            {
                Product.Product_Title = txtTitle.Text;
                Product.Product_Description = txtDescription.Content;
                Product.Product_Specification = txtSpecification.Content;
                Product.Product_Status = eProductStatus.ReviewPending.ToString();
            }
            Product.Administrators_Id = _admin.Administrators_Id;
            Product.Product_Qty = Convert.ToInt32(txtQuantity.Text);
            Product.Product_Qty_Alert = Convert.ToInt32(txtAlert.Text);
            Product.Product_Delivery_Time = Convert.ToInt32(txtProductDelieveredIn.Text);
            Product.Product_Max_Purchase = Convert.ToInt32(txtMaxPurchase.Text);
            Product.Product_Mkt_Price = Convert.ToDecimal(txtMarketPrice.Text);
            Product.Product_Our_Price = Convert.ToDecimal(txtOurPrice.Text);
            Product.Product_ShippingCharge = Convert.ToDecimal(txtShippingCharge.Text);
            Product.Product_Has_Size = (rdbHasSize.SelectedValue == "Yes") ? true : false;
            Product.Product_Size = (rdbHasSize.SelectedValue == "Yes") ? txtSize.Text : "No Size";
            Product.Product_Avail_ZipCode = (txtZipcode.Text != "") ? txtZipcode.Text : "0";
            Product.SubCategory_Id = Convert.ToInt32(ddlCategory.SelectedValue);
            Product.Product_Discount = Convert.ToDecimal(txtDiscount.Text);
            Product.Product_UpdatedDate = DateTime.Now;            
            Product.Store_Rating = (txtRating.Text != "") ? Convert.ToInt32(txtRating.Text) : 1;

            bProduct.Update(Product);

            if (Product.ErrorMessage != null)
            {
                ProductHelper.CreateProductFlow(Product.Product_Id, Product.Product_Title, _admin.Administrators_Id, _admin.FullName, "Product Updated and set to Review Pending Status", Product.Product_Status);
                bProduct.DeleteTopEight(Product.Product_Id);
                bProduct.DeleteProductFeature(Product.Product_Id);
                bProduct.DeleteCart(Product.Product_Id);
                Response.Redirect("/administration/product/productsdetailstatic.aspx?SavePrdId=2000&Productid=" + Product.Product_Id);
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Product cannot be updated. " + Product.ErrorMessage;
            }
        }

        protected void btnSearchPrdHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/product/productsdetailstatic.aspx?productid=" + hdnProductId.Value);
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
