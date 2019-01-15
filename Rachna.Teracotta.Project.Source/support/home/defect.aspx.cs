using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.support.home
{
    public partial class defect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Defects Management";
            if (!IsPostBack)
            {
                List<Administrators> administrators = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in administrators)
                {
                    ddlResolver.Items.Add(new ListItem { Text = item.FullName, Value = item.Administrators_Id.ToString() });
                }

                Array status = Enum.GetValues(typeof(eFunctionalityStatus));
                foreach (eFunctionalityStatus rls in status)
                {
                    ddlStatus.Items.Add(new ListItem(rls.ToString()));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["SupportSession"].ToString()].ToString());
            FunctionalDefect functionalDefect = new FunctionalDefect()
            {
                Title = txtFullname.Text,
                Description = txtDescription.Text,
                FixDate = Convert.ToDateTime(txtDueDate.Text),
                Administrators_Id=adminId,
                Status=ddlStatus.Text,
                Resolver_Id=Convert.ToInt32(ddlResolver.SelectedValue),
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now,
                Priority= rdoPriority.Text                
            };

            functionalDefect = bFunctionalDefect.Create(functionalDefect);
            if(string.IsNullOrEmpty(functionalDefect.ErrorMessage))
            {
                FunctionalDefectStory functionalDefectStory = new FunctionalDefectStory()
                {
                    Defect_Id= functionalDefect.Defect_Id,
                    Title = txtFullname.Text,
                    Description = txtDescription.Text,
                    FixDate = Convert.ToDateTime(txtDueDate.Text),
                    Administrators_Id = adminId,
                    Status = ddlStatus.Text,
                    Resolver_Id = Convert.ToInt32(ddlResolver.SelectedValue),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Priority = rdoPriority.Text
                };

                functionalDefectStory = bFunctionalDefect.CreateDefectStory(functionalDefectStory);

                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string mailBody = MailHelper.DefectAddedOrUpdated(functionalDefect);
                    string emailIdToSend = MailHelper.EmailToSend();

                    string CreatorAdmin = bAdministrator.List().Where(m => m.Administrators_Id == functionalDefect.Administrators_Id).FirstOrDefault().EmailId;
                    string DeveloperAdmin = bAdministrator.List().Where(m => m.Administrators_Id == functionalDefect.Resolver_Id).FirstOrDefault().EmailId;
                    emailIdToSend = emailIdToSend + ";" + CreatorAdmin;
                    emailIdToSend = emailIdToSend + ";" + DeveloperAdmin;
                    MailHelper.SendEmail(emailIdToSend, "New Ticket Created", mailBody, "Support Team");
                }
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Success! New Ticket created successfully";
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Faied! to create the ticket. Error : " + Request.QueryString["errormessage"].ToString();
            }
        }
    }
}