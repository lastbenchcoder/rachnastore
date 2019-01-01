using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using Rachna.Teracotta.Project.Source.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rachna.Teracotta.Project.Source.Controllers
{
    public class userController : Controller
    {
        CartModel _mcartmdl;
        private RachnaDBContext context;
        public userController()
        {
            context = new RachnaDBContext();
            _mcartmdl = new CartModel();
        }
        public ActionResult Index(string id)
        {
            if (Session["UserKey"] != null & TempData["SaveAfterLogin"] != null)
            {
                _mcartmdl.SaveCartAfterLogin();
            }
            if (Session["redirectUrl"] != null)
            {
                return Redirect("/user/paymentmethod");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login(Customers _customer)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View(_customer);
        }
        public ActionResult LoginUser(Customers _customer)
        {
            Customers _cust = context.Customer.Where(m => m.Customers_EmailId == _customer.Customers_EmailId && m.Customers_Password == _customer.Customers_Password && m.Customers_Status == eStatus.Active.ToString()).FirstOrDefault();
            if (_cust != null)
            {
                string ipAddress = IpAddress.GetLocalIPAddress();
                Session["UserKey"] = _cust.Customer_Id.ToString();
                Carts _carts = context.Cart.Where(m => m.Ip_Address == ipAddress && m.Cart_Status == eCartStatus.Temp.ToString()).FirstOrDefault();
                if (_carts != null)
                {
                    TempData["SaveAfterLogin"] = 200;
                }
                else
                {
                    Session["redirectUrl"] = null;
                }
                return Redirect("/user/index");
            }
            else
            {
                TempData["Message"] = "Oops!! Login failed due to invalid userid/password or your EmailId is Not verified.. Please try with valid userid/password or Click activation link to activate your account.";
                return RedirectToAction("login", _customer);
            }
        }
        public ActionResult SignUp(Customers _customer)
        {
            Customers _cust = context.Customer.Where(m => m.Customers_EmailId == _customer.Customers_EmailId && m.Customers_Phone == _customer.Customers_Phone).FirstOrDefault();
            if (_cust == null)
            {
                Customers Customer = new Customers()
                {
                    Customers_FullName = _customer.Customers_FullName,
                    Customers_Description = "test description",
                    Customers_EmailId = _customer.Customers_EmailId,
                    Customers_Phone = _customer.Customers_Phone,
                    Customers_Photo = "images/user_icon.png",
                    Customers_Login_Attempt = 0,
                    Customers_CreatedDate = DateTime.Now,
                    Customers_UpdatedDate = DateTime.Now,
                    Customers_Password = _customer.Customers_Password,
                    Customers_Status = eStatus.InActive.ToString(),
                    IsEmailVerified = 0,
                    CustomerType = eCustomerType.regular.ToString()
                };

                int maxBnrAdminId = 1;
                if (context.Customer.ToList().Count > 0)
                    maxBnrAdminId = context.Customer.Max(m => m.Customer_Id);
                maxBnrAdminId = (maxBnrAdminId == 1 && context.Customer.ToList().Count > 0) ? (maxBnrAdminId + 1) : maxBnrAdminId;
                Customer.CustomerCode = "CUSRACH" + maxBnrAdminId + "TERA" + (maxBnrAdminId + 1);
                context.Customer.Add(Customer);
                context.SaveChanges();

                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string host = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
                    host = host + "/user/VerifyEmail?VerificationId=" + Customer.CustomerCode + "&reirect-url=ghgfhsgf798798jhshfjsfkjs.html";
                    string body = MailHelper.VerifyEmailLink(host, Customer.Customers_FullName);
                    MailHelper.SendEmail(Customer.Customers_EmailId, "Verify Your EmailId", body, "Rachna Teracotta Store");
                }

                return Redirect("/user/success");
            }
            else
            {
                TempData["Message"] = "Entered EmailId/Phone Already Exists in our database. Please login to your account or try with different emailid or phone.";
                return RedirectToAction("login", _customer);
            }
        }
        public ActionResult success()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CheckoutConfirm()
        {
            if (Session["UserKey"] != null)
            {
                return Redirect("/user/paymentmethod");
            }
            return Redirect("/user/checkoutoption");
        }
        public ActionResult CheckoutOption()
        {
            Session["redirectUrl"] = "100";
            return View();
        }
        public ActionResult UpdateQty(string id, string qty, string size)
        {
            _mcartmdl.UpdateCart(id, qty, size);
            return Redirect("/user/index");
        }
        public ActionResult UpdateSize(string id, string qty, string size)
        {
            _mcartmdl.UpdateCart(id, size, size);
            return Redirect("/user/index");
        }
        public ActionResult DeleteCart(string id)
        {
            _mcartmdl.DeleteCart(id);
            return Redirect("/user/index");
        }
        public ActionResult guestcheckin(Customers _customer, CustomerAddress _customeraddress)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            var tupleModel = new Tuple<Customers, CustomerAddress>(_customer, _customeraddress);
            return View(tupleModel);
        }
        public ActionResult SubmitAsGuest(Customers _customer, CustomerAddress _address)
        {
            Customers cust = context.Customer.Where(m => m.Customers_EmailId == _customer.Customers_EmailId || m.Customers_Phone == _customer.Customers_Phone).FirstOrDefault();
            if (cust == null)
            {
                Customers Customer = new Customers()
                {
                    Customers_FullName = _customer.Customers_FullName,
                    Customers_Description = "test description",
                    Customers_EmailId = _customer.Customers_EmailId,
                    Customers_Phone = _customer.Customers_Phone,
                    Customers_Photo = "images/user_icon.png",
                    Customers_Login_Attempt = 0,
                    Customers_CreatedDate = DateTime.Now,
                    Customers_UpdatedDate = DateTime.Now,
                    Customers_Password = _customer.Customers_Password,
                    Customers_Status = eStatus.Active.ToString(),
                    IsEmailVerified = 0,
                    CustomerType = eCustomerType.guest.ToString()
                };

                int maxBnrAdminId = 1;
                if (context.Customer.ToList().Count > 0)
                    maxBnrAdminId = context.Customer.Max(m => m.Customer_Id);
                maxBnrAdminId = (maxBnrAdminId == 1 && context.Customer.ToList().Count > 0) ? (maxBnrAdminId + 1) : maxBnrAdminId;
                Customer.CustomerCode = "CUSRACH" + maxBnrAdminId + "TERA" + (maxBnrAdminId + 1);
                context.Customer.Add(Customer);
                context.SaveChanges();

                if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                {
                    string host = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
                    host = host + "/user/VerifyEmail?VerificationId=" + Customer.CustomerCode + "&reirect-url=ghgfhsgf798798jhshfjsfkjs.html";
                    string body = MailHelper.VerifyEmailLink(host, Customer.Customers_FullName);
                    MailHelper.SendEmail(Customer.Customers_EmailId, "Verify Your EmailId", body, "Rachna Teracotta Store");
                }

                CustomerAddress CustomerAddres = new CustomerAddress()
                {
                    Customer_Id = Customer.Customer_Id,
                    Customer_AddressLine1 = _address.Customer_AddressLine1,
                    Customer_AddressLine2 = _address.Customer_AddressLine2,
                    CustomerAddress_LandMark = _address.CustomerAddress_LandMark,
                    CustomerAddress_City = _address.CustomerAddress_City,
                    CustomerAddress_State = _address.CustomerAddress_State,
                    CustomerAddress_Country = _address.CustomerAddress_Country,
                    CustomerAddress_ZipCode = _address.CustomerAddress_ZipCode,
                    CustomerAddress_DateCreated = DateTime.Now,
                    CustomerAddress_DateUpdated = DateTime.Now,
                    CustomerAddress_Status = _address.CustomerAddress_Status
                };

                int maxBnrCusAdrAdminId = 1;
                if (context.CustomerAddres.ToList().Count > 0)
                    maxBnrCusAdrAdminId = context.CustomerAddres.Max(m => m.CustomerAddress_Id);
                maxBnrCusAdrAdminId = (maxBnrCusAdrAdminId == 1 && context.CustomerAddres.ToList().Count > 0) ? (maxBnrCusAdrAdminId + 1) : maxBnrCusAdrAdminId;
                CustomerAddres.CustomerAddress_Code = "CUSADRRACH" + maxBnrCusAdrAdminId + "TERA" + (maxBnrCusAdrAdminId + 1);
                context.CustomerAddres.Add(CustomerAddres);
                context.SaveChanges();
                Carts _carts = _mcartmdl.GetCarts().Where(m => m.Ip_Address == IpAddress.GetLocalIPAddress() && m.Cart_Status == eCartStatus.Temp.ToString()).FirstOrDefault();
                Session["UserKey"] = Customer.Customer_Id.ToString();
                if (_carts != null)
                {
                    _mcartmdl.SaveCartAfterLogin();
                }
                return Redirect("/user/paymentmethod");
            }
            else
            {
                TempData["Message"] = "Oops!! entered customer email/phone already exists.please try with different emailid/phone.";
            }
            return Redirect("/user/guestcheckin");
        }
        public ActionResult PaymentMethod()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult AddAddress(CustomerAddress _address)
        {
            int CusId = Convert.ToInt32(Session["UserKey"]);
            Customers _customer = context.Customer.Where(m => m.Customer_Id == CusId).FirstOrDefault();

            CustomerAddress CustomerAddres = new CustomerAddress()
            {
                Customer_Id = _customer.Customer_Id,
                Customer_AddressLine1 = _address.Customer_AddressLine1,
                Customer_AddressLine2 = _address.Customer_AddressLine2,
                CustomerAddress_LandMark = _address.CustomerAddress_LandMark,
                CustomerAddress_City = _address.CustomerAddress_City,
                CustomerAddress_State = _address.CustomerAddress_State,
                CustomerAddress_Country = _address.CustomerAddress_Country,
                CustomerAddress_ZipCode = _address.CustomerAddress_ZipCode,
                CustomerAddress_DateCreated = DateTime.Now,
                CustomerAddress_DateUpdated = DateTime.Now,
                CustomerAddress_Status = eStatus.Active.ToString()
            };

            int maxBnrCusAdrAdminId = 1;
            if (context.CustomerAddres.ToList().Count > 0)
                maxBnrCusAdrAdminId = context.CustomerAddres.Max(m => m.CustomerAddress_Id);
            maxBnrCusAdrAdminId = (maxBnrCusAdrAdminId == 1 && context.CustomerAddres.ToList().Count > 0) ? (maxBnrCusAdrAdminId + 1) : maxBnrCusAdrAdminId;
            CustomerAddres.CustomerAddress_Code = "CUSADRRACH" + maxBnrCusAdrAdminId + "TERA" + (maxBnrCusAdrAdminId + 1);
            context.CustomerAddres.Add(CustomerAddres);
            context.SaveChanges();

            return Redirect("/user/account");
        }
        public ActionResult UpdatePassword(string password)
        {
            Customers _customer = context.Customer.Where(m => m.Customer_Id == Convert.ToInt32(Session["UserKey"])).FirstOrDefault();
            _customer.Customers_Password = password;

            context.Entry(_customer).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            TempData["Message"] = "Success!! password updated successfully.";
            return Redirect("/user/account");
        }
        public ActionResult SubmitOrder(string addressId, string paymentType)
        {
            int custId = Convert.ToInt32(Session["UserKey"]);
            Customers _cust = context.Customer.Where(m => m.Customer_Id == custId).FirstOrDefault();
            int custAdrId = Convert.ToInt32(addressId);
            int selPaymentType = Convert.ToInt32(paymentType);
            List<Carts> _cart = _mcartmdl.GetCarts().Where(m => m.Customer_Id == custId && m.Cart_Status == eCartStatus.Open.ToString()).ToList();
            string _res = string.Empty;
            foreach (var item in _cart)
            {
                Product _prd = context.Product.Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();

                Order Orders = new Order()
                {
                    Order_Price = item.Cart_Price,
                    Order_Qty = item.Cart_Qty,
                    Order_Size = item.Cart_Size,
                    Order_Status = eOrderStatus.Placed.ToString(),
                    Product_Id = item.Product_Id,
                    Product_Banner = item.Product_Banner,
                    Product_Price = item.Product_Price,
                    Product_Title = item.Product_Title,
                    Customer_Id = item.Customer_Id,
                    Customer_Name = item.Customer_Name,
                    CustomerAddress_Id = custAdrId,
                    Payment_Method_Id = selPaymentType,
                    Order_Date = DateTime.Now,
                    Order_Delievery_Date = DateTime.Now.AddDays(_prd.Product_Delivery_Time),
                    Store_Id = _prd.Store_Id,
                    Order_UpdateDate = DateTime.Now
                };

                int maxBnrCusAdrAdminId = 1;
                if (context.Orders.ToList().Count > 0)
                    maxBnrCusAdrAdminId = context.Orders.Max(m => m.Order_Id);
                maxBnrCusAdrAdminId = (maxBnrCusAdrAdminId == 1 && context.Orders.ToList().Count > 0) ? (maxBnrCusAdrAdminId + 1) : maxBnrCusAdrAdminId;
                Orders.Order_Code = "ORDRACH" + maxBnrCusAdrAdminId + "TERA" + (maxBnrCusAdrAdminId + 1);
                context.Orders.Add(Orders);
                context.SaveChanges();

                Administrators _adm = context.Administrator.Where(m => m.EmailId == "admin@rachnateracotta.com").FirstOrDefault();
                OrderHistory OrderHistories = new OrderHistory()
                {
                    Order_Id = Orders.Order_Id,
                    OrderHistory_Status = eOrderStatus.Placed.ToString(),
                    OrderHistory_Description = "Order Submitted successfully on " + DateTime.Now.ToString("D").ToString(),
                    OrderHistory_CreatedDate = DateTime.Now,
                    OrderHistory_UpdatedDate = DateTime.Now,
                    Administrators_Id = _adm.Administrators_Id,
                    Store_Id = Orders.Store_Id
                };

                context.OrderHistories.Add(OrderHistories);
                context.SaveChanges();

                Carts _carts = _mcartmdl.GetCarts().Where(m => m.Cart_Id == item.Cart_Id).FirstOrDefault();
                _mcartmdl.DeleteCartByCartId(_carts);

                string productUrl = "http://rachnateracotta.com/product/index?id=" + item.Product_Id;
                _res = _res + "<tr style='border: 1px solid black;'><td style='border: 1px solid black;'><img src='" + ConfigurationSettings.AppSettings["DomainUrl"].ToString() + item.Product_Banner + "' width='100' height='100'/></td>"
                    + "<td style='border: 1px solid black;'><a href='" + productUrl + "'>" + item.Product_Title + "</a></td><td style='border: 1px solid black;'> Total Quantity :" + item.Cart_Qty + " </td><td style='border: 1px solid black;'> " + item.Cart_Price + " </td></tr>";
            }
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string host = string.Empty;
                host = "<table style='width:100%'>" + _res + "</ table >";
                string body = MailHelper.CustomerOrderPlaced(host, (_cust.Customers_FullName));
                MailHelper.SendEmail(_cust.Customers_EmailId, "Success!!! You Order Placed In Rachna Teracotta Estore.", body, "Rachna Teracotta Order Placed");
            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult TrackOrder()
        {
            return View();
        }
        public ActionResult Message()
        {
            return View();
        }
        public ActionResult emailVerified(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult CancelOrder(string orderId)
        {
            ViewBag.orderId = orderId;
            return View();
        }
        public ActionResult VerifyEmail(string VerificationId)
        {
            Customers _cust = context.Customer.Where(m => m.CustomerCode == VerificationId).FirstOrDefault();
            if (_cust != null)
            {
                if (_cust.IsEmailVerified != 1)
                {
                    _cust.IsEmailVerified = 1;
                    _cust.Customers_UpdatedDate = DateTime.Now;
                    _cust.Customers_Status = eStatus.Active.ToString();
                    context.Entry(_cust).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return Redirect("/user/emailVerified?id=100&redirect-url=hgvvnb798798Vhgfhfhhghgh.html");
                }
                else
                {
                    return Redirect("/user/emailVerified?id=404&redirect-url=hgvvnb798798Vhgfhfhhghgh.html");
                }
            }
            else
            {
                return Redirect("/user/emailVerified?id=404&redirect-url=hgvvnb798798Vhgfhfhhghgh.html");
            }
        }
        public ActionResult SubmitOrdetCancel(string orderid, string reason)
        {
            string _res = string.Empty;
            int cusId = Convert.ToInt32(Session["UserKey"]);
            Customers _cust = context.Customer.Where(m => m.Customer_Id == cusId).FirstOrDefault();
            int ordId = Convert.ToInt32(orderid);
            Order _order = context.Orders.Where(m => m.Order_Id == ordId).FirstOrDefault();

            _order.Order_Status = eOrderStatus.Cancelled.ToString();
            context.Entry(_order).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Administrators _adm = context.Administrator.Where(m => m.EmailId == "admin@rachnateracotta.com").FirstOrDefault();
            OrderHistory _orderCancel = new OrderHistory();
            _orderCancel.Order_Id = Convert.ToInt32(orderid);
            _orderCancel.OrderHistory_Description = reason;
            _orderCancel.OrderHistory_Status = eOrderStatus.Cancelled.ToString();
            _orderCancel.OrderHistory_CreatedDate = DateTime.Now;
            _orderCancel.OrderHistory_UpdatedDate = DateTime.Now;
            _orderCancel.Administrators_Id = _adm.Administrators_Id;
            _orderCancel.Store_Id = _order.Store_Id;

            context.OrderHistories.Add(_orderCancel);
            context.SaveChanges();

            string productUrl = "http://rachnateracotta.com/product/index?id=" + _order.Product_Id;
            _res = _res + "<tr style='border: 1px solid black;'><td style='border: 1px solid black;'><img src='" + _order.Product_Banner + "' width='100' height='100'/></td>"
                + "<td style='border: 1px solid black;'><a href='" + productUrl + "'>" + _order.Product_Title + "</a></td><td style='border: 1px solid black;'> Total Quantity :" + _order.Order_Qty + " </td><td style='border: 1px solid black;'> " + _order.Order_Price + " </td></tr>";

            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string host = string.Empty;
                host = "<table style='width:100%'>" + _res + "</ table >";
                string body = MailHelper.CustomerOrderCancelled(host, (_cust.Customers_FullName), reason);
                MailHelper.SendEmail(_cust.Customers_EmailId, "Success!!! You Order Has Been Cancelled In Rachna Teracotta Estore.", body, "Rachna Teracotta Order Cancelled");
            }
            return Redirect("/user/orders");
        }
        [ValidateInput(false)]
        public ActionResult ProductComments(string ProductId, string rating, string CustomerId, string likeunlike, string description)
        {
            int prdId = Convert.ToInt32(ProductId);
            int cusId = Convert.ToInt32(CustomerId);
            Product Product = context.Product.Include("ProductBanner").Where(m => m.Product_Id == prdId).FirstOrDefault();
            Customers Customers = context.Customer.Where(m => m.Customer_Id == cusId).FirstOrDefault();
            ProdComments Comments = new ProdComments()
            {
                Customer_Id = Customers.Customer_Id,
                Product_Id = Product.Product_Id,
                Comment_Status = eCommentStatus.Pending.ToString(),
                Customer_Name = Customers.Customers_FullName,
                Description = description,
                Product_Title = Product.Product_Title,
                Product_Banner = Product.ProductBanner.Where(m => m.Product_Id == Product.Product_Id).FirstOrDefault().Product_Banner_Photo,
                Rating = Convert.ToInt32(rating),
                LikeUnlike = (likeunlike == "like") ? 1 : 0,
                Store_Id = Product.Store_Id,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            context.ProdComments.Add(Comments);
            context.SaveChanges();
            return Redirect("/product/index?id=" + Product.Product_Id + "&title=" + Product.Product_Title);
        }
    }
}