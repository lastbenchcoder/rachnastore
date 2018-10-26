using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.defectmanager
{
    public partial class functdetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public functdetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Array status = Enum.GetValues(typeof(eFunctionalityStatus));
                    foreach (eFunctionalityStatus sts in status)
                    {
                        ddlStatus.Items.Add(new ListItem(sts.ToString()));
                    }
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    Functionality Functionality = context.Functionality.Include("Administrators").Where(m => m.Function_Id == id).FirstOrDefault();
                    if (Functionality != null)
                    {
                        Functionality.Developer = context.Administrator.Where(m => m.Administrators_Id == Functionality.Developer_Id).FirstOrDefault();
                        txtCategory.Text = Functionality.Title;
                        txtSmallDescription.Text = Functionality.Description;
                        ddlStatus.Text = Functionality.Status;
                        lblAdmin.Text = Functionality.Administrators.FullName;
                        lblDeveloper.Text = Functionality.Developer.FullName;
                        lblDateCreated.Text = Functionality.DateCreated.ToString();
                        lblDateUpdated.Text = Functionality.DateUpdated.ToString();
                        hdnFunctionId.Value = Functionality.Function_Id.ToString();
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
                    Functionality Functionality = new Functionality();
                    int id = Convert.ToInt32(hdnFunctionId.Value);
                    Functionality = context.Functionality.Where(m => m.Function_Id == id).FirstOrDefault();
                    if (Functionality != null)
                    {
                        Functionality.Title = txtCategory.Text;
                        Functionality.Description = txtSmallDescription.Text;
                        Functionality.Status = ddlStatus.Text;
                        Functionality.Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                        Functionality.DateUpdated = DateTime.Now;
                        context.Entry(Functionality).State = System.Data.Entity.EntityState.Modified;
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
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Update Functionality", "new Messi('Invitation created successfully.', { title: 'Failed!! ' });", true);
                        }
                        Response.Redirect("/administration/defectmanager/functionalities.aspx?id=100&redirecturl=admin-store-rachna-teracotta");
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
    }
}