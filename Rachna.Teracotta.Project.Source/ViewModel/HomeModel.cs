using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class HomeModel
    {
        public List<Categories> _categories { get; set; }
        public List<Carts> _carts { get; set; }
        public List<ProductFeatures> _featureOurChoice { get; set; }
        public List<ProductFeatures> _featureBest { get; set; }
        public List<Sliders> _sliders { get; set; }
        public List<ProductEight> _prdeight { get; set; }
        public List<Ads> _ads { get; set; }
        public List<SubCategories> _subRachnaStudio { get; set; }
        public List<SubCategories> _subClothings { get; set; }
        public List<Stores> _stores { get; set; }
        public List<RMenu> _menu { get; set; }
        public Customers _customer { get; set; }
    }

    public class HomePageModelData
    {
        private CartModel CartModel;
        private RachnaDBContext context;
        public HomePageModelData()
        {
            context = new RachnaDBContext();
            CartModel = new CartModel();
        }

        public HomeModel GetHomeModel()
        {
            HomeModel hmpModel = new HomeModel();
            hmpModel._categories = context.Category.ToList().Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
            hmpModel._carts = CartModel.GetCarts();

            hmpModel._featureOurChoice = context.ProductFeature.Include("Product")
                .ToList().Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList();
            foreach (var item in hmpModel._featureOurChoice)
            {
                item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
            }

            hmpModel._featureBest = context.ProductFeature.Include("Product")
                .ToList().Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList();
            foreach (var item in hmpModel._featureBest)
            {
                item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
            }

            hmpModel._sliders = context.Slider.ToList();

            hmpModel._prdeight = context.ProductEights.Include("Product").ToList();
            foreach (var item in hmpModel._prdeight)
            {
                item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
            }

            hmpModel._ads = context.Advertisement.ToList();
            hmpModel._subClothings = context.SubCategory.ToList().Where(m => m.Category_Id == 2).Where(m => m.SubCategory_Status == eStatus.Active.ToString()).ToList();
            hmpModel._subRachnaStudio = context.SubCategory.ToList().Where(m => m.Category_Id == 1).Where(m => m.SubCategory_Status == eStatus.Active.ToString()).ToList();
            hmpModel._stores = context.Store.ToList().Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
            hmpModel._menu = context.RMenu.ToList();
            if (HttpContext.Current.Session["UserKey"] != null)
            {
                int cusId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                hmpModel._customer = context.Customer.ToList().Where(m => m.Customer_Id == cusId).FirstOrDefault();
            }

            return hmpModel;
        }

        public UnderConstrunction PageUnderConstruction()
        {
            UnderConstrunction underConstrunction = new UnderConstrunction();
            underConstrunction = context.UnderConstrunction.Where(m => m.UnderConst_Status == eStatus.Active.ToString()).FirstOrDefault();
            return underConstrunction;
        }

        public ContactOwner ContactUs()
        {
            ContactOwner contactOwner = new ContactOwner();
            contactOwner = context.ContactOwner.Where(m => m.Contact_Status == eStatus.Active.ToString()).FirstOrDefault();
            return contactOwner;
        }
    }
}