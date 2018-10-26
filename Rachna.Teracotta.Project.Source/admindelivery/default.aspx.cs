using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.admindelivery
{
    public partial class _default : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public _default()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                lblMessage.Text = "Oops!! Session Ended, Please enter delievery code to proceed.";
            }
        }

        protected void btnDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                DeleveryTeam _admin = context.DeleveryTeam.Where(m => m.TeamCode == txtDeliveryId.Text).FirstOrDefault();
                if (_admin != null)
                {
                    Session["DelieveryKey"] = _admin.TeamId;
                    Response.Redirect("/admindelivery/deliveryhome.aspx?redirecturl=rachna-teracotta-home");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Failed Please enter valid Delivery Team Code.";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Failed Please enter valid Delivery Team Code.";
            }
        }
    }
}