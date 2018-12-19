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

namespace Rachna.Teracotta.Project.Source.administration.product
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
                    Response.Redirect("/administration/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/product/productdetail.aspx?Productid=" + lblProductId.Text);
        }

        protected void btnImageUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/product/uploadproductsbanner.aspx?Productid=" + lblProductId.Text);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            Administrators _admin = context.Administrator.ToList().Where(m => m.Administrators_Id == AdminId).FirstOrDefault();

            int prdId = Convert.ToInt32(lblProductId.Text);
            Product _Product = context.Product.ToList().Where(m => m.Product_Id == prdId).FirstOrDefault();


            List<ProductBanners> ProductBanners = context.ProductBanner.Where(m => m.Product_Id == _Product.Product_Id).ToList();
            if (ProductBanners.Count() > 1 && (!(ProductBanners[0].Product_Banner_Photo == "content/noimage.png" && ProductBanners[0].Product_Banner_Default == 1)))
            {
                string currentStatus = _Product.Product_Status;
                if (_Product.Product_Status != eProductStatus.Published.ToString())
                {
                    _Product.Product_Status = ProductHelper.GetProductStatus(currentStatus);

                    context.Entry(_Product).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    ProductHelper.CreateProductFlow(_Product.Product_Id, _Product.Product_Title, _admin.Administrators_Id, _admin.FullName, "Product Updated from" + currentStatus + " to " + _Product.Product_Status, _Product.Product_Status);
                    LoadDetail(_Product.Product_Id.ToString());
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success!!! Product Updated Successfully and Product Status Set to " + _Product.Product_Status
                        + " Status, from " + currentStatus + " Status";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!!! You cannot Update the product status to " + _Product.Product_Status + " from "
                        + currentStatus + " Because, Product status is in published status. You can reject the product.";
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!!! You cannot Update the product status to " + _Product.Product_Status
                    + " Because, there is no enough product banner available(Bnner should not be no image banner and also allease Minimum two banners required). Product should not have default banner.";
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            Administrators _admin = context.Administrator.ToList().Where(m => m.Administrators_Id == AdminId).FirstOrDefault();

            int prdId = Convert.ToInt32(lblProductId.Text);
            Product _Product = context.Product.ToList().Where(m => m.Product_Id == prdId).FirstOrDefault();

            if (_Product.Product_Status != eProductStatus.Rejected.ToString())
            {
                _Product.Product_Status = eProductStatus.Rejected.ToString();
                context.Entry(_Product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                ProductHelper.CreateProductFlow(_Product.Product_Id, _Product.Product_Title, _admin.Administrators_Id, _admin.FullName, "Product " + _Product.Product_Status + " Due to : " + txtReasonReject.Text, _Product.Product_Status);
                LoadDetail(_Product.Product_Id.ToString());
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Success!!! Product Rejected successfully, Product Status Changed to " + _Product.Product_Status;
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!!! You cannot the Reject the product, because Product Already in " + _Product.Product_Status + " Status.";
            }
        }

        public void LoadDetail(string ProductId)
        {
            try
            {
                Product _prd = null;

                int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
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

                    btnApprove.Visible = false;
                    if (_prd.Product_Status == eProductStatus.Rejected.ToString())
                    {
                        btnRejectModel.Visible = false;
                    }
                    if (_prd.Product_Status == eProductStatus.Published.ToString())
                    {
                        btnApprove.Visible = false;
                    }
                    else
                    {
                        if (_admin.Admin_Role == eRole.Approver.ToString() && eProductStatus.ReviewCompleted.ToString() == _prd.Product_Status)
                        {
                            btnApprove.Visible = true;
                        }
                        else if (_admin.Admin_Role == eRole.Publisher.ToString() && eProductStatus.Approved.ToString() == _prd.Product_Status)
                        {
                            btnApprove.Visible = true;
                        }
                        else if (_admin.Admin_Role == eRole.Super.ToString())
                        {
                            btnApprove.Visible = true;
                        }

                        if (eProductStatus.ReviewPending.ToString() == _prd.Product_Status)
                            btnApprove.Text = "Complete Review";
                        if (eProductStatus.ReviewCompleted.ToString() == _prd.Product_Status)
                            btnApprove.Text = "Approve";
                        if (eProductStatus.Approved.ToString() == _prd.Product_Status)
                            btnApprove.Text = "Publish";
                    }

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
                    Response.Redirect("/administration/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}