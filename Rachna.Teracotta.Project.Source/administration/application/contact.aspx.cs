using System;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.administration.application
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Contact Owner";
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"] == "100")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Contact Owner Detail Created Successfully";
                }
            }
        }
    }
}