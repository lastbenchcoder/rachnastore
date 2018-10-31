using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class FooterModel
    {
        public FooterModel()
        {
        }
        public List<SocialNetworking> _social { get; set; }
        public List<RMenu> _menu { get; set; }
        public ContactOwner _contact { get; set; }
        public List<Categories> _categories { get; set; }
        public Customers _customer { get; set; }
        public List<Stores> _stores { get; set; }
    }
    public class Footer
    {
        private static Footer instance = null;
        private static readonly object padlock = new object();

        public Footer()
        {
        }

        public static Footer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Footer();
                        }
                    }
                }
                return instance;
            }
        }
        public FooterModel Get()
        {
            FooterModel _footer = new FooterModel();
            using (var context = new RachnaDBContext())
            {
                _footer._social = context.SocialNetworking.Where(m => m.Scl_Ntk_Status == eStatus.Active.ToString()).ToList();
                _footer._menu = context.RMenu.ToList();
                if (HttpContext.Current.Session["UserKey"] != null)
                {
                    int cusId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                    _footer._customer = context.Customer.ToList().Where(m => m.Customer_Id == cusId).FirstOrDefault();
                }
                _footer._categories = context.Category.Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                _footer._contact = context.ContactOwner.Where(m => m.Contact_Status == eStatus.Active.ToString()).FirstOrDefault();
                _footer._stores = context.Store.ToList().Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
            }
            return _footer;
        }
    }
}