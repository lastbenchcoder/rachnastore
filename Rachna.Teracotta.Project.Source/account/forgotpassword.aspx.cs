using Rachna.Teracotta.Project.Source.App_Data;
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
    public partial class forgotpassword : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public forgotpassword()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Forgot Password";
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Administrators _admin = context.Administrator.Where(m => m.EmailId == txtUserName.Text).FirstOrDefault();

            if (_admin == null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Oops!!! Entered EmailId Does not exists in our database.";
            }
            else
            {
                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string host = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
                    host = host + "account/passwordreset.aspx?emailid=" + txtUserName.Text;
                    string body = MailHelper.PasswordResetLink(host);
                    MailHelper.SendEmail(txtUserName.Text, "Password Reset Link", body, "Password Admin");
                    Response.Redirect("success.aspx?success=forgot-pwd");
                }
                else
                {
                    Response.Redirect("passwordreset.aspx?emailid=" + txtUserName.Text);
                }
            }
        }
    }
}