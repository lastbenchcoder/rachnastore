using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.adminvendor.product
{
    public partial class uploadproductsbanner : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public uploadproductsbanner()
        {
            context = new RachnaDBContext();
        }
        private string _prdId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Product Banner";
            if (Request.QueryString["Productid"] != null)
            {
                if (!IsPostBack)
                {
                    string _prdId = Request.QueryString["Productid"].ToString();
                    hdnProductId.Value = _prdId;
                    hdnProdId.Value = _prdId;
                    LoadGrid();
                }
            }
            else
            {
                Response.Redirect("/adminvendor/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
            }
        }

        private void LoadGrid()
        {
            int prdId = Convert.ToInt32(hdnProdId.Value);
            Product Product = context.Product.Where(m => m.Product_Id == prdId).FirstOrDefault();
            lblBcTitle.Text = Product.Product_Title;
            List<ProductBanners> _banners = context.ProductBanner.Where(m => m.Product_Id == prdId).ToList();
            if (_banners.Count > 4)
            {
                pnlCreateBanner.Visible = false;
            }
            else
            {
                pnlCreateBanner.Visible = true;
            }
            grdPrdSlider.DataSource = _banners;
            grdPrdSlider.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = Upload(hdnProdId.Value);
            if (result == "100")
            {
                int prdId = Convert.ToInt32(hdnProdId.Value);
                ProductBanners currentBanner = context.ProductBanner.Where(m => m.Product_Id == prdId).FirstOrDefault();
                ProductBanners Product = new ProductBanners()
                {
                    Product_Id = Convert.ToInt32(hdnProdId.Value),
                    Product_Banner_Photo = "files/product/" + hdnProdId.Value + "/" + hdnProdId.Value + "_" + imgInp.FileName,
                    Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                    Product_Banner_Default = Convert.ToInt32(ddlStatus.SelectedValue),
                    Product_Banner_CreatedDate = DateTime.Now,
                    Product_Banner_UpdatedDate = DateTime.Now
                };

                if (Product.Product_Banner_Default == 1)
                {
                    List<ProductBanners> Productbnrs = context.ProductBanner.Where(m => m.Product_Id == prdId).ToList();
                    foreach (var item in Productbnrs)
                    {
                        item.Product_Banner_Default = 0;
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                else
                {
                    if (currentBanner == null)
                    {
                        Product.Product_Banner_Default = 1;
                    }
                }

                int maxBnrAdminId = 1;
                if (context.ProductBanner.ToList().Count > 0)
                    maxBnrAdminId = context.ProductBanner.Max(m => m.Product_Id);
                maxBnrAdminId = (maxBnrAdminId == 1 && context.ProductBanner.ToList().Count > 0) ? (maxBnrAdminId + 1) : maxBnrAdminId;
                Product.Product_BannerCode = "PRDBNRTRACH" + maxBnrAdminId + "TERA" + (maxBnrAdminId + 1);
                context.ProductBanner.Add(Product);
                context.SaveChanges();

                LoadGrid();
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Success!!! Banner Created Successfully.";
                ddlStatus.SelectedIndex = 0;
            }
        }
        private string Upload(string Id)
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("~/files/product/" + Id + "/");

                    FileInfo file = new FileInfo(folderPath + imgInp.FileName);
                    if (file.Exists)
                    {
                        file.Delete();
                    }

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    imgInp.SaveAs(folderPath + Path.GetFileName(Id + "_" + imgInp.FileName));

                    return "100";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected banner should not be higher than 1MB.";
                    return "404";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Server error occured, please contact administrator.";
                return "500";
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (var ctx = new RachnaDBContext())
                {
                    ProductBanners _banner = ctx.ProductBanner.ToList().Where(m => m.Product_Banner_Id == Convert.ToInt32(e.Values[0].ToString())).FirstOrDefault();
                    string filePath = Server.MapPath("~/" + _banner.Product_Banner_Photo);
                    if (!filePath.Contains("noimage.png"))
                    {
                        FileInfo file = new FileInfo(filePath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    ctx.Entry(_banner).State = EntityState.Deleted;
                    ctx.SaveChanges();

                    ProductBanners currentBanner = ctx.ProductBanner.ToList().Where(m => m.Product_Id == Convert.ToInt32(hdnProductId.Value)).FirstOrDefault();
                    if (currentBanner != null)
                    {
                        currentBanner.Product_Banner_Default = 1;
                        ctx.Entry(currentBanner).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Product Slider Deleted Successfully.";
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Server error occured, please contact administrator.";
            }
        }

        protected void Product_Command(Object sender, CommandEventArgs e)
        {
            String productID = e.CommandArgument.ToString();
            string result = SetDefaultImage(productID);
        }

        public string SetDefaultImage(string id)
        {
            using (var ctx = new RachnaDBContext())
            {
                List<ProductBanners> Productbnrs = ctx.ProductBanner.ToList().Where(f => f.Product_Id == Convert.ToInt32(hdnProductId.Value)).ToList();
                foreach (var item in Productbnrs)
                {
                    item.Product_Banner_Default = 0;
                    ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }

                ProductBanners _banner = ctx.ProductBanner.ToList().Where(m => m.Product_Banner_Id == Convert.ToInt32(id)).FirstOrDefault();
                _banner.Product_Banner_Default = 1;
                ctx.Entry(_banner).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Banner Updated Successfully.";
            }
            LoadGrid();
            return "";
        }
        protected void btnSearchPrdHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/adminvendor/product/productsdetailstatic.aspx?productid=" + hdnProductId.Value);
        }

    }
}