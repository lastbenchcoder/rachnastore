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

namespace Rachna.Teracotta.Project.Source.administration.menus
{
    public partial class menus : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public menus()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"].ToString() == "200")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Menu", "new Messi('Menu Deleted Successfully.', { title: 'Success!! ' });", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Menu", "new Messi('Menu Created/Updated Successfully.', { title: 'Success!! ' });", true);
                }
            }

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
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                RMenu Menu = new RMenu();
                int pageId = Convert.ToInt32(ddlpage.SelectedValue);
                Menu = context.RMenu.Where(m => m.MenuType == ddlmenutype.Text && m.Title == txtCategory.Text).FirstOrDefault();
                if (Menu == null)
                {
                    RMenu RMenu = new RMenu()
                    {
                        Title = txtCategory.Text,
                        MenuType = ddlmenutype.Text,
                        Page_Id = Convert.ToInt32(ddlpage.SelectedValue),
                        Status = eStatus.Active.ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                    };

                    context.RMenu.Add(RMenu);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sub Category", "new Messi('New Sub Category Created Successfully.', { title: 'Success!! ' });", true);
                    ClearFields();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sub Category", "new Messi('Sub Category cannot be created. Entered Sub Category Name already exists in the database.', { title: 'Failed!! ' });", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sub Category", "new Messi(" + ex.Message + ", { title: 'Error!! ' });", true);
            }
        }
        private void ClearFields()
        {
            ddlpage.SelectedIndex = 0;
            ddlmenutype.SelectedIndex = 0;
            txtCategory.Text = "";
        }
    }
}