using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.salesmanagement
{
    public partial class vorderdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int orderId = 0;
                if (Request.QueryString["orderId"] != null)
                {
                    orderId = Convert.ToInt32(Request.QueryString["orderid"].ToString());
                    LoadDetail(orderId);
                }
                else
                {
                    Response.Redirect("/administration/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
                }
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/salesmanagement/orders.aspx?id=j4242sdfsdfsdfs532543543fdsfsdfhgj657657HGH.htm");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/salesmanagement/orderdetail.aspx?orderId=" + hdnOrderId.Value + "&derdirect-url=12gdggd787hhgfhgfhgfhgfhg.htm");
        }

        public void LoadDetail(int id)
        {
            Order _RequestList = null;
            Customers _customer = null;
            CustomerAddress _custAdress = null;
            Product _product = null;
            using (var ctx = new RachnaDBContext())
            {
                _RequestList = ctx.Orders.Include("OrderHistory").Include("PaymentMethod").ToList().Where(m => m.Order_Id == id).FirstOrDefault();
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
                    if (_RequestList.Order_Status == eOrderStatus.Delevery.ToString() || _RequestList.Order_Status == eOrderStatus.Delivered.ToString())
                    {
                        btnEdit.Enabled = false;
                    }
                }
                else
                {
                    lblOrder_Status.Font.Bold = true;
                    lblOrder_Status.ForeColor = System.Drawing.Color.Red;
                    lblOrder_Status.Text = _RequestList.Order_Status.ToUpper();
                    btnEdit.Enabled = false;
                }
                if (_RequestList.Order_Size != "0")
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
                }
                lblOrder_Qty.Text = _RequestList.Order_Qty.ToString();
                lblOrder_Price.Text = _RequestList.Order_Price.ToString();

                lblCustomerName.Text = _customer.Customers_FullName;
                lblAddress1.Text = _custAdress.Customer_AddressLine1;
                lblAddress2.Text = _custAdress.Customer_AddressLine2;
                lblCity.Text = _custAdress.CustomerAddress_City;
                lblState.Text = _custAdress.CustomerAddress_State;
                lblCountry.Text = _custAdress.CustomerAddress_Country;
                lblZipCode.Text = "ZipCode - " + _custAdress.CustomerAddress_ZipCode;
                lblEmailId.Text = _customer.Customers_EmailId;
                lblPhoneNumber.Text = _customer.Customers_Phone;
                hdnAvailableSize.Value = _product.Product_Size;
                hdnOrderId.Value = _RequestList.Order_Id.ToString();
                hdnProductId.Value = _RequestList.Product_Id.ToString();
                hdnCustId.Value = _RequestList.Customer_Id.ToString();
                lblOrder_Delivery.Text = "Delivery expected by " + _RequestList.Order_Delievery_Date.ToString("D");
                lblOrderStatus.Text = _RequestList.Order_Status;
                lblPaymentMode.Text = _RequestList.PaymentMethod.Title.ToString();
                lblOrderDetail.Text = _RequestList.OrderHistory.OrderByDescending(m => m.OrderHistory_Id).FirstOrDefault().OrderHistory_Description.ToString();
            }
        }
    }
}