using Rachna.Teracotta.Project.Source.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source
{
    public partial class appsetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Application SetUp";
        }

        protected void btnSetUp_Click(object sender, EventArgs e)
        {
            Migrations.Configuration AppSetUp = new Migrations.Configuration();
            AppSetUp.ApplicationSetUp();
            lblMessage.Text = "Success!! Application set up completed successfully.";
        }
    }
}