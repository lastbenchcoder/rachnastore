using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.home
{
    public partial class slider : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public slider()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Home Page Slider";
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"] == "2000")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Slider Detail Updated Successfully";
                }
                else if (Request.QueryString["id"] == "3000")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Slider Detail Deleted Successfully";
                }
                else if (Request.QueryString["id"] == "404")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Slider Detail Failed to Update/Delete, Server Error Occured.";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Sliders Slider = new Sliders()
                {
                    Slider_Photo = "files/slider/Slider_" + imgInp.FileName,
                    Slider_TItle = txtTitle.Text,
                    Slider_Description = txtDescription.Text,
                    ButtonText = txtBtnTitle.Text,
                    Slider_RedirectUrl = txtImageUrl.Text,
                    Slider_CreatedDate = DateTime.Now,
                    Slider_UpdatedDate = DateTime.Now,
                    Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString())
                };

                Upload();

                int maxSliderId = 0;
                if (context.Slider.ToList().Count > 0)
                    maxSliderId = context.Slider.Max(m => m.Slider_Id);
                maxSliderId = (maxSliderId > 0) ? (maxSliderId + 1) : 1;
                Slider.Slider_Code = "SLDRACH" + maxSliderId + "TERA" + (maxSliderId + 1);
                context.Slider.Add(Slider);
                context.SaveChanges();

                txtImageUrl.Text = "";
                txtTitle.Text = "";
                txtDescription.Text = "";
                txtBtnTitle.Text = "";
                txtImageUrl.Text = "";
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Slider Detail Created Successfully";
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        private void Upload()
        {
            try
            {
                string folderPath = Server.MapPath("~/files/slider/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                imgInp.SaveAs(folderPath + Path.GetFileName("Slider_" + imgInp.FileName));
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