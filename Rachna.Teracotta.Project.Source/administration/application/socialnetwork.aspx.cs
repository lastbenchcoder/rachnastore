using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class socialnetwork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : SocialNetworking";
            if (Request.QueryString["id"] != null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "SocialNetworking Detail Updated Successfully";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SocialNetworking SocialNetworking1 = bSocialNetworking.List().Where(m => m.Scl_Ntk_URL == txtTitle.Text.Trim()).FirstOrDefault();
            if (SocialNetworking1 == null)
            {
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                SocialNetworking SocialNetworking = new SocialNetworking()
                {
                    Scl_Ntk_URL = txtTitle.Text.Trim(),
                    Scl_Ntk_Icon = "files/SocialNetworking/" + "SocialNetworking_" + imgInp.FileName,
                    Scl_Ntk_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString(),
                    Scl_Ntk_CreatedDate = DateTime.Now,
                    Scl_Ntk_UpdatedDate = DateTime.Now,
                    Administrators_Id = adminId
                };

                SocialNetworking = bSocialNetworking.Create(SocialNetworking);

                if (String.IsNullOrEmpty(SocialNetworking.ErrorMessage))
                {
                    Upload();

                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "SocialNetworking Detail Updated Successfully";
                    ClearFields();
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + SocialNetworking.ErrorMessage;
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! SocialNetworking detail not updated successfully, because SocialNetworking name should not be same as other";
            }
        }


        private void ClearFields()
        {
            txtTitle.Text = "";
        }

        private void Upload()
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("~/files/SocialNetworking/");
                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    imgInp.SaveAs(folderPath + Path.GetFileName("SocialNetworking" + "_" + imgInp.FileName));
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected SocialNetworking Banner should not be higher than 1MB.";
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