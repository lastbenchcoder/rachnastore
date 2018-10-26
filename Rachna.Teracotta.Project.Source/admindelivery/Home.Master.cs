using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.admindelivery
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DelieveryKey"] == null)
            {
                Response.Redirect("/admindelivery/default.aspx?id=200&redirecturl=rachna-teracotta-home");
            }
        }
    }
}