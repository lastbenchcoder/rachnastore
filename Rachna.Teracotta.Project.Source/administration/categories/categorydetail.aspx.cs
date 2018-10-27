﻿using Rachna.Teracotta.Project.Source.App_Data;
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
    public partial class categorydetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public categorydetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Category Update";
            if (!IsPostBack)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["catid"].ToString());
                    Categories _category = null;
                    _category = context.Category.Include("Admin").Where(m => m.Category_Id == id).FirstOrDefault();
                    txtCategory.Text = _category.Category_Title;
                    txtAdministrator.Text = _category.Admin.FullName;
                    hdnCatId.Value = id.ToString();
                    lblBcTitle.Text = _category.Category_Title;
                }
                catch (Exception ex)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = ex.InnerException.InnerException.Message;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hdnCatId.Value);
                Categories _otherCat = context.Category.Where(m => m.Category_Id != id && m.Category_Title == txtCategory.Text).FirstOrDefault();
                if (_otherCat == null)
                {
                    Categories Categories = context.Category.Where(m => m.Category_Id == id).FirstOrDefault();
                    Categories.Category_Title = txtCategory.Text;
                    Categories.Category_UpdatedDate = DateTime.Now;
                    Categories.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()]);

                    context.Entry(Categories).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    Response.Redirect("/administration/categories/category.aspx?id=2000&redirecturl=admin-category-RachnaTeracotta");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Category not updated successfully, category name should not be same as other";
                }

            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.InnerException.InnerException.Message;
            }
        }
    }
}