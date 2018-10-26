using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.home
{
    public partial class advertisementdetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public advertisementdetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Advertisements Detail";
                if (Request.QueryString["adsId"] != null)
                {
                    int adsId = Convert.ToInt32(Request.QueryString["adsId"].ToString());
                    LoadSlider(adsId);
                }
                else
                {
                    Response.Redirect("/administration/home/advertisement.aspx?id=404&redirecturl=admin-advertisement-RachnaTeracotta");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hdnAdsId.Value);

                Ads Ads = context.Advertisement.Where(m => m.Ads_Id == id).FirstOrDefault();
                Ads.Ads_RedirectUrl = txtImageUrl.Text;
                Ads.Ads_UpdatedDate = DateTime.Now;
                Ads.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()]);

                context.Entry(Ads).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                Response.Redirect("/administration/home/advertisement.aspx?id=2000&redirecturl=admin-advertisement-RachnaTeracotta");

            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int sliderId = Convert.ToInt32(hdnAdsId.Value);
                Ads Ads = context.Advertisement.Where(m => m.Ads_Id == sliderId).FirstOrDefault();

                context.Entry(Ads).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                string filePath = Server.MapPath("~/" + Ads.Ads_Banner_Or_Source);
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }

                Response.Redirect("/administration/home/advertisement.aspx?id=3000&redirecturl=admin-advertisement-RachnaTeracotta");
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        private void LoadSlider(int adsId)
        {
            Ads Ads = context.Advertisement.Where(m => m.Ads_Id == adsId).FirstOrDefault();
            lblAdsType.Text = Ads.Ads_Type;
            txtImageUrl.Text = Ads.Ads_RedirectUrl;
            imgBanner.ImageUrl = "../../" + Ads.Ads_Banner_Or_Source;
            hdnAdsId.Value = adsId.ToString();
        }
    }
}