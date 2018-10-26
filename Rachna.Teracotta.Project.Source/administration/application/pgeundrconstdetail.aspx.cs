using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class pgeundrconstdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : UnderConstrunction";
            if (Request.QueryString["UnderConstrunctionid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnUnderConstrunctionId.Value = Request.QueryString["UnderConstrunctionid"].ToString();
                    int UnderConstrunctionId = Convert.ToInt32(Request.QueryString["UnderConstrunctionid"].ToString());

                    UnderConstrunction _UnderConstrunction = bUnderConstrunction.List().Where(m => m.UnderConst_Id == UnderConstrunctionId).FirstOrDefault();

                    txtTitle.Text = _UnderConstrunction.UnderConst_Title;
                    txtDescription.Text = _UnderConstrunction.UnderConst_Description;
                    chkIsDefault.Checked = (_UnderConstrunction.UnderConst_Status == eStatus.Active.ToString()) ? true : false;
                    chkDisplayInsteadHomePage.Checked = (_UnderConstrunction.UnderConst_DispInstHmpPage == eStatus.Active.ToString()) ? true : false;
                    lblBcTitle.Text = _UnderConstrunction.UnderConst_Title;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int UnderConstrunctionId = Convert.ToInt32(hdnUnderConstrunctionId.Value);
            UnderConstrunction _otherStr = bUnderConstrunction.List().Where(m => m.UnderConst_Id != UnderConstrunctionId && m.UnderConst_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                UnderConstrunction UnderConstrunction = bUnderConstrunction.List().Where(m => m.UnderConst_Id == UnderConstrunctionId).FirstOrDefault();
                UnderConstrunction.UnderConst_Title = txtTitle.Text;
                UnderConstrunction.UnderConst_Description = txtDescription.Text;
                UnderConstrunction.UnderConst_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                UnderConstrunction.UnderConst_DispInstHmpPage = (chkDisplayInsteadHomePage.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                UnderConstrunction.UnderConst_UpdatedDate = DateTime.Now;
                UnderConstrunction.Administrators_Id = adminId;

                UnderConstrunction = bUnderConstrunction.Update(UnderConstrunction);

                if (String.IsNullOrEmpty(UnderConstrunction.ErrorMessage))
                {
                    Response.Redirect("/administration/application/pageunderconstruction.aspx?id=100&redirecturl=admin-UnderConstrunction-rachna-teracotta");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + UnderConstrunction.ErrorMessage;
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! UnderConstrunction detail not updated successfully, because UnderConstrunction name should not be same as other";
            }
        }
    }
}