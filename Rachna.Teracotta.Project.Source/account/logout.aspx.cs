﻿using Rachna.Teracotta.Project.Source.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.account
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailid = string.Empty;
            if (Request.QueryString["logoutEmail"] != null)
            {
                emailid = Request.QueryString["logoutEmail"].ToString();
            }
            var sessionObjects = new List<string>();
            foreach (var item in HttpContext.Current.Session)
            {
                if (item.ToString() != "PreviousUrl")
                {
                    sessionObjects.Add(item.ToString());
                }
            }
            foreach (var item in sessionObjects)
            {
                Session[item] = null;
            }
            if (Request.QueryString["logout"] == "100")
            {
                lblLogoutMessage.Text = "You Have successfully logged out successfully.";
            }
            if (Request.QueryString["logout"] == "1000")
            {
                lblLogoutMessage.Text = "Password Changed Successfully, So you have successfully logged out from application.";
            }
            else
            {
                lblLogoutMessage.Text = "We are sorry!! your account logged out due to inactivity.";
            }
            RemoveLoggedOutUser(emailid);
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Logged Out";
        }

        private void RemoveLoggedOutUser(string emailId)
        {
            var loggedInUsers = (Dictionary<string, DateTime>)HttpRuntime.Cache["LoggedInUsers"];

            if (loggedInUsers != null)
            {
                foreach (var item in loggedInUsers.ToList())
                {
                    if (item.Value < DateTime.Now.AddMinutes(-10))
                    {
                        loggedInUsers.Remove(item.Key);
                    }
                }
                HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
            }

            if (loggedInUsers != null)
            {
                if (!string.IsNullOrEmpty(emailId))
                {
                    foreach (var item in loggedInUsers.ToList())
                    {
                        if (item.Key == emailId)
                        {
                            loggedInUsers.Remove(item.Key);
                        }
                    }

                    HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                }
            }
        }
    }
}