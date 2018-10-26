using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.salesmanagement
{
    public partial class cart : System.Web.UI.Page
    {
        List<Carts> _RequestList;
        private RachnaDBContext context;
        public cart()
        {
            context = new RachnaDBContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Stores> Stores = context.Store.Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }

                Array status = Enum.GetValues(typeof(eCartStatus));
                foreach (eCartStatus sts in status)
                {
                    ddlStatus.Items.Add(new ListItem(sts.ToString()));
                }
                _RequestList = context.Cart.ToList();
                if (_RequestList == null)
                {
                    btnExport.Visible = false;
                }
                grdStoreCart.DataSource = _RequestList;
                grdStoreCart.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDetail();
        }

        public void LoadDetail()
        {
            int storeId = Convert.ToInt32(ddlStore.Text);

            if (txtEndDate.Text != "" && txtStartDate.Text != "" && ddlStatus.Text != "Select..")
            {
                _RequestList = context.Cart.ToList().Where(m => m.Store_Id == storeId && m.Cart_Status == ddlStatus.Text && (m.DateCreated >= Convert.ToDateTime(txtStartDate.Text) && m.DateCreated <= Convert.ToDateTime(txtEndDate.Text))).ToList();
            }
            else if (txtEndDate.Text != "" && txtStartDate.Text != "")
            {
                _RequestList = context.Cart.ToList().Where(m => m.Store_Id == storeId && (m.DateCreated >= Convert.ToDateTime(txtStartDate.Text) && m.DateCreated <= Convert.ToDateTime(txtEndDate.Text))).ToList();
            }
            else if (ddlStatus.Text != "Select..")
            {
                _RequestList = context.Cart.ToList().Where(m => m.Store_Id == storeId && m.Cart_Status == ddlStatus.Text).ToList();
            }
            else
            {
                _RequestList = context.Cart.ToList().Where(m => m.Store_Id == storeId).ToList();
            }

            if (_RequestList != null)
            {
                grdStoreCart.DataSource = _RequestList;
                grdStoreCart.DataBind();
            }
            else
            {
                btnExport.Visible = false;
            }
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdStoreCart.AllowPaging = false;
                if (ddlStore.Text != "Select..")
                {
                    LoadDetail();
                }
                else
                {
                    using (var ctx = new RachnaDBContext())
                    {
                        _RequestList = context.Cart.ToList();
                        if (_RequestList == null)
                        {
                            btnExport.Visible = false;
                        }
                        grdStoreCart.DataSource = _RequestList;
                        grdStoreCart.DataBind();
                    }
                }
                grdStoreCart.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdStoreCart.HeaderRow.Cells)
                {
                    cell.BackColor = grdStoreCart.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdStoreCart.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdStoreCart.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdStoreCart.RowStyle.BackColor;
                        }

                        cell.CssClass = "textmode";
                    }
                }

                grdStoreCart.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}