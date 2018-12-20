using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.adminvendor
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Check();
            }
        }
        protected void Check()
        {
            if (Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()] == null)
            {
                string url = HttpContext.Current.Request.Url.PathAndQuery;
                Session["PreviousUrl"] = url;
                Response.Redirect("~/account/logout.aspx?logout=100&redUrl=HGHGH786876");
            }
        }
    }
}