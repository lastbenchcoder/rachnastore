using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
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
                _category = bCategory.List().Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
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
                _category1 = bSubCategory.List().Where(m => m.Category_Id == catId && m.SubCategory_Title == txtCategory.Text).FirstOrDefault();
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                if (_category1 == null)
                {
                    SubCategories SubCategories = new SubCategories()
                    {
                        SubCategory_Title = txtCategory.Text,
                        Administrators_Id = adminId,
                        Category_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                        SubCategory_CreatedDate = DateTime.Now,
                        SubCategory_UpdatedDate = DateTime.Now,
                        SubCategory_Status = eStatus.Active.ToString()
                    };

                    bSubCategory.Create(SubCategories);
                    ActivityHelper.Create("New Sub Category", "New Sub Category Created On " + DateTime.Now.ToString("D") + " Successfully and Title is " + SubCategories.SubCategory_Title + ".", adminId);

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
