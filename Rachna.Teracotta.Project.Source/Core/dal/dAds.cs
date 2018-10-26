using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dAds
    {
        private RachnaDBContext context;
        internal dAds()
        {
            context = new RachnaDBContext();
        }

        internal Ads Create(Ads ads)
        {
            try
            {
                int maxAdsId = 1;
                if (context.Advertisement.ToList().Count > 0)
                    maxAdsId = context.Advertisement.Max(m => m.Ads_Id);
                maxAdsId = (maxAdsId == 1 && context.Advertisement.ToList().Count > 0) ? (maxAdsId + 1) : maxAdsId;
                ads.AdsCode = "RT" + maxAdsId + "ADVCODE" + (maxAdsId + 1);
                context.Advertisement.Add(ads);
                context.SaveChanges();
                return ads;
            }
            catch (Exception ex)
            {
                ads.ErrorMessage = ex.Message;
                return ads;
            }            
        }

        internal List<Ads> List()
        {
            List<Ads> ads = new List<Ads>();
            try
            {
                ads = context.Advertisement.Include("Administrators").ToList();
                return ads;
            }
            catch (Exception ex)
            {
                ads[0].ErrorMessage = ex.Message;
                return ads;
            }
        }

        internal Ads Update(Ads ads)
        {
            try
            {
                context.Entry(ads).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return ads;
            }
            catch (Exception ex)
            {
                ads.ErrorMessage = ex.Message;
                return ads;
            }
        }

        internal int Delete(Ads ads)
        {
            try
            {
                context.Entry(ads).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                ads.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}