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
    public partial class featuredproducts : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public featuredproducts()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Featured Products";
                Array status = Enum.GetValues(typeof(eProductFeature));
                foreach (eProductFeature sts in status)
                {
                    ddlFeature.Items.Add(new ListItem(sts.ToString()));
                }
                LoadDetail();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
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
                    ProductFeatures _feature = context.ProductFeature.Where(m => m.Product_Id == _Product.Product_Id).FirstOrDefault();
                    if (_feature == null)
                    {

                        pnlProduct.Visible = true;
                        _Product.ProductBanner = context.ProductBanner.ToList().Where(m=>m.Product_Id==_Product.Product_Id).ToList();
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
                        lblMessage.Text = "Selected product already added to the feature list..please try with other product";
                    }
                }
                else
                {

                    pnlProduct.Visible = false;
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "No Product found for your search or selected product does not have published status...please try with valid Product id";
                }
            }
            catch (Exception ex)
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnAddToFeature_Click(object sender, EventArgs e)
        {
            List<ProductFeatures> _features = context.ProductFeature.ToList();
            if (_features.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Best.ToString()).Count() > 4 && ddlFeature.Text == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Best.ToString())
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "There are already 5 items found for selected feature type. If you want to continue please delete the existing item";
            }
            else if (_features.Where(m => m.Product_Feature_Type == eProductFeature.Featured.ToString()).Count() > 4 && ddlFeature.Text == eProductFeature.Featured.ToString())
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "There are already 5 items found for selected feature type. If you want to continue please delete the existing item";
            }
            else if (_features.Where(m => m.Product_Feature_Type == eProductFeature.Latest.ToString()).Count() > 4 && ddlFeature.Text == eProductFeature.Latest.ToString())
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "There are already 5 items found for selected feature type. If you want to continue please delete the existing item";
            }
            else if (_features.Where(m => m.Product_Feature_Type == eProductFeature.Top.ToString()).Count() > 4 && ddlFeature.Text == eProductFeature.Top.ToString())
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "There are already 5 items found for selected feature type. If you want to continue please delete the existing item";
            }
            else if (_features.Where(m => m.Product_Feature_Type == eProductFeature.Hot.ToString()).Count() > 4 && ddlFeature.Text == eProductFeature.Hot.ToString())
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "There are already 5 items found for selected feature type. If you want to continue please delete the existing item";
            }
            else if (_features.Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).Count() > 4 && ddlFeature.Text == eProductFeature.OurChoice.ToString())
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "There are already 5 items found for selected feature type. If you want to continue please delete the existing item";
            }
            else
            {
                ProductFeatures ProductFeature = new ProductFeatures()
                {
                    Product_Id = Convert.ToInt32(lblId.Text),
                    Product_Feature_Type = ddlFeature.Text,
                    Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                    Product_Feature_CreatedDate = DateTime.Now,
                    Product_Feature_UpdatedDate = DateTime.Now
                };

                int maxAdminId = 1;
                if (context.ProductFeature.ToList().Count > 0)
                    maxAdminId = context.ProductFeature.Max(m => m.Product_Feature_Id);
                ProductFeature.Product_Feature_Code = "PRDFETRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
                context.ProductFeature.Add(ProductFeature);
                context.SaveChanges();

                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Selected Product Added to the feature list Successfully.";
                pnlProduct.Visible = false;
                LoadDetail();
            };
        }

        public void LoadDetail()
        {
            List<ProductFeatures> _RequestList = null;
            _RequestList = context.ProductFeature.Include("Product").ToList();

            List<ProductFeature> _feature = new List<ProductFeature>();

            foreach (var item in _RequestList)
            {
                _feature.Add(new ProductFeature
                {
                    Product_Id = item.Product_Id,
                    Id = item.Product_Feature_Id,
                    Title = item.Product.Product_Title,
                    Type = item.Product_Feature_Type,
                    DateCreated = item.Product_Feature_CreatedDate.ToString(),
                    DateUpdated = item.Product_Feature_UpdatedDate.ToString()
                });
            }

            grdPrdSlider.DataSource = _feature;
            grdPrdSlider.DataBind();

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int prdFeatId = Convert.ToInt32(e.Values[0].ToString());
                ProductFeatures _banner = context.ProductFeature.Where(m=>m.Product_Feature_Id==prdFeatId).FirstOrDefault();

                context.Entry(_banner).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                LoadDetail();
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Product Feature Deleted Successfully.";

                pnlProduct.Visible = false;
            }
            catch (Exception ex)
            {

                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
    }

    public class ProductFeature
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
    }
}