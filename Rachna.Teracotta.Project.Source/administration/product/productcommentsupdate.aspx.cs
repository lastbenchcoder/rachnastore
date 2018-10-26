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

namespace Rachna.Teracotta.Project.Source.administration.product
{
    public partial class productcommentsupdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Product Comment Update";
            if (!IsPostBack)
            {
                Array roles = Enum.GetValues(typeof(eCommentStatus));
                foreach (eCommentStatus rls in roles)
                {
                    ddlSorderStatus.Items.Add(new ListItem(rls.ToString()));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new RachnaDBContext())
                {
                    ProdComments ProdComments = new ProdComments();
                    int commentId = Convert.ToInt32(hdnProductCommentId.Value);
                    ProdComments = ctx.ProdComments.ToList().Where(m => m.Comment_Id == commentId).FirstOrDefault();
                    if (ProdComments != null)
                    {
                        ProdComments.Comment_Status = ddlSorderStatus.Text;
                        ProdComments.DateUpdated = DateTime.Now;
                        ctx.Entry(ProdComments).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();

                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Comment Detail Updated Successfully and status set to " + ddlSorderStatus.Text;
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