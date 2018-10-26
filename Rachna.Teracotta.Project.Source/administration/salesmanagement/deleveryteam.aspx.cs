using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.salesmanagement
{
    public partial class deleveryteam : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public deleveryteam()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DeliveryMethod> _category = new List<DeliveryMethod>();
                _category = context.DeliveryMethod.ToList();
                foreach (var item in _category)
                {
                    ddlCategory.Items.Add(new ListItem { Text = item.Title, Value = item.DeliveryMethod_Id.ToString() });
                }

                List<Stores> Stores = new List<Stores>();
                Stores = context.Store.ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DeleveryTeam DeleveryTeam1 = new DeleveryTeam();
                int catId = Convert.ToInt32(ddlCategory.SelectedValue);
                int storeId = Convert.ToInt32(ddlStore.SelectedValue);
                DeleveryTeam1 = context.DeleveryTeam.Where(m => m.DeliveryMethod_Id == catId && m.EmailId == txtEmailId.Text && m.Store_Id== storeId).FirstOrDefault();
                if (DeleveryTeam1 == null)
                {
                    DeleveryTeam DeleveryTeam = new DeleveryTeam()
                    {
                        DeliveryMethod_Id=catId,
                        Store_Id=storeId,
                        Name = txtCategory.Text,
                        Description = txtSmallDescription.Text,
                        Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                        EmailId = txtEmailId.Text,
                        Phone=txtPhone.Text,
                        Address=txtAddress.Text,
                        City=txtCity.Text,
                        State=txtState.Text,
                        Country=txtCountry.Text,
                        ZipCode=txtZip.Text,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Status = eStatus.Active.ToString()
                    };

                    int maxAdminId = 1;
                    if (context.DeleveryTeam.ToList().Count > 0)
                        maxAdminId = context.DeleveryTeam.Max(m => m.TeamId);
                    maxAdminId = (maxAdminId == 1 && context.DeleveryTeam.ToList().Count > 0) ? (maxAdminId + 1) : maxAdminId;
                    DeleveryTeam.TeamCode = "DELTEAMRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
                    context.DeleveryTeam.Add(DeleveryTeam);

                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delevery Team", "new Messi('New Delevery Team Created Successfully.', { title: 'Success!! ' });", true);
                    ClearFields();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Delevery Team", "new Messi('Delevery Team cannot be created. Entered Delevery Team Name already exists in the database.', { title: 'Failed!! ' });", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Delevery Team", "new Messi(" + ex.Message + ", { title: 'Error!! ' });", true);
            }
        }
        private void ClearFields()
        {
            ddlCategory.SelectedIndex = 0;
            ddlStore.SelectedIndex = 0;
            txtCategory.Text = "";
            txtSmallDescription.Text = "";
            txtEmailId.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";            
            txtCountry.Text = "";
            txtZip.Text = "";
        }
    }
}