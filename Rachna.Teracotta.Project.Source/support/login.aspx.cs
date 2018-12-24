﻿using Rachna.Teracotta.Project.Source.App_Data;
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

namespace Rachna.Teracotta.Project.Source.support
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["a4rredirectUrl"] != null)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Login";
            }
            else
            {
                Response.Redirect("/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979");
            }
            if (!IsPostBack)
            {
                FilesHelper.DeleteFilesOlderThen5Days();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Administrators _admin = bAdministrator.List().Where(m => m.EmailId == txtUserName.Text).FirstOrDefault();

                if (_admin == null)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Oops!!! No entered email id exists in our database.";
                }
                else if (_admin.Admin_Status == "inactive")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Oops!!! Cannot login to your account, becaues your account is inactive. Please raise request to activate your account.";
                }
                else if (_admin.Admin_Login_Attempt > 5)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Oops!!! Cannot login to your account, becaues your account is locked. Please raise request to unlock your account.";
                }
                else if (_admin.Password != txtPassword.Text && _admin.Admin_Login_Attempt < 5)
                {
                    _admin.Admin_Login_Attempt = (_admin.Admin_Login_Attempt + 1);
                    _admin.Admin_UpdatedDate = DateTime.Now;
                    _admin = bAdministrator.Update(_admin);
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Oops!!! Entered password is invalid for entered emailid.";
                }
                else
                {
                    ActivityHelper.Create("Login", "Loogged In on " + DateTime.Now.ToString("D") + " Successfully", _admin.Administrators_Id);
                    pnlErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    if (_admin.Admin_Role != eRole.Vendor.ToString())
                    {
                        Session[ConfigurationSettings.AppSettings["SupportSession"].ToString()] = _admin.Administrators_Id;
                        if (_admin.Admin_Login_Attempt != 0)
                        {
                            _admin.Admin_Login_Attempt = 0;
                            _admin.Admin_UpdatedDate = DateTime.Now;
                            _admin = bAdministrator.Update(_admin);
                        }
                        if (Session["PreviousUrl"] != null)
                        {
                            Response.Redirect(Session["PreviousUrl"].ToString(), false);
                        }
                        else
                        {
                            Response.Redirect("/support/home/default.aspx?redirecturl=rachna-teracotta-home");
                        }
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblErrorMessage.Text = "Oops!! You are not authorized user to access this page.";
                    }
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Oops!! Server error occured, please contact administrator.";
            }
        }
    }
}