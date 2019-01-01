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
    public partial class functionalitydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Functionality Detail";
            if (!IsPostBack)
            {
                if (Request.QueryString["functionalId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["functionalId"]);
                    hdnFunctionalityId.Value = Request.QueryString["functionalId"].ToString();
                    LoadDetail(id);
                }
            }
        }

        private void LoadDetail(int id)
        {
            List<Administrators> Stores = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
            foreach (var item in Stores)
            {
                ddlDeveloper.Items.Add(new ListItem { Text = item.FullName, Value = item.Administrators_Id.ToString() });
            }

            Array status = Enum.GetValues(typeof(eFunctionalityStatus));
            foreach (eFunctionalityStatus sts in status)
            {
                ddlStatus.Items.Add(new ListItem(sts.ToString()));
            }

            Functionality _functionality = bFunctionality.List().Where(m => m.Function_Id == id).FirstOrDefault();
            lblBcTitle.Text = _functionality.Title;
            txtTitle.Text= _functionality.Title;
            lblFunctionalityName.Text = _functionality.Title;
            txtDescription.Text = _functionality.Description;
            lblFunctionalityDescription.Text = _functionality.Description;
            lblFunctionalityStatus.Text = _functionality.Status;
            lblFunctionalityId.Text = _functionality.Function_Id.ToString();
            lblFunctionalityCode.Text = _functionality.FunctionCode;
            lblDeveloperName.Text = bAdministrator.List().Where(m => m.Administrators_Id == _functionality.Developer_Id).FirstOrDefault().EmailId;
            lblCreatedBy.Text = _functionality.Administrators.EmailId;
            ddlDeveloper.SelectedValue = _functionality.Developer_Id.ToString();
            ddlStatus.Text = _functionality.Status.ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancelEdit.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            ddlDeveloper.Visible = true;
            lblDeveloperName.Visible = false;
            ddlStatus.Visible = true;
            lblFunctionalityStatus.Visible = false;
            txtTitle.Visible = true;
            lblFunctionalityName.Visible = false;
            txtDescription.Visible = true;
            lblFunctionalityDescription.Visible = false;
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            btnCancelEdit.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;

            ddlDeveloper.Visible = false;
            lblDeveloperName.Visible = true;
            ddlStatus.Visible = false;
            lblFunctionalityStatus.Visible = true;
            txtTitle.Visible = false;
            lblFunctionalityName.Visible = true;
            txtDescription.Visible = false;
            lblFunctionalityDescription.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session[ConfigurationSettings.AppSettings["SupportSession"]] != null)
            {
                int id = Convert.ToInt32(hdnFunctionalityId.Value);
                Functionality _functionality = bFunctionality.List().Where(m => m.Function_Id == id).FirstOrDefault();
                _functionality.Title = txtTitle.Text;
                _functionality.Description = txtDescription.Text;
                _functionality.Developer_Id = Convert.ToInt32(ddlDeveloper.SelectedValue);
                _functionality.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["SupportSession"].ToString()].ToString()); ;
                _functionality.Status = ddlStatus.Text;
                _functionality.DateUpdated = DateTime.Now;

                _functionality = bFunctionality.Update(_functionality);
                if (!String.IsNullOrEmpty(_functionality.ErrorMessage))
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
                        string mailBody = MailHelper.FunctionalityAddedOrUpdated(_functionality);
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
                        string CreatorAdmin = Administrators.Where(m => m.Administrators_Id == _functionality.Administrators_Id).FirstOrDefault().EmailId;
                        string DeveloperAdmin = Administrators.Where(m => m.Administrators_Id == _functionality.Developer_Id).FirstOrDefault().EmailId;
                        emailIdToSend = emailIdToSend + ";" + CreatorAdmin;
                        emailIdToSend = emailIdToSend + ";" + DeveloperAdmin;
                        MailHelper.SendEmail(emailIdToSend, "Functionality Updated", mailBody, "Support Team");
                    }
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! functionality updated successfully";

                    btnCancelEdit.Enabled = false;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;

                    ddlDeveloper.Visible = false;
                    lblDeveloperName.Visible = true;
                    ddlStatus.Visible = false;
                    lblFunctionalityStatus.Visible = true;
                    txtTitle.Visible = false;
                    lblFunctionalityName.Visible = true;
                    txtDescription.Visible = false;
                    lblFunctionalityDescription.Visible = true;

                    LoadDetail(id);
                }
            }
        }
    }
}