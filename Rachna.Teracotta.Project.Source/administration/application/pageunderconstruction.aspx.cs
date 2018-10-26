using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class pageunderconstruction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : UnderConstrunction";
            if (Request.QueryString["id"] != null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Under Construnction Detail Updated Successfully";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UnderConstrunction UnderConstrunction1 = bUnderConstrunction.List().Where(m => m.UnderConst_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (UnderConstrunction1 == null)
            {
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                UnderConstrunction UnderConstrunction = new UnderConstrunction()
                {
                    UnderConst_Title = txtTitle.Text.Trim(),
                    UnderConst_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString(),
                    UnderConst_DispInstHmpPage = (chkDisplayInsteadHomePage.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString(),
                    UnderConst_Description = txtDescription.Text,
                    UnderConst_CreatedDate = DateTime.Now,
                    UnderConst_UpdatedDate = DateTime.Now,
                    Administrators_Id = adminId
                };

                UnderConstrunction = bUnderConstrunction.Create(UnderConstrunction);

                if (String.IsNullOrEmpty(UnderConstrunction.ErrorMessage))
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Under Construnction Detail Updated Successfully";
                    ClearFields();
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
                lblMessage.Text = "Oops!! Under Construnction detail not updated successfully, because UnderConstrunction name should not be same as other";
            }
        }


        private void ClearFields()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
        }
    }
}