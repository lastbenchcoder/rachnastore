using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.home
{
    public partial class topeight : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public topeight()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDetail();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int prdId = Convert.ToInt32(txtProductSearch.Text);
            Product _Product = context.Product.Include("SubCategory")
                .Include("ProductBanner")
                .Include("Admin")
                .Include("Store")
                .Include("ProductFlow")
                .Where(m => m.Product_Id == prdId && m.Product_Status == eProductStatus.Published.ToString())
                .FirstOrDefault();

            if (_Product != null)
            {
                ProductEight _Eights = context.ProductEights.Where(m=>m.Product_Id==_Product.Product_Id).FirstOrDefault();
                if (_Eights == null)
                {
                    pnlProduct.Visible = true;
                    lblId.Text = _Product.Product_Id.ToString();
                    lblTitle.Text = _Product.Product_Title;
                    Image1.ImageUrl = "../../" + _Product.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo;
                }
                else
                {
                    pnlProduct.Visible = false;
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected Product already added to the Product Eight Feature list...please try with valid Product id";
                }
            }
            else
            {
                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! No Product found for your search or selected product does not have published status...please try with valid Product id";
            }
        }

        protected void btnAddToEights_Click(object sender, EventArgs e)
        {
            ProductEight ProductEights = new ProductEight()
            {
                Product_Id = Convert.ToInt32(lblId.Text),
                Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                Product_Eight_CreatedDate = DateTime.Now,
                Product_Eight_UpdatedDate = DateTime.Now
            };

            int maxAdminId = 1;
            if (context.ProductEights.ToList().Count > 0)
                maxAdminId = context.ProductEights.Max(m => m.Product_Eight_Id);
            maxAdminId = (maxAdminId == 1 && context.ProductEights.ToList().Count > 0) ? (maxAdminId + 1) : maxAdminId;
            ProductEights.Product_Eight_Code = "PRDEIGHTRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
            context.ProductEights.Add(ProductEights);
            context.SaveChanges();

            pnlProduct.Visible = false;
            pnlErrorMessage.Attributes.Remove("class");
            pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
            pnlErrorMessage.Visible = true;
            lblMessage.Text = "Product Added to Top Eight Feature Successfully";
           
            pnlProduct.Visible = false;
            LoadDetail();
        }

        public void LoadDetail()
        {
            List<ProductEight> _RequestList = null;

            _RequestList = context.ProductEights.Include("Product").ToList();

            List<ProductTop> _Eights = new List<ProductTop>();

            foreach (var item in _RequestList)
            {
                _Eights.Add(new ProductTop
                {
                    Product_Id = item.Product_Id,
                    Id = item.Product_Eight_Id,
                    Title = item.Product.Product_Title,
                    DateCreated = item.Product_Eight_CreatedDate.ToString(),
                    DateUpdated = item.Product_Eight_UpdatedDate.ToString()
                });
            }

            grdPrdSlider.DataSource = _Eights;
            grdPrdSlider.DataBind();

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int prdFeatId = Convert.ToInt32(e.Values[0].ToString());
                ProductEight _banner = context.ProductEights.Where(m => m.Product_Eight_Id == prdFeatId).FirstOrDefault();

                context.Entry(_banner).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Top Eight Product Information Deleted Successfully.";
                LoadDetail();
                pnlProduct.Visible = false;
            }
            catch (Exception ex)
            {
                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text =ex.Message;
            }
        }
    }

    public class ProductTop
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public string Title { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
    }
}