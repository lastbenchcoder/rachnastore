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
    public partial class subcategorydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Category Update";
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["catid"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["catid"].ToString());

                        List<Categories> _category = new List<Categories>();
                        _category = bCategory.List().Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                        foreach (var item in _category)
                        {
                            ddlCategory.Items.Add(new ListItem { Text = item.Category_Title, Value = item.Category_Id.ToString() });
                        }

                        SubCategories _subCategory = null;
                        _subCategory = bSubCategory.List().Where(m => m.SubCategory_Id == id).FirstOrDefault();

                        txtCategory.Text = _subCategory.SubCategory_Title;
                        lblAdministrator.Text = _subCategory.Admin.FullName;
                        ddlCategory.SelectedValue = _subCategory.Category_Id.ToString();
                        hdnCatId.Value = id.ToString();
                        hdnCurrentSubCatCatId.Value = _subCategory.Category_Id.ToString();
                        lblBcTitle.Text = _subCategory.SubCategory_Title;
                        chkIsActive.Checked = (_subCategory.SubCategory_Status == eStatus.Active.ToString()) ? true : false;
                    }
                    else
                    {
                        Response.Redirect("/administration/default.aspx?id=rachna-tecotta-admin.htm");
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sub Category", "new Messi(" + ex.Message + ", { title: 'Error!! ' });", true);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int subCatId = Convert.ToInt32(hdnCatId.Value);
                int catId = Convert.ToInt32(hdnCurrentSubCatCatId.Value);
                SubCategories _otherSubCat = bSubCategory.List().Where(m => m.Category_Id == catId && m.SubCategory_Id != subCatId & m.SubCategory_Title == txtCategory.Text).FirstOrDefault();
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()]);
                if (_otherSubCat == null)
                {
                    SubCategories SubCategories = bSubCategory.List().Where(m => m.SubCategory_Id == subCatId).FirstOrDefault();
                    SubCategories.SubCategory_Title = txtCategory.Text;
                    SubCategories.SubCategory_UpdatedDate = DateTime.Now;
                    SubCategories.Administrators_Id = adminId;
                    SubCategories.Category_Id = Convert.ToInt32(ddlCategory.SelectedValue);
                    SubCategories.SubCategory_Status = (chkIsActive.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();

                    bSubCategory.Update(SubCategories);
                    ActivityHelper.Create("Update Sub Category", "Sub Category Updated On " + DateTime.Now.ToString("D") + " Successfully and Title is " + SubCategories.SubCategory_Title + ".", adminId);

                    Response.Redirect("/administration/categories/subcategory.aspx?id=2000&redirecturl=admin-category-RachnaTeracotta");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Sub Category not updated successfully, sub category name should not be same as other.";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! "+ ex.Message.ToString();
            }
        }
    }
}