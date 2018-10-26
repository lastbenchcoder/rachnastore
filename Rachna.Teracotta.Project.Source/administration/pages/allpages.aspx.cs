using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.pages
{
    public partial class allpages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if(Request.QueryString["id"].ToString()=="200")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Pages", "new Messi('Pages Deleted Successfully.', { title: 'Success!! ' });", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Pages", "new Messi('Pages Created/Updated Successfully.', { title: 'Success!! ' });", true);
                    }
                }
            }
        }
    }
}