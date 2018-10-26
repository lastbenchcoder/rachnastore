using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dSocialNetworking
    {
        private RachnaDBContext context;
        internal dSocialNetworking()
        {
            context = new RachnaDBContext();
        }

        internal SocialNetworking Create(SocialNetworking SocialNetworking)
        {
            try
            {
                int maxSocialNetworkingId = 1;
                if (context.SocialNetworking.ToList().Count > 0)
                    maxSocialNetworkingId = context.SocialNetworking.Max(m => m.Scl_Ntk_Id);
                maxSocialNetworkingId = (maxSocialNetworkingId == 1 && context.SocialNetworking.ToList().Count > 0) ? (maxSocialNetworkingId + 1) : maxSocialNetworkingId;
                SocialNetworking.Scl_Ntk_Code = "RT" + maxSocialNetworkingId + "SLNCODE" + (maxSocialNetworkingId + 1);
                context.SocialNetworking.Add(SocialNetworking);
                context.SaveChanges();
                return SocialNetworking;
            }
            catch (Exception ex)
            {
                SocialNetworking.ErrorMessage = ex.Message;
                return SocialNetworking;
            }
        }

        internal List<SocialNetworking> List()
        {
            List<SocialNetworking> SocialNetworking = new List<SocialNetworking>();
            try
            {
                SocialNetworking = context.SocialNetworking.Include("Administrators").ToList();
                return SocialNetworking;
            }
            catch (Exception ex)
            {
                SocialNetworking[0].ErrorMessage = ex.Message;
                return SocialNetworking;
            }
        }

        internal SocialNetworking Update(SocialNetworking SocialNetworking)
        {
            try
            {
                context.Entry(SocialNetworking).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return SocialNetworking;
            }
            catch (Exception ex)
            {
                SocialNetworking.ErrorMessage = ex.Message;
                return SocialNetworking;
            }
        }

        internal int Delete(SocialNetworking SocialNetworking)
        {
            try
            {
                context.Entry(SocialNetworking).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                SocialNetworking.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}