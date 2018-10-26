using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.pages
{
    public partial class newpage : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public newpage()
        {
            context = new RachnaDBContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());

            Pages Pages = new Pages()
            {
                Administrators_Id = Administrators_Id,
               Title=txtOfferTitle.Text,
               Description=txtSmallDescription.Text,
               DateCreated=DateTime.Now,
               DateUpdated=DateTime.Now,
               Status=eStatus.Active.ToString()
            };

            context.Pages.Add(Pages);
            context.SaveChanges();
            Response.Redirect("/administration/pages/allpages.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }
    }
}