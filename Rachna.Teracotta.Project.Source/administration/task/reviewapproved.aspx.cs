using Rachna.Teracotta.Project.Source.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Rachna.Teracotta.Project.Source.Models;
using Rachna.Teracotta.Project.Source.Helper;
using System.Data.Entity.Validation;
using Rachna.Teracotta.Project.Source.Exceptions;
using Rachna.Teracotta.Project.Source.Entity;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.administration.task
{
    public partial class reviewapproved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDetail();
            }
        }
        protected void btnGetSelected_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grdReviewPending.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string productId = (row.Cells[2].FindControl("lblProductId") as Label).Text;
                            using (var ctx = new RachnaDBContext())
                            {
                                Administrators _admin = ctx.Administrator.ToList().Where(m => m.Administrators_Id == Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString())).Single();
                                Product _Product = ctx.Product.ToList().Where(m => m.Product_Id == Convert.ToInt32(productId)).FirstOrDefault();
                                _Product.Administrators_Id = _admin.Administrators_Id;
                                _Product.Product_UpdatedDate = DateTime.Now;
                                _Product.Product_Status = eProductStatus.Approved.ToString();
                                ctx.Entry(_Product).State = System.Data.Entity.EntityState.Modified;
                                ctx.SaveChanges();

                                ProductHelper.CreateProductFlow(_Product.Product_Id, _Product.Product_Title, _admin.Administrators_Id, _admin.FullName, "Product Published Successfully", _Product.Product_Status);

                                LoadDetail();
                            }
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                var newException = new FormattedDbEntityValidationException(ex);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Store", "new Messi('" + newException + "', { title: 'Error!! ' });", true);
            }
        }

        public void LoadDetail()
        {
            using (var ctx = new RachnaDBContext())
            {
                grdReviewPending.DataSource = ctx.Product.Where(m => m.Product_Status == eProductStatus.ReviewCompleted.ToString()).ToList();
                grdReviewPending.DataBind();
            }
        }
    }
}