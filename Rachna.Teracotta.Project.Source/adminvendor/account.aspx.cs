using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
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

namespace Rachna.Teracotta.Project.Source.adminvendor
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Account Setting";
            try
            {
                hdnAdminId.Value = Request.QueryString["adminid"].ToString();
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.InnerException.InnerException.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int adminId = Convert.ToInt32(hdnAdminId.Value);
                Administrators administrators = bAdministrator.List().Where(m => m.Administrators_Id == adminId).FirstOrDefault();
                administrators.Admin_UpdatedDate = DateTime.Now;
                administrators.Password = txtPassword.Text;
                administrators = bAdministrator.Update(administrators);
                ActivityHelper.Create("Password Reset", "Password Updated on " + DateTime.Now.ToString("D") + " Successfully", adminId);
                if (string.IsNullOrEmpty(administrators.ErrorMessage))
                {
                    Response.Redirect("~/account/logout.aspx?logout=1000&redUrl=HGHGH786876");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + administrators.ErrorMessage;
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