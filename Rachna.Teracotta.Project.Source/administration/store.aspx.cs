using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page3.Project.Source.administration
{
    public partial class store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Stores";
            if (Request.QueryString["id"] != null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Store Detail Updated Successfully";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Stores Stores1 = bStores.List().Where(m => m.Store_Name == txtStoreName.Text.Trim()).FirstOrDefault();
            if (Stores1 == null)
            {
                Stores stores = new Stores()
                {
                    Store_Name = txtStoreName.Text.Trim(),
                    Store_Logo = "files/store/" + "Store_" + imgInp.FileName,
                    Store_Status = eStatus.Active.ToString(),
                    Store_Description = txtDescription.Text,                    
                    Store_CreatedDate = DateTime.Now,
                    Store_UpdatedDate = DateTime.Now
                };

                stores = bStores.Create(stores);
                ActivityHelper.Create("New Store Creation", "New Store Created On " +
                       DateTime.Now.ToString("D") + " Successfully, for Store Name " + stores.Store_Name + ".",
                       Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()));

                if (String.IsNullOrEmpty(stores.ErrorMessage))
                {
                    Upload();

                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Store Detail Updated Successfully";
                    ClearFields();
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!" + stores.ErrorMessage;
                }
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Store detail not updated successfully, because store name should not be same as other";
            }
        }


        private void ClearFields()
        {
            txtStoreName.Text = "";
        }

        private void Upload()
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("~/files/store/");
                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    imgInp.SaveAs(folderPath + Path.GetFileName("Store" + "_" + imgInp.FileName));
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected Store Banner should not be higher than 1MB.";
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