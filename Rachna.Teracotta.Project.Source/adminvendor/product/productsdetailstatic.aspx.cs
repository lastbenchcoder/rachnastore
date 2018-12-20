using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.adminvendor.product
{
    public partial class productsdetailstatic : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public productsdetailstatic()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Product Detail";
            if (!IsPostBack)
            {
                if (Request.QueryString["Productid"] != null)
                {
                    if (Request.QueryString["SavePrdId"] != null)
                    {
                        var reqId = Request.QueryString["SavePrdId"].ToString();
                        if (reqId == "2000")
                        {
                            pnlErrorMessage.Attributes.Remove("class");
                            pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                            pnlErrorMessage.Visible = true;
                            lblMessage.Text = "Success!!! Product Updated Successfully and Submitted for Administrator Rewiew.";
                        }
                        else
                        {
                            pnlErrorMessage.Attributes.Remove("class");
                            pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                            pnlErrorMessage.Visible = true;
                            lblMessage.Text = "Success!!! New Product Created Successfully and Submitted for Administrator Rewiew.";
                        }
                    }
                    string ProductId = Request.QueryString["Productid"].ToString();
                    LoadDetail(ProductId);
                }
                else
                {
                    Response.Redirect("/adminvendor/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/adminvendor/product/productdetail.aspx?Productid=" + lblProductId.Text);
        }

        protected void btnImageUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("/adminvendor/product/uploadproductsbanner.aspx?Productid=" + lblProductId.Text);
        }

        public void LoadDetail(string ProductId)
        {
            try
            {
                Product _prd = null;

                int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString());
                Administrators _admin = context.Administrator.ToList().Where(m => m.Administrators_Id == AdminId).FirstOrDefault();

                if (!ProductId.All(char.IsDigit))
                {
                    _prd = context.Product.Include("SubCategory").Include("ProductBanner").Include("Admin").Include("Store").Include("ProductFlow").Include("ProdComments").ToList().Where(m => m.ProductCode == ProductId).FirstOrDefault();
                    if (_prd != null)
                    {
                        _prd.SubCategory.Category = context.Category.Where(m => m.Category_Id == _prd.SubCategory.Category_Id).FirstOrDefault();
                    }
                }
                else
                {
                    int prdId = Convert.ToInt32(ProductId);
                    _prd = context.Product.Include("SubCategory").Include("ProductBanner").Include("Admin").Include("Store").Include("ProductFlow").Include("ProdComments").ToList().Where(m => m.Product_Id == prdId).FirstOrDefault();
                    if (_prd != null)
                    {
                        _prd.SubCategory.Category = context.Category.Where(m => m.Category_Id == _prd.SubCategory.Category_Id).FirstOrDefault();
                    }
                }
                if (_prd != null)
                {
                    lblProductCode.Text = _prd.ProductCode.ToString();
                    lblProductId.Text = _prd.Product_Id.ToString();
                    lblProductName.Text = _prd.Product_Title;
                    lblCategorySubCategory.Text = _prd.SubCategory.SubCategory_Title + "(" + _prd.SubCategory.Category.Category_Title + ")";
                    if (_prd.Product_Status == eProductStatus.Approved.ToString() || _prd.Product_Status == eProductStatus.ReviewCompleted.ToString() || _prd.Product_Status == eProductStatus.Published.ToString())
                    {
                        lblStatus.Font.Bold = true;
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        lblStatus.Text = _prd.Product_Status.ToUpper();
                    }
                    else
                    {
                        lblStatus.Font.Bold = true;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.Text = _prd.Product_Status.ToUpper();
                    }
                    lblCreatedBy.Text = _prd.Admin.FullName;
                    lblDescription.Text = _prd.Product_Description;
                    lblSpecification.Text = _prd.Product_Specification;
                    lblQty.Text = _prd.Product_Qty.ToString(); ;
                    lblAlert.Text = _prd.Product_Qty_Alert.ToString();
                    lblmktprc.Text = Math.Round(_prd.Product_Mkt_Price).ToString();
                    lblourprc.Text = Math.Round(_prd.Product_Our_Price).ToString();
                    lblShippingchrge.Text = Math.Round(_prd.Product_ShippingCharge).ToString();
                    lbldiscount.Text = Math.Round(_prd.Product_Discount).ToString();
                    lblSizes.Text = _prd.Product_Size;
                    lblzipcode.Text = _prd.Product_Avail_ZipCode;
                    lblmaxpurchase.Text = _prd.Product_Max_Purchase.ToString();
                    lblDelieveryTime.Text = (_prd.Product_Delivery_Time - 1) + " to " + _prd.Product_Delivery_Time.ToString() + " days";
                    lblBcTitle.Text = _prd.Product_Title;
                    lblRatingStore.Text = _prd.Store_Rating.ToString();
                    lblStore.Text = _prd.Store.Store_Name;

                    if (_prd.ProductBanner.Count > 0)
                    {
                        DataList1.DataSource = _prd.ProductBanner;
                        DataList1.DataBind();
                    }

                    if (_prd.ProdComments.Count > 0)
                    {
                        grdComments.DataSource = _prd.ProdComments;
                        grdComments.DataBind();
                    }

                    grdProdHistory.DataSource = _prd.ProductFlow;
                    grdProdHistory.DataBind();
                }
                else
                {
                    Response.Redirect("/adminvendor/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}