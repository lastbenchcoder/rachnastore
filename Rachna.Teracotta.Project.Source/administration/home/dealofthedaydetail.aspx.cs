using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.home
{
    public partial class dealofthedaydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Deal of the day Detail";
                if (Request.QueryString["dealId"] != null)
                {
                    int dealId = Convert.ToInt32(Request.QueryString["dealId"].ToString());
                    DealOfTheDay dealOftheDay = bDealOfTheDay.List().Where(m => m.Deal_Id == dealId).FirstOrDefault();
                    lblTitle.Text = dealOftheDay.Product.Product_Title;
                    lblId.Text = dealOftheDay.Product.Product_Id.ToString();
                    Image1.ImageUrl = "../../" + dealOftheDay.Product.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo;
                    ltlActualPrice.Text = Math.Round(dealOftheDay.Product.Product_Our_Price).ToString();
                    txtDealPrice.Text = Math.Round(dealOftheDay.Deal_Price).ToString();
                    txtStartDate.Text = dealOftheDay.Deal_Starts_From.ToString("D");
                    hdnDealId.Value = dealOftheDay.Deal_Id.ToString();
                }
                else
                {
                    Response.Redirect("/administration/home/dealoftheday.aspx?id=404&redirecturl=admin-advertisement-RachnaTeracotta");
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hdnDealId.Value);

                DealOfTheDay dealOftheDay = bDealOfTheDay.List().Where(m => m.Deal_Id == id).FirstOrDefault();
                dealOftheDay.Product_Id = Convert.ToInt32(lblId.Text);
                dealOftheDay.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                dealOftheDay.Deal_Price = Convert.ToInt32(txtDealPrice.Text);
                dealOftheDay.Deal_Starts_From = Convert.ToDateTime(txtStartDate.Text);
                dealOftheDay.Deal_CreatedDate = DateTime.Now;
                dealOftheDay.Deal_UpdatedDate = DateTime.Now;
                dealOftheDay.Status = eStatus.Active.ToString();

                dealOftheDay = bDealOfTheDay.Update(dealOftheDay);

                if (String.IsNullOrEmpty(dealOftheDay.ErrorMessage))
                {
                    Response.Redirect("/administration/home/dealoftheday.aspx?id=2000&redirecturl=admin-advertisement-RachnaTeracotta");
                }
                else
                {
                    Response.Redirect("/administration/home/dealoftheday.aspx?id=404&redirecturl=admin-advertisement-RachnaTeracotta");
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
    }
}