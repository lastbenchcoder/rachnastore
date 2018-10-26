using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class metainformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : MetaInformation";
            if (Request.QueryString["id"] != null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "MetaInformation Detail Updated Successfully";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MetaInformation MetaInformation1 = bMetaInformation.List().Where(m => m.Meta_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (MetaInformation1 == null)
            {
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                MetaInformation MetaInformation = new MetaInformation()
                {
                    Meta_Title = txtTitle.Text.Trim(),
                    Meta_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString(),
                    Meta_Description = txtDescription.Text,
                    Meta_KeyWords=txtKeywords.Text,
                    Meta_CreatedDate = DateTime.Now,
                    Meta_UpdatedDate = DateTime.Now,
                    Administrators_Id = adminId
                };

                MetaInformation = bMetaInformation.Create(MetaInformation);

                if (String.IsNullOrEmpty(MetaInformation.ErrorMessage))
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "MetaInformation Detail Updated Successfully";
                    ClearFields();
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + MetaInformation.ErrorMessage;
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! MetaInformation detail not updated successfully, because MetaInformation name should not be same as other";
            }
        }


        private void ClearFields()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtKeywords.Text = "";
        }
    }
}