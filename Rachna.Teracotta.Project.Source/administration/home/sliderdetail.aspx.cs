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
    public partial class sliderdetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public sliderdetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Home Page Slider Detail";
            if (!IsPostBack)
            {
                if (Request.QueryString["sliderId"] != null)
                {
                    int sliderId = Convert.ToInt32(Request.QueryString["sliderId"].ToString());
                    LoadSlider(sliderId);
                }
                else
                {
                    Response.Redirect("/administration/home/slider.aspx?id=404&redirecturl=admin-slider-RachnaTeracotta");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hdnSliderId.Value);

                Sliders Sliders = context.Slider.Where(m => m.Slider_Id == id).FirstOrDefault();
                Sliders.Slider_TItle = txtAltText.Text;
                Sliders.Slider_RedirectUrl = txtImageUrl.Text;
                Sliders.Slider_UpdatedDate = DateTime.Now;
                Sliders.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()]);

                context.Entry(Sliders).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                Response.Redirect("/administration/home/slider.aspx?id=2000&redirecturl=admin-slider-RachnaTeracotta");

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
                int sliderId = Convert.ToInt32(hdnSliderId.Value);
                Sliders Sliders = context.Slider.Where(m => m.Slider_Id == sliderId).FirstOrDefault();

                context.Entry(Sliders).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                string filePath = Server.MapPath("~/" + Sliders.Slider_Photo);
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }

                Response.Redirect("/administration/home/slider.aspx?id=3000&redirecturl=admin-slider-RachnaTeracotta");
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        private void LoadSlider(int sliderId)
        {
            Sliders Sliders = context.Slider.Where(m => m.Slider_Id == sliderId).FirstOrDefault();
            txtAltText.Text = Sliders.Slider_TItle;
            txtImageUrl.Text = Sliders.Slider_RedirectUrl;
            imgBanner.ImageUrl = "../../" + Sliders.Slider_Photo;
            hdnSliderId.Value = sliderId.ToString();
        }
    }
}