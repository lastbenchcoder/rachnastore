using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.home
{
    public partial class advertisement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Advertisements";
                if (Request.QueryString["id"] != null)
                {
                    if (Request.QueryString["id"] == "2000")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Advertisement Detail Updated Successfully";
                    }
                    else if (Request.QueryString["id"] == "3000")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Advertisement Detail Deleted Successfully";
                    }
                    else if (Request.QueryString["id"] == "404")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Advertisement Detail Failed to Update/Delete, Server Error Occured.";
                    }
                }
                LoadDetail();
            }
        }
        private void LoadDetail()
        {
            try
            {
                List<Ads> _Advertisement = bAds.List().ToList();
                ddlAddType.Items.Clear();

                List<string> ads = new List<string>();

                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 1").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 1");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 2").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 2");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 3").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 3");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 4").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 4");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 5").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 5");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 6").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 6");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 7").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 7");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 8").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 8");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 9").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 9");
                }
                if (_Advertisement.Where(m => m.Ads_Type == "Advertisement 10").FirstOrDefault() == null)
                {
                    ads.Add("Advertisement 10");
                }

                foreach (var item in ads)
                {
                    ddlAddType.Items.Add(new ListItem { Text = item });
                }

                if (_Advertisement.Count > 5)
                {
                    btnSubmit.Visible = false;
                }
                else
                {
                    btnSubmit.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Advertisement", "new Messi(" + ex.Message + ", { title: 'Error!! ' });", true);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Ads Advertisement = new Ads()
                {
                    Ads_Type = ddlAddType.Text,
                    Ads_Banner_Or_Source = "files/advertisement/advertisement_" + imgInp.FileName,
                    Ads_RedirectUrl = txtImageUrl.Text,
                    Ads_CreatedDate = DateTime.Now,
                    Ads_UpdatedDate = DateTime.Now,
                    Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString())
                };

                Advertisement = bAds.Create(Advertisement);

                if (String.IsNullOrEmpty(Advertisement.ErrorMessage))
                {
                    Upload();

                    txtImageUrl.Text = "";
                    ddlAddType.SelectedIndex = 0;
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "New Advertisement created successfully.";

                    LoadDetail();
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed! " + Advertisement.ErrorMessage;
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
                string folderPath = Server.MapPath("~/files/advertisement/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                imgInp.SaveAs(folderPath + Path.GetFileName("advertisement_" + imgInp.FileName));
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int adsId = (Convert.ToInt32(e.Values[0].ToString()));
                Ads _Advertisement = bAds.List().Where(m => m.Ads_Id == adsId).FirstOrDefault();

                int result = bAds.Delete(_Advertisement);

                if (result == 100)
                {
                    string filePath = Server.MapPath("~/" + _Advertisement.Ads_Banner_Or_Source);
                    FileInfo file = new FileInfo(filePath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    LoadDetail();
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Advertisement deleted successfully.";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Server Error Occured, Please Try after some time, if exists again contact to the administrator.";
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