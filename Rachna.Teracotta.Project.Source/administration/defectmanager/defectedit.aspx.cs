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
    public partial class defectedit : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public defectedit()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Defect Detail";
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    List<Administrators> Administrators = new List<Administrators>();
                    Administrators = context.Administrator.Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                    foreach (var item in Administrators)
                    {
                        ddlresolver.Items.Add(new ListItem { Text = item.FullName + "(" + item.Admin_Role + ")", Value = item.Administrators_Id.ToString() });
                    }

                    Array status = Enum.GetValues(typeof(eFunctionalityStatus));
                    foreach (eFunctionalityStatus sts in status)
                    {
                        ddlStatus.Items.Add(new ListItem(sts.ToString()));
                    }

                    FunctionalDefect FunctionalDefect = context.DefectsManager.Include("Functionality").Include("Administrators").Where(m => m.Defect_Id == id).FirstOrDefault();
                    FunctionalDefect.Resolver = context.Administrator.Where(m => m.Administrators_Id == FunctionalDefect.Resolver_Id).FirstOrDefault();

                    hdnDefectId.Value = FunctionalDefect.Defect_Id.ToString();
                    lblFunctionality.Text = FunctionalDefect.Functionality.Title;
                    ddlStatus.SelectedValue = FunctionalDefect.Status;
                    ddlresolver.SelectedValue = FunctionalDefect.Resolver_Id.ToString();
                    lblpriority.Text = FunctionalDefect.Priority;
                    txtDefectTitle.Text = FunctionalDefect.Title;
                    txtDescription.Text = FunctionalDefect.Description;
                    lblFixDate.Text = FunctionalDefect.FixDate.ToString();
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new RachnaDBContext())
                {
                    FunctionalDefect FunctionalDefect = new FunctionalDefect();
                    int id = Convert.ToInt32(hdnDefectId.Value);
                    FunctionalDefect = context.DefectsManager.Where(m => m.Defect_Id == id).FirstOrDefault();
                    if (FunctionalDefect != null)
                    {
                        FunctionalDefect.Title = txtDefectTitle.Text;
                        FunctionalDefect.Description = txtDescription.Text;
                        FunctionalDefect.Status = ddlStatus.Text;
                        FunctionalDefect.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                        FunctionalDefect.UpdatedDate = DateTime.Now;
                        FunctionalDefect.Resolver_Id = Convert.ToInt32(ddlresolver.SelectedValue);
                        context.Entry(FunctionalDefect).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();

                        FunctionalDefectStory FunctionalDefectStory = new FunctionalDefectStory()
                        {
                            Defect_Id = FunctionalDefect.Defect_Id,
                            Title = txtDefectTitle.Text,
                            Description = txtDescription.Text,
                            Banner = "files/defects/" + "Defects_" + imgInp.FileName,
                            Status = ddlStatus.Text,
                            Priority = FunctionalDefect.Priority,
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                            FixDate = FunctionalDefect.FixDate,
                            Resolver_Id = Convert.ToInt32(ddlresolver.SelectedValue)
                        };

                        context.FunctionalDefectStory.Add(FunctionalDefectStory);
                        context.SaveChanges();
                        Upload();

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
                        }

                        Response.Redirect("/administration/defectmanager/defectdetail.aspx?id=" + id + "&redirecturl=admin-store-rachna-teracotta");
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Defect cannot be updated. Entered Functionality Name already exists in the database";
                    }
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