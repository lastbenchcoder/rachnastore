using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class ProductPageModel
    {
        public ProductPageModel()
        {

        }
        public int AlreadyCommentsDone = 0;
        public Product Product { get; set; }
        public Customers Customers { get; set; }
        public List<Carts> Carts { get; set; }
        public List<ProdComments> ProdComments { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<ProductFeatures> ProductFeatures { get; set; }
        public List<ProductFeatures> ProductFeatures2 { get; set; }
        public List<Categories> Categories { get; set; }
    }

    public sealed class ProductPage
    {
        private static ProductPage instance = null;
        private static readonly object padlock = new object();

        public ProductPage()
        {
        }

        public static ProductPage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ProductPage();
                        }
                    }
                }
                return instance;
            }
        }
        public ProductPageModel GetProductPageData(int product_id)
        {
            ProductPageModel prdModel = new ProductPageModel();
            bool status = true;
            using (var ctx = new RachnaDBContext())
            {
                CartModel _cartMdl = new CartModel();
                prdModel.Carts = _cartMdl.GetCarts();
                prdModel.Product = bProduct.List().Where(m => m.Product_Id == product_id).FirstOrDefault();

                if (prdModel.Product.SubCategory.SubCategory_Status != eStatus.Active.ToString())
                {
                    status = false;
                }
                else
                {
                    Categories categories = bCategory.List()
                        .Where(m => m.Category_Status == eStatus.InActive.ToString()
                        && m.Category_Id == prdModel.Product.SubCategory.Category_Id).FirstOrDefault();
                    if (categories != null)
                    {
                        status = false;
                    }
                }
                if (status)
                {
                    if (prdModel.Product.Product_Status == eProductStatus.Published.ToString())
                    {
                        prdModel.Product.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == prdModel.Product.Product_Id).ToList();
                        prdModel.Product.SubCategory = bSubCategory.List().Where(m => m.SubCategory_Id == prdModel.Product.SubCategory_Id).FirstOrDefault();

                        prdModel.RelatedProducts = bProduct.List().Where(m => m.Product_Id != prdModel.Product.Product_Id && m.Product_Status == eProductStatus.Published.ToString()).Take(4).ToList();
                        foreach (var item in prdModel.RelatedProducts)
                        {
                            item.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == item.Product_Id).ToList();
                        }

                        prdModel.ProductFeatures = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList();
                        foreach (var item in prdModel.ProductFeatures)
                        {
                            item.Product = bProduct.List().Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                            item.Product.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == item.Product_Id).ToList();
                        }

                        prdModel.ProductFeatures2 = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList();
                        foreach (var item in prdModel.ProductFeatures2)
                        {
                            item.Product = bProduct.List().Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                            item.Product.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == item.Product_Id).ToList();
                        }

                        prdModel.Categories = bCategory.List().Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                        foreach (var item in prdModel.Categories)
                        {
                            item.SubCategory = bSubCategory.List().Where(m => m.Category_Id == item.Category_Id && item.Category_Status == eStatus.Active.ToString()).ToList();
                        }

                        prdModel.ProdComments = ctx.ProdComments.Where(m => m.Product_Id == prdModel.Product.Product_Id && m.Comment_Status == eCommentStatus.Approved.ToString()).ToList();
                        if (HttpContext.Current.Session["UserKey"] != null)
                        {
                            int CustomerId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                            List<ProdComments> _commentsTemp = new List<ProdComments>();
                            _commentsTemp = ctx.ProdComments.Where(m => m.Customer_Id == CustomerId).ToList();
                            if (_commentsTemp != null)
                            {
                                prdModel.AlreadyCommentsDone = 1;
                                prdModel.ProdComments.AddRange(_commentsTemp);
                            }
                        }
                    }
                }
                return prdModel;
            }
        }

        public ProductPageModel GetProductPageDataOffline(int product_id)
        {
            ProductPageModel prdModel = new ProductPageModel();

            using (var ctx = new RachnaDBContext())
            {
                CartModel _cartMdl = new CartModel();
                prdModel.Carts = _cartMdl.GetCarts();
                prdModel.Product = bProduct.List().Where(m => m.Product_Id == product_id).FirstOrDefault();
                prdModel.Product.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == prdModel.Product.Product_Id).ToList();
                prdModel.Product.SubCategory = bSubCategory.List().Where(m => m.SubCategory_Id == prdModel.Product.SubCategory_Id).FirstOrDefault();

                prdModel.RelatedProducts = bProduct.List().Where(m => m.Product_Id != prdModel.Product.Product_Id).Take(4).ToList();
                foreach (var item in prdModel.RelatedProducts)
                {
                    item.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                prdModel.ProductFeatures = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList();
                foreach (var item in prdModel.ProductFeatures)
                {
                    item.Product = bProduct.List().Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                    item.Product.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                prdModel.ProductFeatures2 = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList();
                foreach (var item in prdModel.ProductFeatures2)
                {
                    item.Product = bProduct.List().Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                    item.Product.ProductBanner = bProduct.ListProductBanner().Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                prdModel.Categories = bCategory.List().Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in prdModel.Categories)
                {
                    item.SubCategory = bSubCategory.List().Where(m => m.Category_Id == item.Category_Id && item.Category_Status == eStatus.Active.ToString()).ToList();
                }

                prdModel.ProdComments = ctx.ProdComments.Where(m => m.Product_Id == prdModel.Product.Product_Id).ToList();
                if (HttpContext.Current.Session["UserKey"] != null)
                {
                    int CustomerId = Convert.ToInt32(HttpContext.Current.Session["UserKey"].ToString());
                    List<ProdComments> _commentsTemp = new List<ProdComments>();
                    _commentsTemp = ctx.ProdComments.Where(m => m.Customer_Id == CustomerId).ToList();
                    if (_commentsTemp != null)
                    {
                        prdModel.AlreadyCommentsDone = 1;
                        prdModel.ProdComments.AddRange(_commentsTemp);
                    }
                }
                return prdModel;
            }
        }
    }
}