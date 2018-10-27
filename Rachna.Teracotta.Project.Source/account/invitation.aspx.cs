using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.account
{
    public partial class invitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["code"].ToString();
            string emailid = Request.QueryString["emailid"].ToString();

            Invitations _invit = bInvitations.List().Where(m => m.Invitation_Code == code).FirstOrDefault();
            if(_invit==null)
            {
                Response.Redirect("/account/success.aspx?success=invitation-invalid");                
            }
            else if (_invit.Invitation_Status != eStatus.Active.ToString())
            {
                Response.Redirect("/account/success.aspx?success=invitation-expired");
            }
            else
            {
                Panel1.Visible = true;
                hdnCode.Value = code;
                txtEmail.Text = emailid;
            }
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Invitations";
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            Invitations _invit = bInvitations.List().Where(m => m.Invitation_Code == hdnCode.Value).FirstOrDefault();

            if (_invit.Invitation_Status != eStatus.Active.ToString())
            {
                Response.Redirect("/account/success.aspx?success=invitation-expired");
            }

            Administrators _administrators = bAdministrator.List().Where(m => m.Phone == txtPhone.Text).FirstOrDefault();
            if (_administrators == null)
            {
                Administrators Administrators = new Administrators()
                {
                    FullName = "Name Required",
                    EmailId = txtEmail.Text,
                    Invitation_Id=_invit.Invitation_Id,
                    Phone = txtPhone.Text,
                    Description = "Please Enter about yourself",
                    Photo = "content/noimage.png",
                    Password = txtPassword.Text,
                    Admin_Status = eStatus.Active.ToString(),
                    Admin_CreatedDate = DateTime.Now,
                    Admin_UpdatedDate = DateTime.Now,
                    Admin_Login_Attempt = 0,
                    Store_Id = _invit.Store_Id,
                    Admin_Role = _invit.Role
                };

                Administrators = bAdministrator.Create(Administrators);

                _invit.Invitation_Status = eStatus.InActive.ToString();
                _invit.Invitation_UpdatedDate = DateTime.Now;

                _invit = bInvitations.Update(_invit);

                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string body = MailHelper.AccountCreated(Administrators.FullName, Administrators.EmailId, Administrators.Password, Administrators.Admin_Role);
                    string mail_result = MailHelper.SendEmail(Administrators.EmailId, "[Rachna Teracotta] - New Account Creation", body, "[Rachna Teracotta] - New Account Creation");
                }

                Response.Redirect("success.aspx?success=invitation");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Failed!!! Entered phone number already exists, please choose different phone number.";
            }
        }
    }
}