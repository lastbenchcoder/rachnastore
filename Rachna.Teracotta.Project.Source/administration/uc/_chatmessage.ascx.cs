using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.uc
{
    public partial class _chatmessage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int adminId1 = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()]);
                Administrators administrators = bAdministrator.List()
                    .Where(m => m.Administrators_Id == adminId1).FirstOrDefault();
                hdnAdminId.Value = administrators.Administrators_Id.ToString();
                imgAdmin.ImageUrl = "../../" + administrators.Photo;
                ltlAdmin.Text = administrators.FullName;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //No Statements
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            AdminChatting adminChatting = new AdminChatting()
            {
                Administrators_Id = adminId,
                Message = txtMessage.Text,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            int result = bAdministrator.CreateChatMessage(adminChatting);
            txtMessage.Text = "";
        }
    }
}