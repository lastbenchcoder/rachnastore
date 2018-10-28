using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class HomePageModel
    {
        public HomePageModel()
        {
        }
        public List<Categories> _categories { get; set; }
        public List<DealOfTheDay> _dealoftheday { get; set; }
        public List<Ads> _ads { get; set; }
        public List<ProductEight> _prdeight { get; set; }
        public List<ProductFeatures> _featureOurChoice { get; set; }
        public List<ProductFeatures> _featureBest { get; set; }
        public List<ProductFeatures> _featureHot { get; set; }
        public List<Stores> _stores { get; set; }
    }

    public sealed class HomePage
    {
        private static HomePage instance = null;
        private static readonly object padlock = new object();

        public HomePage()
        {
        }

        public static HomePage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new HomePage();
                        }
                    }
                }
                return instance;
            }
        }
        public HomePageModel Get()
        {
            HomePageModel _HomePage = new HomePageModel();
            CartModel CartModel = new CartModel();
            using (var context = new RachnaDBContext())
            {
                _HomePage._categories = context.Category.Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                _HomePage._dealoftheday=context.DealOfTheDay.Include("Product").ToList();
                if(_HomePage._dealoftheday.Count>0)
                {
                    foreach(var item in _HomePage._dealoftheday)
                    {
                        item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                        item.Product.ProdComments = context.ProdComments.Where(m => m.Product_Id == item.Product_Id).ToList();
                    }
                }
                _HomePage._ads = context.Advertisement.ToList();
                _HomePage._prdeight = context.ProductEights.Include("Product").ToList();
                foreach (var item in _HomePage._prdeight)
                {
                    item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                _HomePage._featureOurChoice = context.ProductFeature.Include("Product")
                .ToList().Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList();
                foreach (var item in _HomePage._featureOurChoice)
                {
                    item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                _HomePage._featureBest = context.ProductFeature.Include("Product")
                    .ToList().Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList();
                foreach (var item in _HomePage._featureBest)
                {
                    item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                _HomePage._featureHot = context.ProductFeature.Include("Product")
                    .ToList().Where(m => m.Product_Feature_Type == eProductFeature.Hot.ToString()).ToList();
                foreach (var item in _HomePage._featureHot)
                {
                    item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                _HomePage._stores = context.Store.ToList().Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
            }
            return _HomePage;
        }
    }
}