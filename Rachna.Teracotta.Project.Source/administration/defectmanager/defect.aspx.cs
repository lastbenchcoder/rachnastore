using Rachna.Teracotta.Project.Source.App_Data;
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

namespace Rachna.Teracotta.Project.Source.administration.defectmanager
{
    public partial class defect : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public defect()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Defects";
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Defect Detail Updated Successfully.";
                }
                List<Administrators> Administrators = new List<Administrators>();
                Administrators = context.Administrator.Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Administrators)
                {
                    ddlresolver.Items.Add(new ListItem { Text = item.FullName + "(" + item.Admin_Role + ")", Value = item.Administrators_Id.ToString() });
                }

                List<Functionality> Functionality = new List<Functionality>();
                Functionality = context.Functionality.ToList();
                foreach (var item in Functionality)
                {
                    ddlfunctionality.Items.Add(new ListItem { Text = item.Title, Value = item.Function_Id.ToString() });
                }

                Array status = Enum.GetValues(typeof(eFunctionalityStatus));
                foreach (eFunctionalityStatus sts in status)
                {
                    ddlStatus.Items.Add(new ListItem(sts.ToString()));
                }

                Array priority = Enum.GetValues(typeof(ePriority));
                foreach (ePriority sts in priority)
                {
                    ddlpriority.Items.Add(new ListItem(sts.ToString()));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FunctionalDefect FunctionalDefect = new FunctionalDefect()
            {
                Function_Id = Convert.ToInt32(ddlfunctionality.SelectedValue),
                Title = txtDefectTitle.Text,
                Description = txtDescription.Text,
                Banner = (imgInp.FileName != null || imgInp.FileName != "") ? "files/defects/" + "Defects_" + imgInp.FileName : "",
                Status = ddlStatus.Text,
                Priority = ddlpriority.Text,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                FixDate = Convert.ToDateTime(txtfixdate.Text),
                Resolver_Id = Convert.ToInt32(ddlresolver.SelectedValue)
            };

            context.DefectsManager.Add(FunctionalDefect);
            context.SaveChanges();
            if (imgInp.FileName != null || imgInp.FileName != "")
            {
                Upload();
            }


            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string host = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
                string body = MailHelper.DefectAddedOrUpdated(FunctionalDefect);
                string emailId = string.Empty;
                List<Administrators> Administrators = context.Administrator.Where(m => (m.Admin_Role == eRole.Super.ToString() || m.Admin_Role == eRole.Developer.ToString())).ToList();
                foreach (var item in Administrators)
                {
                    emailId = emailId + "," + item.EmailId;
                }
                string mail_result = MailHelper.SendEmail(emailId, FunctionalDefect.Title + " - " + FunctionalDefect.Status, body, "Rachna Teracotta Functional Defect");
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Functionality Detail Created Successfully.";
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Defect Detail Created Successfully.";
            }
        }

        private void Upload()
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("files/defects/");
                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    imgInp.SaveAs(folderPath + Path.GetFileName("Defects" + "_" + imgInp.FileName));
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected Defects Banner should not be higher than 1MB.";
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