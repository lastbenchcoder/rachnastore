using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;

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
    public partial class orders : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public orders()
        {
            context = new RachnaDBContext();
        }
        List<Order> _RequestList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Stores> Stores = context.Store.Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }

                Array status = Enum.GetValues(typeof(eOrderStatus));
                foreach (eOrderStatus sts in status)
                {
                    ddlStatus.Items.Add(new ListItem(sts.ToString()));
                }

                using (var ctx = new RachnaDBContext())
                {
                    _RequestList = ctx.Orders.ToList();
                    if(_RequestList==null)
                    {
                        btnExport.Visible = false;
                    }
                    grdStoreOrders.DataSource = _RequestList;
                    grdStoreOrders.DataBind();
                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDetail();
        }

        public void LoadDetail()
        {
            using (var ctx = new RachnaDBContext())
            {
                if (txtEndDate.Text != "" && txtStartDate.Text != "" && ddlStatus.Text != "Select..")
                {
                    _RequestList = ctx.Orders.ToList().Where(m => m.Store_Id == Convert.ToInt32(ddlStore.Text) && m.Order_Status == ddlStatus.Text && (m.Order_Date >= Convert.ToDateTime(txtStartDate.Text) && m.Order_Date <= Convert.ToDateTime(txtEndDate.Text))).ToList();
                }
                else if (txtEndDate.Text != "" && txtStartDate.Text != "")
                {
                    _RequestList = ctx.Orders.ToList().Where(m => m.Store_Id == Convert.ToInt32(ddlStore.Text) && (m.Order_Date >= Convert.ToDateTime(txtStartDate.Text) && m.Order_Date <= Convert.ToDateTime(txtEndDate.Text))).ToList();
                }
                else if (ddlStatus.Text != "Select..")
                {
                    _RequestList = ctx.Orders.ToList().Where(m => m.Store_Id == Convert.ToInt32(ddlStore.Text) && m.Order_Status == ddlStatus.Text).ToList();
                }
                else
                {
                    _RequestList = ctx.Orders.ToList().Where(m => m.Store_Id == Convert.ToInt32(ddlStore.Text)).ToList();
                }
                foreach (var item in _RequestList)
                {
                    item.OrderHistory = ctx.OrderHistories.ToList().Where(m => m.Order_Id == item.Order_Id).ToList();
                    item.CustomerAddress = ctx.CustomerAddres.ToList().Where(m => m.CustomerAddress_Id == item.CustomerAddress_Id).FirstOrDefault();
                }
            }
            if (_RequestList != null)
            {                
                grdStoreOrders.DataSource = _RequestList;
                grdStoreOrders.DataBind();
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
                grdStoreOrders.AllowPaging = false;
                if (ddlStore.Text != "Select..")
                {
                    LoadDetail();
                }
                else
                {
                    using (var ctx = new RachnaDBContext())
                    {
                        _RequestList = ctx.Orders.ToList();
                        if (_RequestList == null)
                        {
                            btnExport.Visible = false;
                        }
                        grdStoreOrders.DataSource = _RequestList;
                        grdStoreOrders.DataBind();
                    }
                }
                grdStoreOrders.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdStoreOrders.HeaderRow.Cells)
                {
                    cell.BackColor = grdStoreOrders.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdStoreOrders.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdStoreOrders.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdStoreOrders.RowStyle.BackColor;
                        }

                        cell.CssClass = "textmode";
                    }
                }

                grdStoreOrders.RenderControl(hw);

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