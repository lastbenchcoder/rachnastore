using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.admindelivery
{
    public partial class delieveryupdate : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public delieveryupdate()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["delId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["delId"]);
                    hdnDelId.Value = id.ToString();
                    LoadDetail(id);
                }
            }
        }

        private void LoadDetail(int id)
        {
            try
            {
                OrderDelivery OrderDelivery = context.OrderDelivery.Include("DeleveryTeam").Include("Order").Include("Stores")
                    .Include("Customers").Where(m => m.Order_Delivery_Id == id).FirstOrDefault();
                if (OrderDelivery != null)
                {
                    Array status = Enum.GetValues(typeof(eOrderDeliveryStatus));
                    foreach (eOrderDeliveryStatus sts in status)
                    {
                        ddlSorderStatus.Items.Add(new ListItem(sts.ToString()));
                    }

                    OrderDelivery.Order.CustomerAddress = context.CustomerAddres.Where(m => m.CustomerAddress_Id == OrderDelivery.Order.CustomerAddress_Id).FirstOrDefault();
                    Image1.ImageUrl = "../../" + OrderDelivery.Order.Product_Banner;
                    lblBCTitle.Text = OrderDelivery.Order.Product_Title;
                    lblProductTitle.Text = OrderDelivery.Order.Product_Title;
                    lblCustomerName.Text = OrderDelivery.Order.Customer_Name;
                    lblStore.Text = OrderDelivery.Stores.Store_Name;
                    lblCustomerName.Text = OrderDelivery.Order.Customer_Name;
                    lblAddress1.Text = OrderDelivery.Order.CustomerAddress.Customer_AddressLine1;
                    lblAddress2.Text = OrderDelivery.Order.CustomerAddress.Customer_AddressLine2;
                    lblCity.Text = OrderDelivery.Order.CustomerAddress.CustomerAddress_City;
                    lblState.Text = OrderDelivery.Order.CustomerAddress.CustomerAddress_State;
                    lblCountry.Text = OrderDelivery.Order.CustomerAddress.CustomerAddress_Country;
                    lblZipCode.Text = OrderDelivery.Order.CustomerAddress.CustomerAddress_ZipCode;
                    lblEmailId.Text = OrderDelivery.Customers.Customers_EmailId;
                    lblPhoneNumber.Text = OrderDelivery.Customers.Customers_Phone;
                    ddlSorderStatus.SelectedValue = OrderDelivery.Status;
                    txtOrderDescription.Text = OrderDelivery.Comment;
                    hdnOrderId.Value = OrderDelivery.Order_Id.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddToFeature_Click(object sender, EventArgs e)
        {
            string _res = string.Empty;
            using (var ctx = new RachnaDBContext())
            {
                int productId = Convert.ToInt32(hdnOrderId.Value);
                int delOrderId = Convert.ToInt32(hdnDelId.Value);
                Order _productOrder = new Order();
                _productOrder = ctx.Orders.ToList().Where(m => m.Order_Id == productId).FirstOrDefault();
                OrderDelivery OrderDelivery = ctx.OrderDelivery.Where(m => m.Order_Delivery_Id == delOrderId).FirstOrDefault();


                _productOrder.Order_Status = ddlSorderStatus.Text;
                ctx.Entry(_productOrder).State = EntityState.Modified;
                ctx.SaveChanges();

                OrderDelivery.Status = ddlSorderStatus.Text;
                ctx.Entry(OrderDelivery).State = EntityState.Modified;
                ctx.SaveChanges();

                OrderHistory OrderHistory = new OrderHistory();
                OrderHistory.Order_Id = Convert.ToInt32(hdnOrderId.Value);
                OrderHistory.OrderHistory_Description = txtOrderDescription.Text;
                OrderHistory.OrderHistory_Status = ddlSorderStatus.Text;
                OrderHistory.OrderHistory_CreatedDate = DateTime.Now;
                OrderHistory.OrderHistory_UpdatedDate = DateTime.Now;
                OrderHistory.Administrators_Id = OrderDelivery.Administrators_Id;
                OrderHistory.Store_Id = OrderDelivery.Store_Id;

                ctx.OrderHistories.Add(OrderHistory);
                ctx.SaveChanges();

                Customers _cust = ctx.Customer.ToList().Where(m => m.Customer_Id == Convert.ToInt32(_productOrder.Customer_Id)).FirstOrDefault();

                string productUrl = "http://rachnateracotta.com/product/index?id=" + _productOrder.Product_Id;
                _res = _res + "<tr style='border: 1px solid black;'><td style='border: 1px solid black;'><img src='" + _productOrder.Product_Banner + "' width='100' height='100'/></td>"
                    + "<td style='border: 1px solid black;'><a href='" + productUrl + "'>" + _productOrder.Product_Title + "</a></td><td style='border: 1px solid black;'> Total Quantity :" + _productOrder.Order_Qty + " </td><td style='border: 1px solid black;'> " + _productOrder.Order_Price + " </td></tr>";

                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string host = string.Empty;
                    host = "<table style='width:100%'>" + _res + "</ table >";
                    string body = MailHelper.CustomerOrderProcessed(host, (_cust.Customers_FullName), txtOrderDescription.Text);
                    MailHelper.SendEmail(_cust.Customers_EmailId, "Success!!! " + txtOrderDescription.Text + " Rachna Teracotta Estore.", body, "Rachna Teracotta Order" + txtOrderDescription.Text);
                }

                Response.Redirect("/admindelivery/deliveryhome.aspx?id=200&requesttype=view-order-detail.html");
            }
        }
    }
}