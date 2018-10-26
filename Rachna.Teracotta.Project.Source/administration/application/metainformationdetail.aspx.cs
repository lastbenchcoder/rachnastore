using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class metainformationdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : MetaInformation";
            if (Request.QueryString["MetaInformationid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnMetaInformationId.Value = Request.QueryString["MetaInformationid"].ToString();
                    int MetaInformationId = Convert.ToInt32(Request.QueryString["MetaInformationid"].ToString());

                    MetaInformation _MetaInformation = bMetaInformation.List().Where(m => m.Meta_Id == MetaInformationId).FirstOrDefault();

                    txtTitle.Text = _MetaInformation.Meta_Title;
                    txtDescription.Text = _MetaInformation.Meta_Description;
                    chkIsDefault.Checked = (_MetaInformation.Meta_Status == eStatus.Active.ToString()) ? true : false;
                    txtKeywords.Text = _MetaInformation.Meta_KeyWords;
                    lblBcTitle.Text = _MetaInformation.Meta_Title;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int MetaInformationId = Convert.ToInt32(hdnMetaInformationId.Value);
            MetaInformation _otherStr = bMetaInformation.List().Where(m => m.Meta_Id != MetaInformationId && m.Meta_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                MetaInformation MetaInformation = bMetaInformation.List().Where(m => m.Meta_Id == MetaInformationId).FirstOrDefault();
                MetaInformation.Meta_Title = txtTitle.Text;
                MetaInformation.Meta_Description = txtDescription.Text;
                MetaInformation.Meta_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                MetaInformation.Meta_UpdatedDate = DateTime.Now;
                MetaInformation.Administrators_Id = adminId;               

                MetaInformation = bMetaInformation.Update(MetaInformation);

                if (String.IsNullOrEmpty(MetaInformation.ErrorMessage))
                {
                    Response.Redirect("/administration/application/MetaInformation.aspx?id=100&redirecturl=admin-MetaInformation-rachna-teracotta");
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
    }
}