using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.support.home
{
    public partial class functionality : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Functionality Home";
                List<Administrators> Stores = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Stores)
                {
                    ddlDeveloper.Items.Add(new ListItem { Text = item.FullName, Value = item.Administrators_Id.ToString() });
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["SupportSession"].ToString()].ToString());
            int DeveloperId = Convert.ToInt32(ddlDeveloper.SelectedValue);
            Functionality _Functionality = new Functionality()
            {
                Administrators_Id = AdminId,
                Developer_Id = DeveloperId,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Status = eFunctionalityStatus.InProgress.ToString(),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            _Functionality = bFunctionality.Create(_Functionality);
            if (!String.IsNullOrEmpty(_Functionality.ErrorMessage))
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Faied! " + Request.QueryString["errormessage"].ToString();
            }
            else
            {                
                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string mailBody = MailHelper.FunctionalityAddedOrUpdated(_Functionality);
                    string emailIdToSend = string.Empty;
                    List<Administrators> Administrators = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                    foreach (var item in Administrators)
                    {
                        if (item.Admin_Role == eRole.Super.ToString())
                        {
                            if (!string.IsNullOrEmpty(emailIdToSend))
                            {
                                emailIdToSend = emailIdToSend + "," + item.EmailId;
                            }
                            else
                            {
                                emailIdToSend = item.EmailId;
                            }
                        }
                    }
                    string CreatorAdmin = Administrators.Where(m => m.Administrators_Id == _Functionality.Administrators_Id).FirstOrDefault().EmailId;
                    string DeveloperAdmin = Administrators.Where(m => m.Administrators_Id == _Functionality.Developer_Id).FirstOrDefault().EmailId;
                    emailIdToSend = emailIdToSend + ";" + CreatorAdmin;
                    emailIdToSend = emailIdToSend + ";" + DeveloperAdmin;
                    MailHelper.SendEmail(emailIdToSend, "New Functionality Added", mailBody, "Support Team");
                }
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Success! New functionality created successfully";
            }
        }
    }
}