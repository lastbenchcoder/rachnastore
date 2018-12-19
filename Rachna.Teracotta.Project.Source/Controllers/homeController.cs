using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rachna.Teracotta.Project.Source.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            FilesHelper.DeleteFilesOlderThen5Days();
            return View();
        }
        public ActionResult GetProductsBySubCat(int id)
        {
            List<Product> _product = null;
            List<HomePageProductModel> _prdModel = new List<HomePageProductModel>();
            using (var ctx = new RachnaDBContext())
            {
                _product = ctx.Product.Where(m => m.SubCategory_Id == id && m.Product_Status == eProductStatus.Published.ToString()).ToList();

                foreach (var item in _product)
                {
                    item.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }
            }

            foreach (var item in _product.Take(8).ToList())
            {
                if (item.ProductBanner.Count > 0)
                {
                    _prdModel.Add(new HomePageProductModel
                    {
                        Id = item.Product_Id,
                        Title = item.Product_Title,
                        Description = (item.Product_Description.Length > 500) ? item.Product_Description.Substring(0, 500) + "..." : item.Product_Description,
                        Banner1 = item.ProductBanner.Where(x => x.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        Banner2 = item.ProductBanner.Where(x => x.Product_Banner_Default != 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        OldPrice = item.Product_Mkt_Price,
                        TotalPrice = item.Product_Our_Price,
                        DiscountPrice = item.Product_Discount,
                        Rating = item.Store_Rating
                    });
                }
            }
            return Json(_prdModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Page(string pageid)
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult ProductByCategory(string subcatid, string category)
        {
            ViewBag.SubCatId = subcatid;
            ViewBag.Category = category;
            return View();
        }
        public ActionResult Subscribe(string emailid)
        {
            string result = string.Empty;
            using (var ctx = new RachnaDBContext())
            {
                Subscription _subscribeUser = ctx.Subscribe.Where(m => m.Subscription_EmailId == emailid).FirstOrDefault();
                if (_subscribeUser == null)
                {
                    Subscription _subscr = new Subscription()
                    {
                        Subscription_EmailId = emailid,
                        Subscription_Status = eStatus.Active.ToString(),
                        Subscription_CreatedDate = DateTime.Now,
                        Subscription_UpdatedDate = DateTime.Now
                    };

                    ctx.Subscribe.Add(_subscr);
                    ctx.SaveChanges();
                    result = "Thank you for sbscribing our news letter! we have triggered a email to you. Please activate the subscription by clicking on the link.";
                }
                else
                {
                    result = "Oops!! Entered Email Id already exists with us.";
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductsBySubCatId(int id, int max_price, int min_price, string filter, string category)
        {
            List<Product> _product = null;
            List<HomePageProductModel> _prdModel = new List<HomePageProductModel>();
            using (var ctx = new RachnaDBContext())
            {
                if (category != null)
                {
                    _product = ctx.Product.Include("SubCategory").Where(m => m.SubCategory.Category_Id == id && m.Product_Status == eProductStatus.Published.ToString()).ToList();
                }
                else
                {
                    _product = ctx.Product.Where(m => m.SubCategory_Id == id && m.Product_Our_Price <= max_price && m.Product_Our_Price >= min_price && m.Product_Status == eProductStatus.Published.ToString()).ToList();
                }
                foreach (var item in _product)
                {
                    item.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }
            }

            ViewBag.TotProducts = _product.Count;

            foreach (var item in _product)
            {
                if (item.ProductBanner.Count > 0)
                {
                    _prdModel.Add(new HomePageProductModel
                    {
                        Id = item.Product_Id,
                        Title = item.Product_Title,
                        Description = (item.Product_Description.Length > 500) ? item.Product_Description.Substring(0, 500) + "..." : item.Product_Description,
                        Banner1 = item.ProductBanner.Where(x => x.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        Banner2 = item.ProductBanner.Where(x => x.Product_Banner_Default != 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        OldPrice = item.Product_Mkt_Price,
                        TotalPrice = item.Product_Our_Price,
                        DiscountPrice = item.Product_Discount,
                        Rating = item.Store_Rating
                    });
                }
            }

            if (filter != "NA")
            {
                if (filter == "az" && filter == "za")
                {
                    return Json(_prdModel.OrderBy(o => o.Title).ToList(), JsonRequestBehavior.AllowGet);
                }
                else if (filter == "hl")
                {
                    return Json(_prdModel.OrderByDescending(o => o.TotalPrice).ToList(), JsonRequestBehavior.AllowGet);
                }
                else if (filter == "lh")
                {
                    return Json(_prdModel.OrderBy(o => o.TotalPrice).ToList(), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(_prdModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult SearchResult(string s)
        {
            ViewBag.SearchKey = s;
            return View();
        }
        public ActionResult GetProductsSearchKey(string s, int loadItems)
        {
            List<Product> _product = null;
            List<HomePageProductModel> _prdModel = new List<HomePageProductModel>();
            using (var ctx = new RachnaDBContext())
            {
                CustomerSearchKey _seracKeys = ctx.CustomerSearchKey.Where(m => m.SearchKey == s).FirstOrDefault();
                if (_seracKeys == null)
                {
                    AddSearchKey(s);
                }
                _product = ctx.Product
                       .Where(p => (p.Product_Title.Contains(s) || p.Product_Description.Contains(s)) && p.Product_Status == eProductStatus.Published.ToString())
                       .Take(loadItems).ToList();
                //_product = ctx.Product.Where(m => (m.Product_Title == s || m.Product_Description== s) && m.Product_Status.ToLower() == "published").Take(loadItems).ToList();
                foreach (var item in _product)
                {
                    item.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }
            }

            foreach (var item in _product.Take(8).ToList())
            {
                if (item.ProductBanner.Count > 0)
                {
                    _prdModel.Add(new HomePageProductModel
                    {
                        Id = item.Product_Id,
                        Title = item.Product_Title,
                        Description = (item.Product_Description.Length > 500) ? item.Product_Description.Substring(0, 500) + "..." : item.Product_Description,
                        Banner1 = item.ProductBanner.Where(x => x.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        Banner2 = item.ProductBanner.Where(x => x.Product_Banner_Default != 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        OldPrice = item.Product_Mkt_Price,
                        TotalPrice = item.Product_Our_Price,
                        DiscountPrice = item.Product_Discount,
                        Rating = item.Store_Rating
                    });
                }
            }
            return Json(_prdModel, JsonRequestBehavior.AllowGet);
        }
        private void AddSearchKey(string searchKey)
        {
            using (var ctx = new RachnaDBContext())
            {
                CustomerSearchKey _customerSearchKey = new CustomerSearchKey()
                {
                    IpAddress = IpAddress.GetLocalIPAddress(),
                    SearchKey = searchKey,
                    DateCreated = DateTime.Now
                };
                ctx.CustomerSearchKey.Add(_customerSearchKey);
                ctx.SaveChanges();
            };

        }
        public ActionResult ProductByStore(string storeId)
        {
            ViewBag.StoreId = storeId;
            return View();
        }
        public ActionResult GetProductsByStoreId(int id, int max_price, int min_price, int storeId)
        {
            List<Product> _product = null;
            List<HomePageProductModel> _prdModel = new List<HomePageProductModel>();
            using (var ctx = new RachnaDBContext())
            {
                if (id != 0)
                    _product = ctx.Product.Where(m => m.SubCategory_Id == id && m.Product_Our_Price <= max_price && m.Product_Our_Price >= min_price && m.Product_Status == eProductStatus.Published.ToString() && m.Store_Id == storeId).ToList();
                else
                    _product = ctx.Product.Where(m => m.Product_Our_Price <= max_price && m.Product_Our_Price >= min_price && m.Product_Status == eProductStatus.Published.ToString() && m.Store_Id == storeId).ToList();
                foreach (var item in _product)
                {
                    item.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }
            }

            foreach (var item in _product.Take(8).ToList())
            {
                if (item.ProductBanner.Count > 0)
                {
                    _prdModel.Add(new HomePageProductModel
                    {
                        Id = item.Product_Id,
                        Title = item.Product_Title,
                        Description = (item.Product_Description.Length > 500) ? item.Product_Description.Substring(0, 500) + "..." : item.Product_Description,
                        Banner1 = item.ProductBanner.Where(x => x.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        Banner2 = item.ProductBanner.Where(x => x.Product_Banner_Default != 1).FirstOrDefault().Product_Banner_Photo.ToString(),
                        OldPrice = item.Product_Mkt_Price,
                        TotalPrice = item.Product_Our_Price,
                        DiscountPrice = item.Product_Discount,
                        Rating = item.Store_Rating
                    });
                }
            }
            return Json(_prdModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Offers()
        {
            return View();
        }
        public class HomePageProductModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Banner1 { get; set; }
            public string Banner2 { get; set; }
            public decimal OldPrice { get; set; }
            public decimal TotalPrice { get; set; }
            public decimal DiscountPrice { get; set; }
            public int Rating { get; set; }
        }
        public ActionResult CustomerRequest(CustomerRequest customerRequest)
        {
            string result = string.Empty;
            using (var ctx = new RachnaDBContext())
            {
                CustomerRequest _customerRequest = new CustomerRequest()
                {
                    FullName = customerRequest.FullName,
                    EmailId = customerRequest.EmailId,
                    Subject = customerRequest.Subject,
                    Description = customerRequest.Description,
                    IpAddress = IpAddress.GetLocalIPAddress(),
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                ctx.CustomerRequest.Add(_customerRequest);
                ctx.SaveChanges();
                result = "Thank you for submitting your request we will work on your request.";

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}