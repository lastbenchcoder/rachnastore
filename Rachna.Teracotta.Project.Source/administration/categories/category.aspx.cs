using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.categories
{
    public partial class category : System.Web.UI.Page
    {
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
                _category1 = bCategory.List().Where(m => m.Category_Title == txtCategory.Text).FirstOrDefault();
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                if (_category1 == null)
                {
                    Categories Categories = new Categories()
                    {
                        Category_Title = txtCategory.Text,
                        Administrators_Id = adminId,
                        Category_Photo = (imgInp.HasFile) ? "files/category/" + "Category_" + imgInp.FileName : "content/noimage.png",
                        Category_CreatedDate = DateTime.Now,
                        Category_UpdatedDate = DateTime.Now,
                        Category_Status = eStatus.Active.ToString()
                    };

                    Categories = bCategory.Create(Categories);
                    ActivityHelper.Create("New Category", "New Category Created On " + DateTime.Now.ToString("D") + " Successfully and Title is " + Categories.Category_Title + ".", adminId);

                    if ((Categories.Category_Id != null || Categories.Category_Id != 0) && imgInp.HasFile)
                    {
                        Upload();
                    }

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
        private void Upload()
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("~/files/category/");
                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    imgInp.SaveAs(folderPath + Path.GetFileName("Category" + "_" + imgInp.FileName));
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected Category Banner should not be higher than 1MB.";
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