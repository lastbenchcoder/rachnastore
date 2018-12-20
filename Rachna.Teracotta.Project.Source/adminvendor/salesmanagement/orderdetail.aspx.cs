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

namespace Rachna.Teracotta.Project.Source.adminvendor.salesmanagement
{
    public partial class orderdetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public orderdetail()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Array status = Enum.GetValues(typeof(eOrderStatus));
                foreach (eOrderStatus sts in status)
                {
                    ddlSorderStatus.Items.Add(new ListItem(sts.ToString()));
                }

                List<DeliveryMethod> DeliveryMethod = new List<DeliveryMethod>();
                DeliveryMethod = context.DeliveryMethod.ToList();
                foreach (var item in DeliveryMethod)
                {
                    ddlDeleveryMethod.Items.Add(new ListItem { Text = item.Title, Value = item.DeliveryMethod_Id.ToString() });
                }

                int orderId = 0;
                if (Request.QueryString["orderId"] != null)
                {
                    orderId = Convert.ToInt32(Request.QueryString["orderid"].ToString());
                    LoadDetail(orderId);
                }
                else
                {
                    Response.Redirect("/adminvendor/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new RachnaDBContext())
                {
                    Order _productOrder = new Order();
                    _productOrder = ctx.Orders.ToList().Where(m => m.Order_Id == Convert.ToInt32(hdnOrderId.Value)).FirstOrDefault();
                    if (_productOrder != null)
                    {
                        if (_productOrder.Order_Status != eOrderStatus.Cancelled.ToString() ||
                            _productOrder.Order_Status != eOrderStatus.Packed.ToString() ||
                            _productOrder.Order_Status != eOrderStatus.Shipped.ToString())
                        {
                            string[] listSize = hdnAvailableSize.Value.Split(',');
                            bool sizeSame = false;
                            foreach (var item in listSize)
                            {
                                if (txtSize.Text == item)
                                {
                                    sizeSame = true;
                                }
                            }
                            if (sizeSame == true)
                            {
                                _productOrder.Order_Size = txtSize.Text;
                                ctx.Entry(_productOrder).State = System.Data.Entity.EntityState.Modified;
                                ctx.SaveChanges();
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('Size Added Successfully.', { title: 'Success!! ' });", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('Selected size not in the available list', { title: 'Failed!! ' });", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is not valid.', { title: 'Failed!! ' });", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('You cannot update the product because no Size available, for this product', { title: 'Failed!! ' });", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('" + ex.Message + "', { title: 'Error!! ' });", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string _res = string.Empty;
            using (var ctx = new RachnaDBContext())
            {
                int productId = Convert.ToInt32(hdnOrderId.Value);
                Order _productOrder = new Order();
                _productOrder = ctx.Orders.ToList().Where(m => m.Order_Id == productId).FirstOrDefault();

                if (_productOrder.Order_Status != eOrderStatus.Rejected.ToString())
                {
                    if (_productOrder.Order_Status != ddlSorderStatus.Text)
                    {
                        if (_productOrder.Order_Status == 
                            eOrderStatus.Approved.ToString() && 
                            ddlSorderStatus.Text == eOrderStatus.Placed.ToString())
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is lower then current.', { title: 'Failed!! ' });", true);
                        }
                        else if (_productOrder.Order_Status == 
                            eOrderStatus.Packed.ToString() && 
                            (ddlSorderStatus.Text == eOrderStatus.Placed.ToString() || 
                            ddlSorderStatus.Text == eOrderStatus.Approved.ToString() || 
                            ddlSorderStatus.Text == eOrderStatus.Packed.ToString()))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is lower then current.', { title: 'Failed!! ' });", true);
                        }
                        else if (_productOrder.Order_Status == eOrderStatus.Shipped.ToString() && 
                            (ddlSorderStatus.Text == eOrderStatus.Placed.ToString() || 
                            ddlSorderStatus.Text == eOrderStatus.Approved.ToString()))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is lower then current.', { title: 'Failed!! ' });", true);
                        }                        
                        else if (ddlSorderStatus.Text == eOrderStatus.Placed.ToString() || 
                            ddlSorderStatus.Text == eOrderStatus.Approved.ToString() || 
                            ddlSorderStatus.Text == eOrderStatus.Packed.ToString() || 
                            ddlSorderStatus.Text == eOrderStatus.Shipped.ToString())
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is lower then current.', { title: 'Failed!! ' });", true);
                        }
                        else
                        {
                            _productOrder.Order_Status = ddlSorderStatus.Text;
                            ctx.Entry(_productOrder).State = EntityState.Modified;
                            ctx.SaveChanges();

                            var adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()]);
                            Administrators _adm = ctx.Administrator.Where(m => m.Administrators_Id == adminId).FirstOrDefault();
                            OrderHistory _orderCancel = new OrderHistory();
                            _orderCancel.Order_Id = Convert.ToInt32(hdnOrderId.Value);
                            _orderCancel.OrderHistory_Description = txtOrderDescription.Text;
                            _orderCancel.OrderHistory_Status = ddlSorderStatus.Text;
                            _orderCancel.OrderHistory_CreatedDate = DateTime.Now;
                            _orderCancel.OrderHistory_UpdatedDate = DateTime.Now;
                            _orderCancel.Administrators_Id = _adm.Administrators_Id;
                            _orderCancel.Store_Id = _adm.Store_Id;

                            ctx.OrderHistories.Add(_orderCancel);
                            ctx.SaveChanges();

                            if (pnlDeleveryTeam.Visible == true)
                            {
                                OrderDelivery OrderDelivery = new OrderDelivery()
                                {
                                    Order_Id = _productOrder.Order_Id,
                                    Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                                    TeamId = Convert.ToInt32(ddlDelieveryTeam.SelectedValue.ToString()),
                                    Comment = txtOrderDescription.Text,
                                    Status = eOrderDeliveryStatus.InTransist.ToString(),
                                    Store_Id=_productOrder.Store_Id,
                                    Customer_Id=_productOrder.Customer_Id,
                                    DateCreated = DateTime.Now,
                                    DateUpdated = DateTime.Now
                                };

                                ctx.OrderDelivery.Add(OrderDelivery);
                                ctx.SaveChanges();
                            }

                            Customers _cust = ctx.Customer.ToList().Where(m => m.Customer_Id == Convert.ToInt32(_productOrder.Customer_Id)).FirstOrDefault();

                            string productUrl = "http://rachnateracotta.com/product/index?id=" + _productOrder.Product_Id;
                            _res = _res + "<tr style='border: 1px solid black;'><td style='border: 1px solid black;'><img src='" + _productOrder.Product_Banner + "' width='100' height='100'/></td>"
                                + "<td style='border: 1px solid black;'><a href='" + productUrl + "'>" + _productOrder.Product_Title + "</a></td><td style='border: 1px solid black;'> Total Quantity :" + _productOrder.Order_Qty + " </td><td style='border: 1px solid black;'> " + _productOrder.Order_Price + " </td></tr>";

                            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                            {
                                string host = string.Empty;
                                host = "<table style='width:100%'>" + _res + "</ table >";
                                string body = MailHelper.CustomerOrderProcessed(host, (_cust.Customers_FullName), txtOrderDescription.Text);
                                string mail_result = MailHelper.SendEmail(_cust.Customers_EmailId, "Success!!! " + txtOrderDescription.Text + " Rachna Teracotta Estore.", body, "Rachna Teracotta Order" + txtOrderDescription.Text);
                            }

                            Response.Redirect("/adminvendor/salesmanagement/vorderdetail.aspx?orderId=" + hdnOrderId.Value + "&requesttype=view-order-detail.html");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is same as current.', { title: 'Failed!! ' });", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Order", "new Messi('update failed because, order status is not valid.', { title: 'Failed!! ' });", true);
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/adminvendor/salesmanagement/vorderdetail.aspx?orderId=" + hdnOrderId.Value + "&requesttype=view-order-detail.html");
        }

        protected void ddlSorderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSorderStatus.Text == eOrderStatus.Delevery.ToString())
            {
                pnlDeleveryTeam.Visible = true;
            }
            else
            {
                pnlDeleveryTeam.Visible = false;
            }
        }

        protected void ddlDeleveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int delMethodId = Convert.ToInt32(ddlDeleveryMethod.SelectedValue.ToString());
            List<DeleveryTeam> DeleveryTeam = new List<DeleveryTeam>();
            DeleveryTeam = context.DeleveryTeam.Where(m => m.DeliveryMethod_Id == delMethodId).ToList();
            foreach (var item in DeleveryTeam)
            {
                ddlDelieveryTeam.Items.Add(new ListItem { Text = item.Name + "(" + item.EmailId + ")", Value = item.TeamId.ToString() });
            }
        }

