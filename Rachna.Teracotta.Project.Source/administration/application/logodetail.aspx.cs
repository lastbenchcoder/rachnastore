using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class logodetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Logo";
            if (Request.QueryString["logoid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnLogoId.Value = Request.QueryString["logoid"].ToString();
                    int LogoId = Convert.ToInt32(Request.QueryString["logoid"].ToString());

                    Logo _Logo = bLogo.List().Where(m => m.Logo_Id == LogoId).FirstOrDefault();

                    txtTitle.Text = _Logo.Logo_Title;
                    txtDescription.Text = _Logo.Logo_Description;
                    chkIsDefault.Checked = (_Logo.Logo_Status == eStatus.Active.ToString()) ? true : false;
                    imgArticle.ImageUrl = "~/" + _Logo.Logo_Banner;
                    lblBcTitle.Text = _Logo.Logo_Title;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int LogoId = Convert.ToInt32(hdnLogoId.Value);
            Logo _otherStr = bLogo.List().Where(m => m.Logo_Id != LogoId && m.Logo_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                Logo Logo = bLogo.List().Where(m => m.Logo_Id == LogoId).FirstOrDefault();
                Logo.Logo_Title = txtTitle.Text;
                Logo.Logo_Description = txtDescription.Text;
                Logo.Logo_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                Logo.Logo_UpdatedDate = DateTime.Now;
                Logo.Administrators_Id = adminId;
                if (imgInp.HasFile)
                {
                    Logo.Logo_Banner = "files/Logo/" + "Logo_" + Logo.Logo_Id + ".png";
                    string path = Server.MapPath("../" + Logo.Logo_Banner);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not
                    {
                        file.Delete();
                    }
                    Upload(Logo.Logo_Id);
                }

                Logo = bLogo.Update(Logo);

                if (String.IsNullOrEmpty(Logo.ErrorMessage))
                {
                    Response.Redirect("/administration/application/logo.aspx?id=100&redirecturl=admin-Logo-rachna-teracotta");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + Logo.ErrorMessage;
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Logo detail not updated successfully, because Logo name should not be same as other";
            }
        }

        private void Upload(int LogoId)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/Logo/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                imgInp.SaveAs(folderPath + Path.GetFileName("Logo" + "_" + LogoId + ".png"));
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.InnerException.InnerException.Message;
            }
        }
    }
}