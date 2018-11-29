using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration
{
    public partial class alladmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Administration";
            if (Request.QueryString["id"] != null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Admin Detail Updated Successfully.";
            }

            if (!IsPostBack)
            {
                Array roles = Enum.GetValues(typeof(eRole));
                foreach (eRole rls in roles)
                {
                    ddlRole.Items.Add(new ListItem(rls.ToString()));
                }

                List<Stores> Stores = bStores.List().Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Administrators _admin1 = bAdministrator.List().Where(m => m.EmailId == txtEmailId.Text || m.Phone == txtPhone.Text).FirstOrDefault();
                Invitations Invitation = bInvitations.List().Where(m => m.Invitation_EmailId == txtEmailId.Text).FirstOrDefault();
                if (_admin1 == null && Invitation == null)
                {
                    Invitations invitations = new Invitations()
                    {
                        Store_Id = Convert.ToInt32(ddlStore.SelectedValue),
                        Invitation_Code = Guid.NewGuid().ToString(),
                        Invitation_EmailId = txtEmailId.Text,
                        Invitation_CreatedDate = DateTime.Now,
                        Invitation_Status = eStatus.InActive.ToString(),
                        Role = ddlRole.Text,
                        Invitation_UpdatedDate = DateTime.Now
                    };

                    invitations = bInvitations.Create(invitations);
                    ActivityHelper.Create("New Invitation", "New Invitation Created On " +
                        DateTime.Now.ToString("D") + " Successfully, for EmailId " + invitations.Invitation_EmailId + ".",
                        Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()));

                    if (string.IsNullOrEmpty(invitations.ErrorMessage))
                    {
                        Administrators administrators = new Administrators()
                        {
                            Invitation_Id = invitations.Invitation_Id,
                            FullName = txtFullname.Text,
                            EmailId = txtEmailId.Text,
                            Phone = txtPhone.Text,
                            Description = "admin description should be here",
                            Photo = "content/noimage.png",
                            Password = "admin123",
                            Admin_Status = eStatus.Active.ToString(),
                            Admin_Role = ddlRole.Text,
                            Admin_CreatedDate = DateTime.Now,
                            Admin_UpdatedDate = DateTime.Now,
                            Admin_Login_Attempt = 0,
                            Store_Id = Convert.ToInt32(ddlStore.SelectedValue)
                        };

                        administrators = bAdministrator.Create(administrators);
                        ActivityHelper.Create("New Administrator", "New Administrator Created On " +
                                            DateTime.Now.ToString("D") + " Successfully, for EmailId " + administrators.Administrators_Id + ".",
                                            Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()));

                        if (string.IsNullOrEmpty(administrators.ErrorMessage))
                        {
                            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                            {
                                txtEmailId.Text = "";
                                string body = MailHelper.AccountCreated(administrators.FullName, administrators.EmailId, administrators.Password, administrators.Admin_Role);
                                string mail_result = MailHelper.SendEmail(administrators.EmailId, "[Rachna Teracotta]-New Account Creation", body, "[Rachna Teracotta]-New Account Creation");

                                txtEmailId.Text = "";
                                txtFullname.Text = "";
                                txtPhone.Text = "";
                                ddlStore.SelectedIndex = 0;
                                ddlRole.SelectedIndex = 0;
                                pnlErrorMessage.Attributes.Remove("class");
                                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                                pnlErrorMessage.Visible = true;
                                lblMessage.Text = "Success! Admin Detail Updated Successfully.";
                            }
                            else
                            {
                                txtEmailId.Text = "";
                                txtFullname.Text = "";
                                txtPhone.Text = "";
                                ddlStore.SelectedIndex = 0;
                                ddlRole.SelectedIndex = 0;
                                pnlErrorMessage.Attributes.Remove("class");
                                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                                pnlErrorMessage.Visible = true;
                                lblMessage.Text = "Success! New Admin Account created successfully.";
                            }
                        }
                        else
                        {
                            pnlErrorMessage.Attributes.Remove("class");
                            pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                            pnlErrorMessage.Visible = true;
                            lblMessage.Text = "Failed!" + administrators.ErrorMessage;
                        }
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Failed!" + invitations.ErrorMessage;
                    }
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! You cannot create the admin because admin already exists in the database. Please try with different emailid.";
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