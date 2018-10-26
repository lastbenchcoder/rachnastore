using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using Rachna.Teracotta.Project.Source.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rachna.Teracotta.Project.Source.Controllers
{
    public class cartController : Controller
    {
        CartModel _mcartmdl;
        public cartController()
        {
            _mcartmdl = new CartModel();
        }
        // GET: cart
        public ActionResult Index()
        {
            return View();
        }
        [HandleError]
        public ActionResult AddToCart(string id, string qty, string size)
        {
            if (qty.ToLower() == "select...")
                qty = "1";
            if (size == "" || size=="0")
            {
                using (var context = new RachnaDBContext())
                {
                    int prdId = Convert.ToInt32(id);
                    Product Product = context.Product.Where(m => m.Product_Id == prdId).FirstOrDefault();
                    if (Product.Product_Has_Size)
                    {
                        string[] sizes = Product.Product_Size.Split(',');
                        size = sizes[0].ToString();
                    }
                    else
                    {
                        size = "No Size";
                    }
                }
            }
            _mcartmdl.AddToCart(id, qty, size);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        [HandleError]
        public ActionResult DeleteCart(string id, string categoryid)
        {
            _mcartmdl.DeleteCart(id);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}