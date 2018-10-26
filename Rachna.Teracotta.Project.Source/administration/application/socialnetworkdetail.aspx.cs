using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class socialnetworkdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : SocialNetworking";
            if (Request.QueryString["SocialNetworkingid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnSocialNetworkingId.Value = Request.QueryString["SocialNetworkingid"].ToString();
                    int SocialNetworkingId = Convert.ToInt32(Request.QueryString["SocialNetworkingid"].ToString());

                    SocialNetworking _SocialNetworking = bSocialNetworking.List().Where(m => m.Scl_Ntk_Id == SocialNetworkingId).FirstOrDefault();

                    txtTitle.Text = _SocialNetworking.Scl_Ntk_URL;
                    chkIsDefault.Checked = (_SocialNetworking.Scl_Ntk_Status == eStatus.Active.ToString()) ? true : false;
                    imgArticle.ImageUrl = "~/" + _SocialNetworking.Scl_Ntk_Icon;
                    lblBcTitle.Text = _SocialNetworking.Scl_Ntk_URL;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int SocialNetworkingId = Convert.ToInt32(hdnSocialNetworkingId.Value);
            SocialNetworking _otherStr = bSocialNetworking.List().Where(m => m.Scl_Ntk_Id != SocialNetworkingId && m.Scl_Ntk_URL == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                SocialNetworking SocialNetworking = bSocialNetworking.List().Where(m => m.Scl_Ntk_Id == SocialNetworkingId).FirstOrDefault();
                SocialNetworking.Scl_Ntk_URL = txtTitle.Text;
                SocialNetworking.Scl_Ntk_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                SocialNetworking.Scl_Ntk_UpdatedDate = DateTime.Now;
                SocialNetworking.Administrators_Id = adminId;
                if (imgInp.HasFile)
                {
                    SocialNetworking.Scl_Ntk_Icon = "files/SocialNetworking/" + "SocialNetworking_" + SocialNetworking.Scl_Ntk_Id + ".png";
                    string path = Server.MapPath("../" + SocialNetworking.Scl_Ntk_Icon);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not
                    {
                        file.Delete();
                    }
                    Upload(SocialNetworking.Scl_Ntk_Id);
                }

                SocialNetworking = bSocialNetworking.Update(SocialNetworking);

                if (String.IsNullOrEmpty(SocialNetworking.ErrorMessage))
                {
                    Response.Redirect("/administration/application/socialnetwork.aspx?id=100&redirecturl=admin-SocialNetworking-rachna-teracotta");
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

        private void Upload(int SocialNetworkingId)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/SocialNetworking/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                imgInp.SaveAs(folderPath + Path.GetFileName("SocialNetworking" + "_" + SocialNetworkingId + ".png"));
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