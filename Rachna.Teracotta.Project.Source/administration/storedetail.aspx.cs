using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;

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

namespace Rachna.Teracotta.Project.Source.administration
{
    public partial class storedetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Stores";
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    hdnStoreId.Value = Request.QueryString["id"].ToString();
                    int storeId = Convert.ToInt32(Request.QueryString["id"].ToString());

                    Array status = Enum.GetValues(typeof(eStatus));
                    foreach (eStatus sts in status)
                    {
                        ddlStatus.Items.Add(new ListItem(sts.ToString()));
                    }

                    Stores _stores = bStores.List().Where(m => m.Store_Id == storeId).FirstOrDefault();

                    txtStoreName.Text = _stores.Store_Name;
                    txtDescription.Text = _stores.Store_Description;
                    ddlStatus.Text = _stores.Store_Status;
                    imgArticle.ImageUrl = "~/" + _stores.Store_Logo;
                    txtImageUrl.Text = _stores.Store_Url;
                    ddlStatus.Text = _stores.Store_Status;
                    lblBcTitle.Text= _stores.Store_Name;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int storeId = Convert.ToInt32(hdnStoreId.Value);
            Stores _otherStr = bStores.List().Where(m => m.Store_Id != storeId && m.Store_Name == txtStoreName.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                Stores stores = bStores.List().Where(m => m.Store_Id == storeId).FirstOrDefault();
                stores.Store_Name = txtStoreName.Text;
                stores.Store_Url = txtImageUrl.Text;
                stores.Store_Status = ddlStatus.Text;
                stores.Store_UpdatedDate = DateTime.Now;
                stores.Store_Description = txtDescription.Text;
                if (imgInp.HasFile)
                {
                    stores.Store_Logo = "files/store/" + "Store_" + stores.Store_Id + ".png";
                    string path = Server.MapPath("../" + stores.Store_Logo);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not
                    {
                        file.Delete();
                    }
                    Upload(stores.Store_Id);
                }

                stores.Store_Url = "?storecode=" + stores.StoreCode + "&redirect-url=" + stores.Store_Name.Trim() + ".html";
                stores = bStores.Update(stores);

                if (String.IsNullOrEmpty(stores.ErrorMessage))
                {
                    Response.Redirect("/administration/store.aspx?id=100&redirecturl=admin-store-rachna-teracotta");
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

        private void Upload(int storeId)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/store/");               

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                imgInp.SaveAs(folderPath + Path.GetFileName("Store" + "_" + storeId + ".png"));
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