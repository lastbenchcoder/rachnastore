using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class newcontact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Contact Owner";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ContactOwner ContactOwner1 = bContactOwner.List().Where(m => m.Contact_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (ContactOwner1 == null)
            {
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                ContactOwner ContactOwner = new ContactOwner()
                {
                    Contact_Title = txtTitle.Text.Trim(),
                    Contact_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString(),
                    Contact_Query_Submission = (chkSubmitRequest.Checked) ? "Y" : "N",
                    Contact_Description = txtDescription.Text,
                    Contact_Address = txtAddress.Text,
                    Contact_City = txtCity.Text,
                    Contact_State = txtState.Text,
                    Contact_ZipCode = Convert.ToInt32(txtZip.Text),
                    Contact_EmailId = txtEmailId.Text,
                    Contact_Phone = txtPhone.Text,
                    Contact_Fax = txtFax.Text,
                    Contact_WebSite = txtWebSite.Text,
                    Contact_GoogleMapURL = txtGMapUrl.Text,
                    Contact_CreatedDate = DateTime.Now,
                    Contact_UpdatedDate = DateTime.Now,
                    Administrators_Id = adminId
                };

                ContactOwner = bContactOwner.Create(ContactOwner);

                if (String.IsNullOrEmpty(ContactOwner.ErrorMessage))
                {
                    Response.Redirect("/administration/application/contact.aspx?id=100&redirecturl=admin-Logo-rachna-teracotta");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + ContactOwner.ErrorMessage;
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! ContactOwner detail not updated successfully, because ContactOwner name should not be same as other";
            }
        }
    }
}