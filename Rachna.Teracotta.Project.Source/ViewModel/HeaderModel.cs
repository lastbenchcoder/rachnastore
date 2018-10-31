using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class HeaderModel
    {
        public HeaderModel()
        {
        }
        public Logo _logo { get; set; }
        public List<Carts> _carts { get; set; }
        public List<RMenu> _menu { get; set; }
        public Customers _customer { get; set; }
        public ContactOwner _contact { get; set; }
    }
    public sealed class Header
    {
        private static Header instance = null;
        private static readonly object padlock = new object();

        public Header()
        {
        }

        public static Header Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Header();
                        }
                    }
                }
                return instance;
            }
        }
        public HeaderModel Get()
        {
            HeaderModel _header = new HeaderModel();
            CartModel CartModel=new CartModel();
            using (var context = new RachnaDBContext())
            {
                _header._logo = context.Logo.Where(m => m.Logo_Status == eStatus.Active.ToString()).FirstOrDefault();
                _header._carts = CartModel.GetCarts();
                _header._menu = context.RMenu.ToList();
                if (HttpContext.Current.Session["UserKey"] != null)
                {
                    int cusId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                    _header._customer = context.Customer.ToList().Where(m => m.Customer_Id == cusId).FirstOrDefault();                    
                }
                _header._contact = context.ContactOwner.Where(m => m.Contact_Status == eStatus.Active.ToString()).FirstOrDefault();
            }
            return _header;
        }
    }
}