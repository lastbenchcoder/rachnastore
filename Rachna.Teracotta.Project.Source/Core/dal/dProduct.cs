﻿using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dProduct
    {
        private RachnaDBContext context;
        internal dProduct()
        {
            context = new RachnaDBContext();
        }

        internal Product Create(Product Product)
        {
            try
            {
                int maxProductId = 1;
                if (context.Product.ToList().Count > 0)
                    maxProductId = context.Product.Max(m => m.Product_Id);
                maxProductId = (context.Product.ToList().Count > 0) ? (maxProductId + 1) : maxProductId;
                Product.ProductCode = "RT" + maxProductId + "PRDCODE" + (maxProductId + 1);                
                context.Product.Add(Product);
                context.SaveChanges();
                return Product;
            }
            catch (Exception ex)
            {
                Product.ErrorMessage = ex.Message;
                return Product;
            }
        }

        internal ProductBanners CreateProductBanner(ProductBanners ProductBanner)
        {
            try
            {
                int maxProductId = 1;
                if (context.ProductBanner.ToList().Count > 0)
                    maxProductId = context.ProductBanner.Max(m => m.Product_Banner_Id);
                maxProductId = (context.ProductBanner.ToList().Count > 0) ? (maxProductId + 1) : maxProductId;
                ProductBanner.Product_BannerCode = "RT" + maxProductId + "PRDBNRCODE" + (maxProductId + 1);
                context.ProductBanner.Add(ProductBanner);
                context.SaveChanges();
                return ProductBanner;
            }
            catch (Exception ex)
            {
                ProductBanner.ErrorMessage = ex.Message;
                return ProductBanner;
            }
        }

        internal List<Product> List()
        {
            List<Product> Product = new List<Product>();
            try
            {
                Product = context.Product
                    .Include("SubCategory")
                    .Include("ProductBanner")
                    .Include("Admin")
                    .Include("Store").ToList();
                return Product;
            }
            catch (Exception ex)
            {
                Product[0].ErrorMessage = ex.Message;
                return Product;
            }
        }

        internal List<ProductBanners> ListProductBanner()
        {
            List<ProductBanners> ProductBanner = new List<ProductBanners>();
            try
            {
                ProductBanner = context.ProductBanner.ToList();
                return ProductBanner;
            }
            catch (Exception ex)
            {
                ProductBanner[0].ErrorMessage = ex.Message;
                return ProductBanner;
            }
        }

        internal Product Update(Product Product)
        {
            try
            {
                var entity = context.Product.Where(c => c.Product_Id == Product.Product_Id).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.Product.Add(Product);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(Product);
                }
                context.SaveChanges();
                return Product;
            }
            catch (Exception ex)
            {
                Product.ErrorMessage = ex.Message;
                return Product;
            }
        }

        internal int Delete(Product Product)
        {
            try
            {
                context.Entry(Product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                Product.ErrorMessage = ex.Message;
                return 404;
            }
        }

        internal void DeleteTopEight(int id)
        {
            ProductEight ProductEight = context.ProductEights.Where(m => m.Product_Id == id).FirstOrDefault();
            if (ProductEight != null)
            {
                context.Entry(ProductEight).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        internal void DeleteProductFeature(int id)
        {
            ProductFeatures ProductFeatures = context.ProductFeature.Where(m => m.Product_Id == id).FirstOrDefault();
            if (ProductFeatures != null)
            {
                context.Entry(ProductFeatures).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        internal void DeleteCart(int id)
        {
            List<Carts> Carts = bCarts.List().Where(m => m.Product_Id == id && m.Cart_Status == eCartStatus.Temp.ToString()).ToList();
            if (Carts.Count > 0)
            {
                foreach (var item in Carts)
                {
                    Carts Cart = bCarts.List().Where(m => m.Cart_Id == item.Cart_Id).FirstOrDefault();
                    if (Cart != null)
                    {
                        context.Entry(Cart).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}