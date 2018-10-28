using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dDealOfTheDay
    {
        private RachnaDBContext context;
        internal dDealOfTheDay()
        {
            context = new RachnaDBContext();
        }

        internal DealOfTheDay Create(DealOfTheDay DealOfTheDay)
        {
            try
            {
                int maxDealOfTheDayId = 0;
                if (context.DealOfTheDay.ToList().Count > 0)
                    maxDealOfTheDayId = context.DealOfTheDay.Max(m => m.Deal_Id);
                maxDealOfTheDayId = (maxDealOfTheDayId > 0) ? (maxDealOfTheDayId + 1) : 1;
                DealOfTheDay.Deal_Code = "RT" + maxDealOfTheDayId + "DEALCODE" + (maxDealOfTheDayId + 1);
                context.DealOfTheDay.Add(DealOfTheDay);
                context.SaveChanges();
                return DealOfTheDay;
            }
            catch (Exception ex)
            {
                DealOfTheDay.ErrorMessage = ex.Message;
                return DealOfTheDay;
            }
        }

        internal List<DealOfTheDay> List()
        {
            List<DealOfTheDay> DealOfTheDay = new List<DealOfTheDay>();
            try
            {
                DealOfTheDay = context.DealOfTheDay.Include("Product").ToList();
                if (DealOfTheDay != null && DealOfTheDay.Count > 0)
                {
                    foreach(var item in DealOfTheDay)
                    {
                        item.Product.ProductBanner = context.ProductBanner.Where(m => m.Product_Id == item.Product_Id).ToList();
                    }
                }
                return DealOfTheDay;
            }
            catch (Exception ex)
            {
                DealOfTheDay[0].ErrorMessage = ex.Message;
                return DealOfTheDay;
            }
        }

        internal DealOfTheDay Update(DealOfTheDay DealOfTheDay)
        {
            try
            {
                context.Entry(DealOfTheDay).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return DealOfTheDay;
            }
            catch (Exception ex)
            {
                DealOfTheDay.ErrorMessage = ex.Message;
                return DealOfTheDay;
            }
        }

        internal List<DealOfTheDay_Audit> AuditList()
        {
            List<DealOfTheDay_Audit> DealOfTheDay = new List<DealOfTheDay_Audit>();
            try
            {
                DealOfTheDay = context.DealOfTheDay_Audit.ToList();
                return DealOfTheDay;
            }
            catch (Exception ex)
            {
                return DealOfTheDay;
            }
        }
    }
}