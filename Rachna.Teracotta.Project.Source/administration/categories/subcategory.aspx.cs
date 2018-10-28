using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.categories
{
    public partial class subcategory : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public subcategory()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Sub Category";
            if (Request.QueryString["id"] != null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Sub Category Updated Successfully.";
            }
            if (!IsPostBack)
            {
                List<Categories> _category = new List<Categories>();
                _category = context.Category.Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in _category)
                {
                    ddlCategory.Items.Add(new ListItem { Text = item.Category_Title, Value = item.Category_Id.ToString() });
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SubCategories _category1 = new SubCategories();
                int catId = Convert.ToInt32(ddlCategory.SelectedValue);
                _category1 = context.SubCategory.Where(m => m.Category_Id == catId && m.SubCategory_Title == txtCategory.Text).FirstOrDefault();
                if (_category1 == null)
                {
                    SubCategories SubCategories = new SubCategories()
                    {
                        SubCategory_Title = txtCategory.Text,
                        Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                        Category_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                        SubCategory_CreatedDate = DateTime.Now,
                        SubCategory_UpdatedDate = DateTime.Now,
                        SubCategory_Status = eStatus.Active.ToString()
                    };

                    int maxAdminId = 0;
                    if (context.SubCategory.ToList().Count > 0)
                        maxAdminId = context.SubCategory.Max(m => m.SubCategory_Id);
                    maxAdminId = (maxAdminId > 0) ? (maxAdminId + 1) : 1;
                    SubCategories.SubCategoryCode = "SCATRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
                    context.SubCategory.Add(SubCategories);

                    context.SaveChanges();
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "New Sub Category Created Successfully..";
                    ClearFields();
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Sub Category cannot be created. Entered Sub Category Name already exists in the database.";
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
        private void ClearFields()
        {
            ddlCategory.SelectedIndex = 0;
            txtCategory.Text = "";
        }
    }
}
