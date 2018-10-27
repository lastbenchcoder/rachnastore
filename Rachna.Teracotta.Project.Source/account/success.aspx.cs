using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.account
{
    public partial class success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Success";
            if (Request.QueryString["success"] != null)
            {
                if (Request.QueryString["success"].ToString() == "forgot-pwd")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Green;
                    lblPasswordSuccessMsg.Text = "Your Password link has been sent to your email id, please check your email-id.";
                }
                else if (Request.QueryString["success"].ToString() == "reset-pwd")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Green;
                    lblPasswordSuccessMsg.Text = "Your Password updated successfully, please login to your account.";
                }
                else if (Request.QueryString["success"].ToString() == "request")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Green;
                    lblPasswordSuccessMsg.Text = "Thank you for your request, your request has been raised and further communication to communicated via email.";
                }
                else if (Request.QueryString["success"].ToString() == "invitation")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Green;
                    lblPasswordSuccessMsg.Text = "Congragulations!!! Your account created successfully. Now you can login to your account.";
                }
                else if (Request.QueryString["success"].ToString() == "invitation-expired")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Red;
                    lblPasswordSuccessMsg.Text = "Failed!!! Unable to process your request, your invitation may expired or deleted from admin. Please contact administrator.";
                }
                else if (Request.QueryString["success"].ToString() == "invitation-invalid")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Red;
                    lblPasswordSuccessMsg.Text = "Failed!!! Unable to process your request, your invitation request is not valid. Please contact administrator.";
                }
            }
        }
    }
}