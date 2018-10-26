using Rachna.Teracotta.Project.Source.App_Data;
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
    public partial class pagedetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public pagedetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["pageid"].ToString();
                hdnPageId.Value = id;
                if (!IsPostBack)
                {
                    int pageId = Convert.ToInt32(id);
                    Pages Pages = context.Pages.Where(m => m.Page_Id == pageId).FirstOrDefault();
                    txtOfferTitle.Text = Pages.Title;
                    txtSmallDescription.Text = Pages.Description;
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int pageId = Convert.ToInt32(hdnPageId.Value);
            Pages Pages = context.Pages.Where(m => m.Page_Id == pageId).FirstOrDefault();

            Pages.Administrators_Id = Administrators_Id;
            Pages.Title = txtOfferTitle.Text;
            Pages.Description = txtSmallDescription.Text;
            Pages.DateUpdated = DateTime.Now;

            context.Entry(Pages).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Response.Redirect("/administration/pages/allpages.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int pageId = Convert.ToInt32(hdnPageId.Value);
            Pages Pages = context.Pages.Where(m => m.Page_Id == pageId).FirstOrDefault();
            context.Entry(Pages).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Response.Redirect("/administration/pages/allpages.aspx?id=200&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }
    }
}