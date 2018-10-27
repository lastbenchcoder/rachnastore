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
    public partial class invitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Invitations";
            if (!IsPostBack)
            {
                Array roles = Enum.GetValues(typeof(eRole));
                foreach (eRole rls in roles)
                {
                    ddlRole.Items.Add(new ListItem(rls.ToString()));
                }

                List<Stores> Stores = bStores.List().Where(m => m.Store_Status == Entity.eStatus.Active.ToString()).ToList();
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
                Invitations _invitation = bInvitations.List().Where(m => m.Invitation_EmailId == txtEmailId.Text).FirstOrDefault();
                Administrators _administrators = bAdministrator.List().Where(m => m.EmailId == txtEmailId.Text).FirstOrDefault();
                if (_invitation == null && _administrators == null)
                {
                    Invitations invitations = new Invitations()
                    {
                        Store_Id = Convert.ToInt32(ddlStore.SelectedValue),
                        Invitation_Code = Guid.NewGuid().ToString(),
                        Invitation_EmailId = txtEmailId.Text,
                        Invitation_CreatedDate = DateTime.Now,
                        Invitation_Status = eStatus.Active.ToString(),
                        Role = ddlRole.Text,
                        Invitation_UpdatedDate = DateTime.Now
                    };

                    invitations = bInvitations.Create(invitations);

                    if (String.IsNullOrEmpty(invitations.ErrorMessage))
                    {
                        if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                        {
                            _invitation = null;
                            invitations = null;
                            txtEmailId.Text = "";
                            ddlRole.SelectedIndex = 0;
                            ddlStore.SelectedIndex = 0;
                            string host = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
                            host = host + "account/invitation.aspx?code=" + invitations.Invitation_Code + "&emailid=" + invitations.Invitation_EmailId;
                            string body = MailHelper.InvitationLink(host);
                            string mail_result = MailHelper.SendEmail(invitations.Invitation_EmailId, "Hurray!!! You Are Invited To Rachna Teracotta.", body, "Rachna Teracotta Invitation");
                            pnlErrorMessage.Attributes.Remove("class");
                            pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                            pnlErrorMessage.Visible = true;
                            lblMessage.Text = "Success! New Invitation Successfully.";
                        }
                        else
                        {
                            _invitation = null;
                            invitations = null;
                            txtEmailId.Text = "";
                            ddlRole.SelectedIndex = 0;
                            ddlStore.SelectedIndex = 0;
                            pnlErrorMessage.Attributes.Remove("class");
                            pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                            pnlErrorMessage.Visible = true;
                            lblMessage.Text = "Success! New Invitation Successfully.";
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
                    lblMessage.Text = "Oops!! Invitation cannot be created, because entered email id already exists in the database.";
                }
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