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
    public partial class contactdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Contact Owner Detail";
            if (Request.QueryString["ContactOwnerid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnContactOwnerId.Value = Request.QueryString["ContactOwnerid"].ToString();
                    int ContactOwnerId = Convert.ToInt32(Request.QueryString["ContactOwnerid"].ToString());

                    ContactOwner _ContactOwner = bContactOwner.List().Where(m => m.Contact_Owner_Id == ContactOwnerId).FirstOrDefault();

                    txtTitle.Text = _ContactOwner.Contact_Title;
                    txtDescription.Text = _ContactOwner.Contact_Description;
                    chkIsDefault.Checked = (_ContactOwner.Contact_Status == eStatus.Active.ToString()) ? true : false;
                    chkSubmitRequest.Checked = (_ContactOwner.Contact_Query_Submission == "Y") ? true : false;
                    txtAddress.Text = _ContactOwner.Contact_Address;
                    txtCity.Text = _ContactOwner.Contact_City;
                    txtState.Text = _ContactOwner.Contact_State;
                    txtZip.Text = _ContactOwner.Contact_ZipCode.ToString();
                    txtEmailId.Text = _ContactOwner.Contact_EmailId;
                    txtPhone.Text = _ContactOwner.Contact_Phone;
                    txtFax.Text = _ContactOwner.Contact_Fax;
                    txtWebSite.Text = _ContactOwner.Contact_WebSite;
                    txtGMapUrl.Text = _ContactOwner.Contact_GoogleMapURL;
                    lblBcTitle.Text = _ContactOwner.Contact_Title;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int ContactOwnerId = Convert.ToInt32(hdnContactOwnerId.Value);
            ContactOwner _otherStr = bContactOwner.List().Where(m => m.Contact_Owner_Id != ContactOwnerId && m.Contact_Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                ContactOwner ContactOwner = bContactOwner.List().Where(m => m.Contact_Owner_Id == ContactOwnerId).FirstOrDefault();
                ContactOwner.Administrators = null;
                ContactOwner.Contact_Title = txtTitle.Text;
                ContactOwner.Contact_Description = txtDescription.Text;
                ContactOwner.Contact_Address = txtAddress.Text;
                ContactOwner.Contact_City = txtCity.Text;
                ContactOwner.Contact_State = txtState.Text;
                ContactOwner.Contact_ZipCode = Convert.ToInt32(txtZip.Text);
                ContactOwner.Contact_EmailId = txtState.Text;
                ContactOwner.Contact_Phone = txtPhone.Text;
                ContactOwner.Contact_Fax = txtFax.Text;
                ContactOwner.Contact_WebSite = txtWebSite.Text;
                ContactOwner.Contact_GoogleMapURL = txtGMapUrl.Text;
                ContactOwner.Contact_Status = (chkIsDefault.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                ContactOwner.Contact_Query_Submission = (chkSubmitRequest.Checked) ? "Y" : "N";
                ContactOwner.Contact_UpdatedDate = DateTime.Now;
                ContactOwner.Administrators_Id = adminId;
                
                ContactOwner = bContactOwner.Update(ContactOwner);

                if (String.IsNullOrEmpty(ContactOwner.ErrorMessage))
                {
                    Response.Redirect("/administration/application/contact.aspx?id=200&redirecturl=admin-ContactOwner-rachna-teracotta");
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