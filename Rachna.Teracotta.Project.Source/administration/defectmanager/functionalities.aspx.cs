using Rachna.Teracotta.Project.Source.App_Data;
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

namespace Rachna.Teracotta.Project.Source.administration.defectmanager
{
    public partial class functionalities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Functionality";
                if (Request.QueryString["id"] != null)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Defect Detail Updated Successfully.";
                }

                Array status = Enum.GetValues(typeof(eFunctionalityStatus));
                foreach (eFunctionalityStatus sts in status)
                {
                    ddlStatus.Items.Add(new ListItem(sts.ToString()));
                }

                using (var context = new RachnaDBContext())
                {
                    List<Administrators> Administrators = new List<Administrators>();
                    Administrators = context.Administrator.Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                    foreach (var item in Administrators)
                    {
                        ddldeveloper.Items.Add(new ListItem { Text = item.FullName + "(" + item.Admin_Role + ")", Value = item.Administrators_Id.ToString() });
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new RachnaDBContext())
                {
                    Functionality _category1 = new Functionality();
                    _category1 = context.Functionality.Where(m => m.Title == txtCategory.Text).FirstOrDefault();
                    if (_category1 == null)
                    {
                        Functionality Functionality = new Functionality()
                        {
                            Title = txtCategory.Text,
                            Description = txtSmallDescription.Text,
                            Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now,
                            Status = ddlStatus.Text,
                            Developer_Id = Convert.ToInt32(ddldeveloper.SelectedValue)
                        };
                        if (Functionality.Function_Id != 0)
                        {
                            Functionality.FunctionCode = "FUNRACH" + Functionality.Function_Id + "TERA" + (Functionality.Function_Id + 2);
                            context.Entry(Functionality).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            int maxAdminId = 1;
                            if (context.Functionality.ToList().Count > 0)
                                maxAdminId = context.Functionality.Max(m => m.Function_Id);
                            Functionality.FunctionCode = "FUNRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
                            context.Functionality.Add(Functionality);
                        }
                        context.SaveChanges();

                        if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                        {
                            string host = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
                            string body = MailHelper.FunctionalityAddedOrUpdated(Functionality);
                            string emailId = string.Empty;
                            List<Administrators> Administrators = context.Administrator.Where(m => (m.Admin_Role == eRole.Super.ToString() || m.Admin_Role == eRole.Developer.ToString())).ToList();
                            foreach (var item in Administrators)
                            {
                                emailId = emailId + "," + item.EmailId;
                            }
                            string mail_result = MailHelper.SendEmail(emailId, Functionality.Title + " - " + Functionality.Status, body, "Rachna Teracotta Functionality");
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
                            lblMessage.Text = "Functionality Detail Created Successfully.";
                        }
                        ClearFields();
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Functionality cannot be created. Entered Functionality Name already exists in the database.";
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
        private void ClearFields()
        {
            ddlStatus.SelectedIndex = 0;
            txtCategory.Text = "";
            txtSmallDescription.Text = "";
        }
    }
}