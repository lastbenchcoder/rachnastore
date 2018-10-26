using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rachna.Teracotta.Project.Source.Models;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.administration.menus
{
    public partial class menudetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public menudetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Pages> Pages = new List<Pages>();
                Pages = context.Pages.ToList();
                foreach (var item in Pages)
                {
                    ddlpage.Items.Add(new ListItem { Text = item.Title, Value = item.Page_Id.ToString() });
                }

                Array roles = Enum.GetValues(typeof(eMenu));
                foreach (eMenu rls in roles)
                {
                    ddlmenutype.Items.Add(new ListItem(rls.ToString()));
                }

                string id = Request.QueryString["menuId"].ToString();
                hdnPageId.Value = id;
                if (!IsPostBack)
                {
                    int menuId = Convert.ToInt32(id);
                    RMenu RMenu = context.RMenu.Where(m => m.Menu_Id == menuId).FirstOrDefault();
                    txtOfferTitle.Text = RMenu.Title;
                    ddlpage.SelectedValue = RMenu.Page_Id.ToString();
                    ddlmenutype.Text = RMenu.MenuType;
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int pageId = Convert.ToInt32(hdnPageId.Value);
            RMenu RMenu = context.RMenu.Where(m => m.Page_Id == pageId).FirstOrDefault();

            RMenu.Administrators_Id = Administrators_Id;
            RMenu.Title = txtOfferTitle.Text;
            RMenu.MenuType = ddlmenutype.Text;
            RMenu.Page_Id = Convert.ToInt32(ddlpage.SelectedValue);
            RMenu.DateUpdated = DateTime.Now;

            context.Entry(RMenu).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Response.Redirect("/administration/menus/menus.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int pageId = Convert.ToInt32(hdnPageId.Value);
            RMenu RMenu = context.RMenu.Where(m => m.Page_Id == pageId).FirstOrDefault();
            context.Entry(RMenu).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Response.Redirect("/administration/menus/menus.aspx?id=200&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }
    }
}