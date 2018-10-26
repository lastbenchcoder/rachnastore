using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dMetaInformation
    {
        private RachnaDBContext context;
        internal dMetaInformation()
        {
            context = new RachnaDBContext();
        }

        internal MetaInformation Create(MetaInformation MetaInformation)
        {
            try
            {
                int maxMetaInformationId = 1;
                if (context.MetaInformation.ToList().Count > 0)
                    maxMetaInformationId = context.MetaInformation.Max(m => m.Meta_Id);
                maxMetaInformationId = (maxMetaInformationId == 1 && context.MetaInformation.ToList().Count > 0) ? (maxMetaInformationId + 1) : maxMetaInformationId;
                MetaInformation.Meta_Code = "RT" + maxMetaInformationId + "MTCODE" + (maxMetaInformationId + 1);
                if (MetaInformation.Meta_Status == eStatus.Active.ToString())
                {
                    List<MetaInformation> _MetaInformation = context.MetaInformation.ToList();
                    foreach (var item in _MetaInformation)
                    {
                        item.Meta_Status = eStatus.InActive.ToString();
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                context.MetaInformation.Add(MetaInformation);
                context.SaveChanges();
                return MetaInformation;
            }
            catch (Exception ex)
            {
                MetaInformation.ErrorMessage = ex.Message;
                return MetaInformation;
            }
        }

        internal List<MetaInformation> List()
        {
            List<MetaInformation> MetaInformation = new List<MetaInformation>();
            try
            {
                MetaInformation = context.MetaInformation.Include("Administrators").ToList();
                return MetaInformation;
            }
            catch (Exception ex)
            {
                MetaInformation[0].ErrorMessage = ex.Message;
                return MetaInformation;
            }
        }

        internal MetaInformation Update(MetaInformation MetaInformation)
        {
            try
            {
                context.Entry(MetaInformation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                UpdateAllInactive(MetaInformation.Meta_Id);
                return MetaInformation;
            }
            catch (Exception ex)
            {
                MetaInformation.ErrorMessage = ex.Message;
                return MetaInformation;
            }
        }

        internal void UpdateAllInactive(int id)
        {
            List<MetaInformation> _MetaInformation = context.MetaInformation.ToList();
            foreach (var item in _MetaInformation)
            {
                if (item.Meta_Id != id)
                {
                    item.Meta_Status = eStatus.InActive.ToString();
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        internal int Delete(MetaInformation MetaInformation)
        {
            try
            {
                context.Entry(MetaInformation).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                MetaInformation.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}