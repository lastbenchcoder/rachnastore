using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.setup
{
    public partial class security : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityToken"] != null)
                Session["SecurityToken"] = null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSecurityId.Text == System.Configuration.ConfigurationManager.AppSettings["AppSecurityTokenId"].ToString())
            {
                Session["SecurityToken"] = txtSecurityId.Text;
                Response.Redirect("/setup/home.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Please enter valid security token id. Entered token id is invalid.";
            }
        }
    }
}