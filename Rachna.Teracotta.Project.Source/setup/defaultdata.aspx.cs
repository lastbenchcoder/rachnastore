using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.setup
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityToken"] != null)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Default SetUp Data";
            }
            else
            {
                Response.Redirect("/setup/security.aspx");
            }
        }
    }
}