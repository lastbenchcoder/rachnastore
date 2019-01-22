using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dLogo
    {
        private RachnaDBContext context;
        internal dLogo()
        {
            context = new RachnaDBContext();
        }

        internal Logo Create(Logo Logo)
        {
            try
            {
                int maxLogoId = 1;
                if (context.Logo.ToList().Count > 0)
                    maxLogoId = context.Logo.Max(m => m.Logo_Id);
                maxLogoId = (maxLogoId == 1 && context.Logo.ToList().Count > 0) ? (maxLogoId + 1) : maxLogoId;
                Logo.LogoCode = "RT" + maxLogoId + "LOGCODE" + (maxLogoId + 1);
                if (Logo.Logo_Status == eStatus.Active.ToString())
                {
                    List<Logo> _Logo = context.Logo.ToList();
                    foreach (var item in _Logo)
                    {
                        item.Logo_Status = eStatus.InActive.ToString();
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                context.Logo.Add(Logo);
                context.SaveChanges();
                return Logo;
            }
            catch (Exception ex)
            {
                Logo.ErrorMessage = ex.Message;
                return Logo;
            }
        }

        internal List<Logo> List()
        {
            List<Logo> Logo = new List<Logo>();
            try
            {
                Logo = context.Logo.Include("Administrators").ToList();
                return Logo;
            }
            catch (Exception ex)
            {
                Logo[0].ErrorMessage = ex.Message;
                return Logo;
            }
        }

        internal Logo Update(Logo Logo)
        {
            try
            {
                var entity = context.Logo.Where(c => c.Logo_Id == Logo.Logo_Id).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.Logo.Add(Logo);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(Logo);
                }
                context.SaveChanges();
                return Logo;
            }
            catch (Exception ex)
            {
                Logo.ErrorMessage = ex.Message;
                return Logo;
            }
        }

        internal void UpdateAllInactive(int id)
        {
            List<Logo> _logo = context.Logo.ToList();
            foreach (var item in _logo)
            {
                if (item.Logo_Id != id)
                {
                    item.Logo_Status = eStatus.InActive.ToString();
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        internal int Delete(Logo Logo)
        {
            try
            {
                context.Entry(Logo).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                Logo.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}