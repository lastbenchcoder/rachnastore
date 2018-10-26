using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Helper
{
    public static class ProductHelper
    {
        public static void CreateProductFlow(int product_id, string product_title, int Administrators_Id, string admin_name, string flow_detail, string status)
        {
            using (var ctx = new RachnaDBContext())
            {
                ProductFlow _product = new ProductFlow()
                {
                    Product_Id = product_id,
                    Product_Title = product_title,
                    Administrators_Id = Administrators_Id,
                    Product_Flow_CreatedBy = admin_name,
                    Product_Flow_Detail = flow_detail,
                    Product_Flow_CreatedDate = DateTime.Now,
                    Product_Status = status
                };

                ctx.ProductFlow.Add(_product);
                ctx.SaveChanges();
            }
        }

        public static List<ProductFlow> ListProductFlow(int product_id)
        {
            List<ProductFlow> _productflow = new List<ProductFlow>();
            using (var ctx = new RachnaDBContext())
            {
                _productflow = ctx.ProductFlow.Where(m => m.Product_Id == product_id).ToList();
            }
            return _productflow;
        }

        public static string GetProductStatus(string CurrentStatus)
        {
            string nextStatus = string.Empty;
            switch (CurrentStatus)
            {
                case "ReviewPending":
                    nextStatus = eProductStatus.ReviewCompleted.ToString();
                    break;
                case "ReviewCompleted":
                    nextStatus = eProductStatus.Approved.ToString();
                    break;
                case "Approved":
                    nextStatus = eProductStatus.Published.ToString();
                    break;
                default:
                    nextStatus = eProductStatus.ReviewPending.ToString();
                    break;
            }
            return nextStatus;
        }
    }
}