using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class ProductModel
    {
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

    public class ProductPageModel
    {
        public ProductModel GetProductPageData(int product_id)
        {
            ProductModel prdModel = new ProductModel();

            using (var ctx = new RachnaDBContext())
            {
                CartModel _cartMdl = new CartModel();
                prdModel.Carts = _cartMdl.GetCarts();
                prdModel.Product = ctx.Product.Where(m => m.Product_Id == product_id).FirstOrDefault();
                if (prdModel.Product.Product_Status == eProductStatus.Published.ToString())
                {
                    prdModel.Product.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == prdModel.Product.Product_Id).ToList();
                    prdModel.Product.SubCategory = ctx.SubCategory.Where(m => m.SubCategory_Id == prdModel.Product.SubCategory_Id).FirstOrDefault();

                    prdModel.RelatedProducts = ctx.Product.Where(m => m.Product_Id != prdModel.Product.Product_Id && m.Product_Status == eProductStatus.Published.ToString()).Take(4).ToList();
                    foreach (var item in prdModel.RelatedProducts)
                    {
                        item.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                    }

                    prdModel.ProductFeatures = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList();
                    foreach (var item in prdModel.ProductFeatures)
                    {
                        item.Product = ctx.Product.Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                        item.Product.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                    }

                    prdModel.ProductFeatures2 = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList();
                    foreach (var item in prdModel.ProductFeatures2)
                    {
                        item.Product = ctx.Product.Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                        item.Product.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                    }

                    prdModel.Categories = ctx.Category.Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                    foreach (var item in prdModel.Categories)
                    {
                        item.SubCategory = ctx.SubCategory.Where(m => m.Category_Id == item.Category_Id && item.Category_Status == eStatus.Active.ToString()).ToList();
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
                return prdModel;
            }
        }

        public ProductModel GetProductPageDataOffline(int product_id)
        {
            ProductModel prdModel = new ProductModel();

            using (var ctx = new RachnaDBContext())
            {
                CartModel _cartMdl = new CartModel();
                prdModel.Carts = _cartMdl.GetCarts();
                prdModel.Product = ctx.Product.Where(m => m.Product_Id == product_id).FirstOrDefault();
                prdModel.Product.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == prdModel.Product.Product_Id).ToList();
                prdModel.Product.SubCategory = ctx.SubCategory.Where(m => m.SubCategory_Id == prdModel.Product.SubCategory_Id).FirstOrDefault();

                prdModel.RelatedProducts = ctx.Product.Where(m => m.Product_Id != prdModel.Product.Product_Id).Take(4).ToList();
                foreach (var item in prdModel.RelatedProducts)
                {
                    item.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                prdModel.ProductFeatures = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList();
                foreach (var item in prdModel.ProductFeatures)
                {
                    item.Product = ctx.Product.Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                    item.Product.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                prdModel.ProductFeatures2 = ctx.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList();
                foreach (var item in prdModel.ProductFeatures2)
                {
                    item.Product = ctx.Product.Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                    item.Product.ProductBanner = ctx.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                }

                prdModel.Categories = ctx.Category.Where(m => m.Category_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in prdModel.Categories)
                {
                    item.SubCategory = ctx.SubCategory.Where(m => m.Category_Id == item.Category_Id && item.Category_Status == eStatus.Active.ToString()).ToList();
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