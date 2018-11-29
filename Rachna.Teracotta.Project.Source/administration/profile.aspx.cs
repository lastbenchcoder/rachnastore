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

namespace Rachna.Teracotta.Project.Source.administration
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Profile Update";
                string id = Request.QueryString["adminid"].ToString();
                hdnAdminId.Value = id;
                if (!IsPostBack)
                {
                    Array status = Enum.GetValues(typeof(eStatus));
                    foreach (eStatus sts in status)
                    {
                        ddlStatus.Items.Add(new ListItem(sts.ToString()));
                    }

                    Array roles = Enum.GetValues(typeof(eRole));
                    foreach (eRole rls in roles)
                    {
                        ddlRole.Items.Add(new ListItem(rls.ToString()));
                    }
                    LoadDetail(id);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/account/logout.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int adminId = Convert.ToInt32(hdnAdminId.Value);
                Administrators administrators = bAdministrator.List().Where(m => m.Administrators_Id == adminId).FirstOrDefault();

                administrators.FullName = txtFullname.Text;
                administrators.EmailId = txtEmailId.Text;
                administrators.Description = txtDescription.Text;
                administrators.Phone = txtPhone.Text;
                administrators.Admin_Status = ddlStatus.Text;
                administrators.Admin_Role = ddlRole.Text;
                administrators.Photo = administrators.Photo;
                administrators.Store_Id = Convert.ToInt32(ddlStore.SelectedValue);

                if (imgInp.HasFile)
                {
                    administrators.Photo = "files/administrators/" + "Admin_" + administrators.Administrators_Id + ".png";
                    administrators = bAdministrator.Update(administrators);
                    if (string.IsNullOrEmpty(administrators.ErrorMessage))
                    {
                        string path = Server.MapPath("../" + administrators.ProductBanner);
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                        Upload(administrators.Administrators_Id.ToString());
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Failed!" + administrators.ErrorMessage;
                    }
                }
                else
                {
                    administrators.Admin_UpdatedDate = DateTime.Now;
                    administrators = bAdministrator.Update(administrators);
                }

                ActivityHelper.Create("Profile Updaion", "Admin Profile Updated On " +
                       DateTime.Now.ToString("D") + " Successfully, for EmailId " + administrators.EmailId + ".",
                       Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()));

                LoadDetail(administrators.Administrators_Id.ToString());
                Response.Redirect("/administration/alladmin.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        private void Upload(string Id)
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("~/files/administrators/");
                    int adminId = Convert.ToInt32(hdnAdminId.Value);
                    Administrators _admin = bAdministrator.List().Where(m => m.Administrators_Id == adminId).FirstOrDefault();

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    Stream strm = imgInp.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        int newWidth = 120; // New Width of Image in Pixel  
                        int newHeight = 120; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = folderPath + "Admin_" + _admin.Administrators_Id + ".png";
                        thumbImg.Save(targetPath, image.RawFormat);
                    }
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected Profile Photo should not be higher than 1MB.";
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
        private void LoadDetail(string id)
        {
            try
            {
                List<Stores> Stores = bStores.List().Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }

                int adminId = Convert.ToInt32(id);
                Administrators _admin = bAdministrator.List().Where(m => m.Administrators_Id == adminId).FirstOrDefault();

                txtFullname.Text = _admin.FullName;
                txtEmailId.Text = _admin.EmailId;
                txtDescription.Text = _admin.Description;
                txtPhone.Text = _admin.Phone;
                imgProduct.ImageUrl = "../" + _admin.Photo;
                ddlRole.Text = _admin.Admin_Role.ToString();
                ddlStatus.Text = _admin.Admin_Status.ToString();
                ddlStore.SelectedValue = _admin.Store_Id.ToString();
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