using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.uc
{
    public partial class _ucleftmenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchPrdHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/product/productsdetailstatic.aspx?productid=" + txtSearchHome.Text);
        }
    }
}