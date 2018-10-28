using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.home
{
    public partial class dealoftheday : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public dealoftheday()
        {
            context = new RachnaDBContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
                DealOfTheDay _dealOfTheDay = context.DealOfTheDay.Where(m => m.Product_Id == _Product.Product_Id).FirstOrDefault();
                if (_dealOfTheDay == null)
                {
                    pnlProduct.Visible = true;
                    lblId.Text = _Product.Product_Id.ToString();
                    lblTitle.Text = _Product.Product_Title;
                    ltlActualPrice.Text = _Product.Product_Our_Price.ToString();
                    Image1.ImageUrl = "../../" + _Product.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo;
                }
                else
                {
                    pnlProduct.Visible = false;
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected Product already added to the Deal list...please try with other valid Product";
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

        protected void btnDealPrice_Click(object sender, EventArgs e)
        {
            DealOfTheDay dealOfTheDay = new DealOfTheDay()
            {
                Product_Id = Convert.ToInt32(lblId.Text),
                Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                Deal_Price = Convert.ToInt32(txtDealPrice.Text),
                Deal_Starts_From=Convert.ToDateTime(txtStartDate.Text),
                Deal_CreatedDate = DateTime.Now,
                Deal_UpdatedDate = DateTime.Now,
                Status=eStatus.Active.ToString()
            };

            dealOfTheDay = bDealOfTheDay.Create(dealOfTheDay);

            if (String.IsNullOrEmpty(dealOfTheDay.ErrorMessage))
            {
                pnlProduct.Visible = false;
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Product Deal added Successfully";

                pnlProduct.Visible = false;
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Failed! " + dealOfTheDay.ErrorMessage;
            }
        }
    }
}