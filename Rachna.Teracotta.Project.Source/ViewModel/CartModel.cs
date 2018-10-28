using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class CartModel
    {
        private RachnaDBContext context;
        public CartModel()
        {
            context = new RachnaDBContext();
        }
        public void SaveCartToDB(Carts Cart)
        {
            int maxBnrAdminId = 1;
            if (context.Cart.ToList().Count > 0)
                maxBnrAdminId = context.Cart.Max(m => m.Cart_Id);
            maxBnrAdminId = (maxBnrAdminId == 1 && context.Cart.ToList().Count > 0) ? (maxBnrAdminId + 1) : maxBnrAdminId;
            Cart.CartCode = "CARTRACH" + maxBnrAdminId + "TERA" + (maxBnrAdminId + 1);
            context.Cart.Add(Cart);
            context.SaveChanges();
        }
        public void SaveCartAfterLogin()
        {
            if (HttpContext.Current.Session["UserKey"] != null)
            {
                int custId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                Customers Customers = context.Customer.Include("Cart").Where(m => m.Customer_Id == custId).FirstOrDefault();
                List<Carts> Carts = context.Cart.ToList().Where(x => x.Cart_Status == eCartStatus.Temp.ToString() && x.Ip_Address == IpAddress.GetLocalIPAddress()).ToList();
                List<Carts> matching = null;
                foreach (var item in Carts)
                {
                    matching = Customers.Cart.Where(m => m.Product_Id == item.Product_Id && m.Cart_Status == eCartStatus.Open.ToString()).ToList();
                    if (matching != null && matching.Count > 0)
                    {
                        context.Entry(matching).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                }

                foreach (var item in Carts)
                {
                    DeleteCart(item.Product_Id.ToString());
                    item.Customer_Id = Customers.Customer_Id;
                    item.Cart_Status = eCartStatus.Open.ToString();
                    item.Customer_Name = Customers.Customers_FullName;
                    SaveCartToDB(item);
                }
            }
        }

        public void AddToCart(string id, string qty, string size)
        {
            int prdId = Convert.ToInt32(id);
            Product _product = context.Product.Include("ProductBanner").Where(m => m.Product_Id == prdId).FirstOrDefault();

            if (HttpContext.Current.Session["UserKey"] != null)
            {
                int custId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                Carts _carts = context.Cart.Include("Customer").ToList().Where(m => m.Customer_Id == custId && m.Product_Id == Convert.ToInt32(id) && m.Cart_Status == eCartStatus.Open.ToString()).FirstOrDefault();
                Customers _customer = context.Customer.Where(m => m.Customer_Id == custId).FirstOrDefault();
                Carts _cart = new Carts();
                _cart.Customer_Id = 000;
                _cart.Product_Id = Convert.ToInt32(id);
                _cart.Cart_Qty = (Convert.ToInt32(qty) == 1 && _carts != null) ? (Convert.ToInt32(qty) + _carts.Cart_Qty) : Convert.ToInt32(qty);
                _cart.Cart_Size = size;
                _cart.Cart_Price = (_cart.Cart_Qty * _product.Product_Our_Price);
                _cart.Cart_Status = eCartStatus.Open.ToString();
                _cart.Product_Banner = _product.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo;
                _cart.Product_Price = _product.Product_Our_Price;
                _cart.Shipping_Charge = _product.Product_ShippingCharge;
                _cart.Cart_Total_Price = _cart.Cart_Price + _cart.Shipping_Charge;
                _cart.Product_Title = _product.Product_Title;
                _cart.Customer_Id = _customer.Customer_Id;
                _cart.Customer_Name = _customer.Customers_FullName;
                _cart.Store_Id = _product.Store_Id;
                _cart.DateCreated = DateTime.Now;
                _cart.DateUpdated = DateTime.Now;
                if (_carts != null)
                    DeleteCart(id);
                SaveCartToDB(_cart);
            }
            else
            {
                Carts _carts = context.Cart.Include("Customer").ToList().Where(m => m.Ip_Address == IpAddress.GetLocalIPAddress() && m.Product_Id == Convert.ToInt32(id) && m.Cart_Status == eCartStatus.Temp.ToString()).FirstOrDefault();
                Customers _customer = context.Customer.Where(m => m.Customer_Id == 1).FirstOrDefault();
                Carts _cart = new Carts();
                _cart.Customer_Id = 000;
                _cart.Product_Id = Convert.ToInt32(id);
                _cart.Cart_Qty = (Convert.ToInt32(qty) == 1 && _carts != null) ? (Convert.ToInt32(qty) + _carts.Cart_Qty) : Convert.ToInt32(qty);
                _cart.Cart_Size = size;
                _cart.Cart_Price = (_cart.Cart_Qty * _product.Product_Our_Price);
                _cart.Cart_Status = eCartStatus.Temp.ToString();
                _cart.Product_Banner = _product.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo;
                _cart.Product_Price = _product.Product_Our_Price;
                _cart.Shipping_Charge = _product.Product_ShippingCharge;
                _cart.Cart_Total_Price = _cart.Cart_Price + _cart.Shipping_Charge;
                _cart.Product_Title = _product.Product_Title;
                _cart.Customer_Id = _customer.Customer_Id;
                _cart.Customer_Name = _customer.Customers_FullName;
                _cart.Ip_Address = IpAddress.GetLocalIPAddress();
                _cart.Store_Id = _product.Store_Id;
                _cart.DateCreated = DateTime.Now;
                _cart.DateUpdated = DateTime.Now;
                if (_carts != null)
                    DeleteCart(id);
                SaveCartToDB(_cart);
            }

        }
        public void UpdateCart(string id, string qty, string size)
        {
            int prdId = Convert.ToInt32(id);
            Product _product = context.Product.Include("ProductBanner").Where(m => m.Product_Id == prdId).FirstOrDefault();

            if (HttpContext.Current.Session["UserKey"] != null)
            {
                int custId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                Customers _customer = context.Customer.Where(m => m.Customer_Id == custId).FirstOrDefault();
                Carts _cart = context.Cart.Include("Customer").ToList().Where(m => m.Customer_Id == _customer.Customer_Id && m.Product_Id == prdId && m.Cart_Status == eCartStatus.Open.ToString()).FirstOrDefault();
                _cart.Cart_Qty = qty!="0"?Convert.ToInt32(qty):_cart.Cart_Qty;
                _cart.Cart_Size = size != "0" ? size : _cart.Cart_Size;
                _cart.Cart_Price = (Convert.ToInt32(qty) * _product.Product_Our_Price);
                DeleteCart(id);
                _cart.DateUpdated = DateTime.Now;
                SaveCartToDB(_cart);
            }
            else
            {
                Carts _cart = context.Cart.Include("Customer").ToList().Where(m => m.Ip_Address == IpAddress.GetLocalIPAddress() && m.Product_Id == prdId && m.Cart_Status == eCartStatus.Temp.ToString()).FirstOrDefault();
                _cart.Cart_Qty = qty != "0" ? Convert.ToInt32(qty) : _cart.Cart_Qty;
                _cart.Cart_Size = size != "0" ? size : _cart.Cart_Size;
                _cart.Cart_Price = (Convert.ToInt32(qty) * _product.Product_Our_Price);
                _cart.DateUpdated = DateTime.Now;
                DeleteCart(id);
                SaveCartToDB(_cart);
            }

        }
        public void DeleteCart(string id)
        {
            int prdId = Convert.ToInt32(id);
            if (HttpContext.Current.Session["UserKey"] != null)
            {
                int custId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                Customers _customer = context.Customer.Where(m => m.Customer_Id == custId).FirstOrDefault();
                Carts _cart = context.Cart.Include("Customer").ToList().Where(m => m.Product_Id == prdId && (m.Cart_Status == eCartStatus.Open.ToString() || m.Cart_Status == eCartStatus.Temp.ToString())).FirstOrDefault();
                if (_cart != null)
                {
                    context.Entry(_cart).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            else
            {
                Carts _cart = context.Cart.ToList().Where(m => m.Product_Id == prdId && (m.Cart_Status == eCartStatus.Open.ToString() || m.Cart_Status == eCartStatus.Temp.ToString()) && m.Ip_Address == IpAddress.GetLocalIPAddress()).FirstOrDefault();
                if (_cart != null)
                {
                    context.Entry(_cart).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCartByCartId(Carts _cart)
        {
            context.Entry(_cart).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<Carts> GetCarts()
        {
            List<Carts> _carts = new List<Carts>();
            if (HttpContext.Current.Session["UserKey"] != null)
            {
                int cusId = Convert.ToInt32(HttpContext.Current.Session["UserKey"]);
                _carts = context.Cart.Include("Customer").ToList().Where(m => m.Customer_Id == cusId && m.Cart_Status == eCartStatus.Open.ToString()).ToList();
            }
            else
            {
                _carts = context.Cart.ToList().ToList().Where(x => x.Cart_Status == eCartStatus.Temp.ToString() && x.Ip_Address == IpAddress.GetLocalIPAddress()).ToList();
            }
            if (_carts != null)
            {
                foreach (var item in _carts)
                {
                    item.Products = context.Product.ToList().Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                }
            }
            return _carts;
        }
    }
}