        public void LoadDetail(int orderId)
        {
            Order _RequestList = null;
            Customers _customer = null;
            CustomerAddress _custAdress = null;
            Product _product = null;
            using (var ctx = new RachnaDBContext())
            {
                _RequestList = ctx.Orders.Include("OrderHistory").Include("PaymentMethod").ToList().Where(m => m.Order_Id == Convert.ToInt32(orderId)).FirstOrDefault();
                _custAdress = ctx.CustomerAddres.ToList().Where(m => m.CustomerAddress_Id == _RequestList.CustomerAddress_Id).FirstOrDefault();
                _customer = ctx.Customer.ToList().Where(m => m.Customer_Id == _RequestList.Customer_Id).FirstOrDefault();
                _product = ctx.Product.ToList().Where(m => m.Product_Id == _RequestList.Product_Id).FirstOrDefault();
                lblProduct_Title.Text = _RequestList.Product_Title + "( Product Id : " + _RequestList.Product_Id + " )";
                imgProductBanner.ImageUrl = "../../" + _RequestList.Product_Banner;
                lblProduct_Price.Text = _RequestList.Product_Price.ToString();

                if (_RequestList.Order_Status != eOrderStatus.Rejected.ToString() && _RequestList.Order_Status != eOrderStatus.Cancelled.ToString())
                {
                    lblOrder_Status.Font.Bold = true;
                    lblOrder_Status.ForeColor = System.Drawing.Color.Green;
                    lblOrder_Status.Text = _RequestList.Order_Status.ToUpper();
                }
                else
                {
                    lblOrder_Status.Font.Bold = true;
                    lblOrder_Status.ForeColor = System.Drawing.Color.Red;
                    lblOrder_Status.Text = _RequestList.Order_Status.ToUpper();
                    btnSubmit.Enabled = false;
                }
                if (_RequestList.Order_Size != null && _RequestList.Order_Size != "0")
                {
                    lblOrder_Size.Font.Bold = true;
                    lblOrder_Size.ForeColor = System.Drawing.Color.Green;
                    lblOrder_Size.Text = "Selected Size is " + _RequestList.Order_Size;
                }
                else if (_RequestList.Order_Size == "0" && _product.Product_Size != "0")
                {
                    lblOrder_Size.Font.Bold = true;
                    lblOrder_Size.ForeColor = System.Drawing.Color.Red;
                    lblOrder_Size.Text = " No Size Selected, Please Confirm From the Customer";
                }
                else
                {
                    lblOrder_Size.Font.Bold = true;
                    lblOrder_Size.ForeColor = System.Drawing.Color.Blue;
                    lblOrder_Size.Text = "This Product has Free Size, No Need to select product size";
                    txtSize.Visible = false;
                    btnSubmit.Visible = false;
                }
                lblOrder_Qty.Text = _RequestList.Order_Qty.ToString();
                lblOrder_Price.Text = _RequestList.Order_Price.ToString();
                lblPaymentMode.Text = _RequestList.PaymentMethod.Title;

                lblCustomerName.Text = _customer.Customers_FullName;
                lblAddress1.Text = _custAdress.Customer_AddressLine1;
                lblAddress2.Text = _custAdress.Customer_AddressLine2;
                lblCity.Text = _custAdress.CustomerAddress_City;
                lblState.Text = _custAdress.CustomerAddress_State;
                lblCountry.Text = _custAdress.CustomerAddress_Country;
                lblZipCode.Text = "ZipCode - " + _custAdress.CustomerAddress_ZipCode;
                lblEmailId.Text = _customer.Customers_EmailId;
                lblPhoneNumber.Text = _customer.Customers_Phone;
                lblAvailableSize.Text = _product.Product_Size;
                hdnAvailableSize.Value = _product.Product_Size;
                hdnOrderId.Value = _RequestList.Order_Id.ToString();
                hdnProductId.Value = _RequestList.Product_Id.ToString();
                txtSize.Text = (_RequestList.Order_Status != eOrderStatus.Rejected.ToString() &&
                    _RequestList.Order_Status != eOrderStatus.Cancelled.ToString()) ? _RequestList.Order_Size.ToString() : "No Size";
                hdnCustId.Value = _RequestList.Customer_Id.ToString();
                lblOrder_Delivery.Text = "Delivery expected by " + _RequestList.Order_Delievery_Date.ToString("D");
                ddlSorderStatus.SelectedValue = _RequestList.Order_Status;
                txtOrderDescription.Text = _RequestList.OrderHistory.OrderByDescending(m => m.OrderHistory_Id).FirstOrDefault().OrderHistory_Description.ToString();

                grdOrderHistory.DataSource = _RequestList.OrderHistory;
                grdOrderHistory.DataBind();
            }
        }
    }
}