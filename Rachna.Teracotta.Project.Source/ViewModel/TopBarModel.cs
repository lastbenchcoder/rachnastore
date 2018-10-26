using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class TopBarModel
    {
        public List<SocialNetworking> _social { get; set; }
        public Customers _customer { get; set; }
    }

    public class TopBar
    {
        public TopBarModel Get()
        {
            TopBarModel _topbar = new TopBarModel();
            using (var context = new RachnaDBContext())
            {
                _topbar._social=context.SocialNetworking.Where(m=>m.Scl_Ntk_Status== eStatus.Active.ToString()).ToList();
                if (HttpContext.Current.Session["UserKey"] != null)
                {
                    int cusId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                    _topbar._customer = context.Customer.ToList().Where(m => m.Customer_Id == cusId).FirstOrDefault();
                }
            }
            return _topbar;
        }
    }
}