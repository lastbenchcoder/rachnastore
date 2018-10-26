using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dUnderConstrunction
    {
        private RachnaDBContext context;
        internal dUnderConstrunction()
        {
            context = new RachnaDBContext();
        }

        internal UnderConstrunction Create(UnderConstrunction UnderConstrunction)
        {
            try
            {
                int maxUnderConstrunctionId = 1;
                if (context.UnderConstrunction.ToList().Count > 0)
                    maxUnderConstrunctionId = context.UnderConstrunction.Max(m => m.UnderConst_Id);
                maxUnderConstrunctionId = (maxUnderConstrunctionId == 1 && context.UnderConstrunction.ToList().Count > 0) ? (maxUnderConstrunctionId + 1) : maxUnderConstrunctionId;
                UnderConstrunction.UnderConstCode = "RT" + maxUnderConstrunctionId + "UNDCNSTCODE" + (maxUnderConstrunctionId + 1);
                if (UnderConstrunction.UnderConst_Status == eStatus.Active.ToString())
                {
                    List<UnderConstrunction> _UnderConstrunction = context.UnderConstrunction.ToList();
                    foreach (var item in _UnderConstrunction)
                    {
                        item.UnderConst_Status = eStatus.InActive.ToString();
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                context.UnderConstrunction.Add(UnderConstrunction);
                context.SaveChanges();
                return UnderConstrunction;
            }
            catch (Exception ex)
            {
                UnderConstrunction.ErrorMessage = ex.Message;
                return UnderConstrunction;
            }
        }

        internal List<UnderConstrunction> List()
        {
            List<UnderConstrunction> UnderConstrunction = new List<UnderConstrunction>();
            try
            {
                UnderConstrunction = context.UnderConstrunction.Include("Administrators").ToList();
                return UnderConstrunction;
            }
            catch (Exception ex)
            {
                UnderConstrunction[0].ErrorMessage = ex.Message;
                return UnderConstrunction;
            }
        }

        internal UnderConstrunction Update(UnderConstrunction UnderConstrunction)
        {
            try
            {
                context.Entry(UnderConstrunction).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                UpdateAllInactive(UnderConstrunction.UnderConst_Id);
                return UnderConstrunction;
            }
            catch (Exception ex)
            {
                UnderConstrunction.ErrorMessage = ex.Message;
                return UnderConstrunction;
            }
        }

        internal void UpdateAllInactive(int id)
        {
            List<UnderConstrunction> _UnderConstrunction = context.UnderConstrunction.ToList();
            foreach (var item in _UnderConstrunction)
            {
                if (item.UnderConst_Id != id)
                {
                    item.UnderConst_Status = eStatus.InActive.ToString();
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        internal int Delete(UnderConstrunction UnderConstrunction)
        {
            try
            {
                context.Entry(UnderConstrunction).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                UnderConstrunction.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}