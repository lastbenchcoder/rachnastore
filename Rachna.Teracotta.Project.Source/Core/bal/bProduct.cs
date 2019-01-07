using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bProduct
    {
        public static Product Create(Product Product)
        {
            dProduct _dProduct = new dProduct();
            Product = _dProduct.Create(Product);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Product", "New Product " + Product.Product_Title +
                    "( " + Product.Product_Id + "  and " + Product.ProductCode + " ) created successfully.",
                    Product.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Product Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return Product;
        }

        public static ProductBanners CreateProductBanner(ProductBanners ProductBanner)
        {
            dProduct _dProduct = new dProduct();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Product", "New Product Banner " +
                    "( " + ProductBanner.Product_Banner_Id + "  and " + ProductBanner.Product_BannerCode + " ) created successfully.",
                    ProductBanner.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Product Banner Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dProduct.CreateProductBanner(ProductBanner);
        }

        public static List<Product> List()
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.List();
        }

        public static List<ProductBanners> ListProductBanner()
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.ListProductBanner();
        }

        public static Product Update(Product Product)
        {
            dProduct _dProduct = new dProduct();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Product", "Product Updation done on " + Product.Product_Title +
                    "( " + Product.Product_Id + "  and " + Product.ProductCode + " ) successfully.",
                    Product.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Product Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dProduct.Update(Product);
        }

        public static int Delete(Product Product)
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.Delete(Product);
        }

        internal static void DeleteTopEight(int product_Id)
        {
            dProduct _dProduct = new dProduct();
            _dProduct.DeleteTopEight(product_Id);
        }

        internal static void DeleteProductFeature(int product_Id)
        {
            dProduct _dProduct = new dProduct();
            _dProduct.DeleteProductFeature(product_Id);
        }

        internal static void DeleteCart(int product_Id)
        {
            dProduct _dProduct = new dProduct();
            _dProduct.DeleteCart(product_Id);
        }
    }
}