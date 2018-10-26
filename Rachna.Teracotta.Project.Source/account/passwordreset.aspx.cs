using Rachna.Teracotta.Project.Source.App_Data;
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

namespace Rachna.Teracotta.Project.Source.account
{
    public partial class passwordreset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEmailId.Value = Request.QueryString["emailid"].ToString();
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Password Reset";
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            Administrators _admin = bAdministrator.List().Where(m=>m.EmailId==hdnEmailId.Value).FirstOrDefault();

            _admin.Password = txtPassword.Text;
            _admin.Admin_UpdatedDate = DateTime.Now;

            _admin = bAdministrator.Update(_admin);

            Response.Redirect("success.aspx?success=reset-pwd");

        }
    }
}