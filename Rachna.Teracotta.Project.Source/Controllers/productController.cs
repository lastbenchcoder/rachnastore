using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rachna.Teracotta.Project.Source.Controllers
{
    public class productController : Controller
    {
        // GET: product
        public ActionResult Index(string id)
        {
            ViewBag.ArticleId = id;
            AddVisitedProducts(Convert.ToInt32(id));
            return View();
        }

        public ActionResult ProductOffline(string id)
        {
            ViewBag.ArticleId = id;
            AddVisitedProducts(Convert.ToInt32(id));
            return View();
        }

        public ActionResult CheckZipCode(string zip, string selzip)
        {
            string[] allzip = zip.Split(',');
            string result = string.Empty;
            foreach (string x in allzip)
            {
                if (selzip.Contains(x))
                {
                    result = "Selected item will not be available to your location.";
                    break;
                }
                else
                {
                    result = "Selected item will be available to your location.";
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private void AddVisitedProducts(int productId)
        {
            string ipAddress = IpAddress.GetLocalIPAddress();
            using (var ctx = new RachnaDBContext())
            {
                Product _prd = ctx.Product.Where(m => m.Product_Id == productId).FirstOrDefault();
                VisitedProducts vpdts = ctx.VisitedProducts.Where(m => m.Product_Id == productId && m.IpAddress == ipAddress).FirstOrDefault();
                if (_prd != null)
                {
                    _prd.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == _prd.Product_Id).ToList();
                    VisitedProducts _customerVisitedProducts = new VisitedProducts()
                    {
                        IpAddress = IpAddress.GetLocalIPAddress(),
                        Product_Id = productId,
                        Store_Id=_prd.Store_Id,
                        ProductTitle = _prd.Product_Title,
                        ProductBanner = _prd.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo,
                        DateCreated = DateTime.Now,
                        VisitedCount=1
                    };
                    if (vpdts == null)
                    {
                        ctx.VisitedProducts.Add(_customerVisitedProducts);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        vpdts.VisitedCount = vpdts.VisitedCount + 1;
                        ctx.Entry(vpdts).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
            };

        }
    }
}