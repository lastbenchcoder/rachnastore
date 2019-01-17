using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
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
    public partial class defectdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Defects Management";
            if (!IsPostBack)
            {
                if (Request.QueryString["defectid"] != null)
                {
                    LoadDetail(Convert.ToInt32(Request.QueryString["defectid"]));
                }
            }
        }

        public void LoadDetail(int defectId)
        {
            FunctionalDefect functionalDefect = bFunctionalDefect.List().Where(m => m.Defect_Id == defectId).FirstOrDefault();
            ltlBc.Text = functionalDefect.Title;
            ltlDefectTitle.Text = functionalDefect.Title;
            lblStatus.Text = functionalDefect.Status;
            if (functionalDefect.Status == eFunctionalityStatus.Completed.ToString())
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            lblResolver.Text = functionalDefect.Resolver.FullName;
        }
    }
}