using Rachna.Teracotta.Project.Source.App_Data;
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

        internal List<Product> List()
        {
            List<Product> Product = new List<Product>();
            try
            {
                Product = context.Product.Include("Admin").Include("Category").ToList();
                return Product;
            }
            catch (Exception ex)
            {
                Product[0].ErrorMessage = ex.Message;
                return Product;
            }
        }

        internal Product Update(Product Product)
        {
            try
            {
                context.Entry(Product).State = System.Data.Entity.EntityState.Modified;
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
    }
}