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
                    getLoginUsers(_admin);
                    pnlErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    if (_admin.Admin_Role == eRole.Super.ToString() || _admin.Admin_Role == eRole.Developer.ToString())
                    {
                        Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()] = _admin.Administrators_Id;
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
                            Response.Redirect("/administration/default.aspx?redirecturl=rachna-teracotta-home");
                        }

                    }
                    else if (_admin.Admin_Role == eRole.Approver.ToString())
                    {
                        Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()] = _admin.Administrators_Id;
                        if (_admin.Admin_Login_Attempt != 0)
                        {
                            _admin.Admin_Login_Attempt = 0;
                            _admin.Admin_UpdatedDate = DateTime.Now;
                            _admin = bAdministrator.Update(_admin);
                        }
                        //Response.Redirect("/admapprover/default.aspx?redirecturl=rachna-teracotta-home");
                        Response.Redirect("/account/inprogress.aspx?redirecturl=rachna-teracotta-home");
                    }
                    else if (_admin.Admin_Role == eRole.Publisher.ToString())
                    {
                        Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()] = _admin.Administrators_Id;
                        if (_admin.Admin_Login_Attempt != 0)
                        {
                            _admin.Admin_Login_Attempt = 0;
                            _admin.Admin_UpdatedDate = DateTime.Now;
                            _admin = bAdministrator.Update(_admin);
                        }
                        //Response.Redirect("/admpublisher/default.aspx?redirecturl=rachna-teracotta-home");
                        Response.Redirect("/account/inprogress.aspx?redirecturl=rachna-teracotta-home");
                    }
                    else
                    {
                        Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()] = _admin.Administrators_Id;
                        if (_admin.Admin_Login_Attempt != 0)
                        {
                            _admin.Admin_Login_Attempt = 0;
                            _admin.Admin_UpdatedDate = DateTime.Now;
                            _admin = bAdministrator.Update(_admin);
                        }
                        //Response.Redirect("/adminvendor/default.aspx?redirecturl=rachna-teracotta-home");
                        Response.Redirect("/account/inprogress.aspx?redirecturl=rachna-teracotta-home");
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

        public void getLoginUsers(Administrators administrators)
        {
            if (administrators.Administrators_Id != null)
            {
                //if the list exists, add this user to it
                if (HttpRuntime.Cache["LoggedInUsers"] != null)
                {
                    //get the list of logged in users from the cache
                    var loggedInUsers = (Dictionary<string, DateTime>)HttpRuntime.Cache["LoggedInUsers"];

                    if (!loggedInUsers.ContainsKey(administrators.EmailId))
                    {
                        //add this user to the list
                        loggedInUsers.Add(administrators.EmailId, DateTime.Now);
                        //add the list back into the cache
                        HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                    }
                }

                //the list does not exist so create it
                else
                {
                    //create a new list
                    var loggedInUsers = new Dictionary<string, DateTime>();
                    //add this user to the list
                    loggedInUsers.Add(administrators.EmailId, DateTime.Now);
                    //add the list into the cache
                    HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                }
            }
        }
    }
}