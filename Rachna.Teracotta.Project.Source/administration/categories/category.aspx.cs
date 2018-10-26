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

namespace Rachna.Teracotta.Project.Source.administration.categories
{
    public partial class category : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public category()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Category";
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success!!! Category Updated Successfully.";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Categories _category1 = new Categories();
                _category1 = context.Category.Where(m => m.Category_Title == txtCategory.Text).FirstOrDefault();
                if (_category1 == null)
                {
                    Categories Categories = new Categories()
                    {
                        Category_Title = txtCategory.Text,
                        Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                        Category_CreatedDate = DateTime.Now,
                        Category_UpdatedDate = DateTime.Now,
                        Category_Status = eStatus.Active.ToString()
                    };


                    int maxAdminId = 1;
                    if (context.Category.ToList().Count > 0)
                        maxAdminId = context.Category.Max(m => m.Category_Id);
                    maxAdminId = (maxAdminId == 1 && context.Category.ToList().Count > 0) ? (maxAdminId + 1) : maxAdminId;
                    Categories.CategoryCode = "CATRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
                    context.Category.Add(Categories);

                    context.SaveChanges();
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success!!! Category Created Successfully.";
                    txtCategory.Text = "";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Category cannot be created. Entered Category Name already exists in the database.";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
    }
}