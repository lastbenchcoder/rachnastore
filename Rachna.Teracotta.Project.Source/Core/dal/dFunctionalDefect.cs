using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dFunctionalDefect
    {
        private RachnaDBContext context;
        internal dFunctionalDefect()
        {
            context = new RachnaDBContext();
        }

        internal FunctionalDefect Create(FunctionalDefect FunctionalDefect)
        {
            try
            {
                int maxDefectId = 1;
                if (context.FunctionalDefect.ToList().Count > 0)
                    maxDefectId = context.FunctionalDefect.Max(m => m.Defect_Id);
                maxDefectId = (context.FunctionalDefect.ToList().Count > 0) ? (maxDefectId + 1) : maxDefectId;
                FunctionalDefect.DefectCode = "RT" + maxDefectId + "FUNDEFCODE" + (maxDefectId + 1);
                context.FunctionalDefect.Add(FunctionalDefect);
                context.SaveChanges();
                return FunctionalDefect;
            }
            catch (Exception ex)
            {
                FunctionalDefect.ErrorMessage = ex.Message;
                return FunctionalDefect;
            }
        }

        internal List<FunctionalDefectStory> ListStory(int defectid)
        {
            List<FunctionalDefectStory> FunctionalDefectStory = new List<FunctionalDefectStory>();
            try
            {
                FunctionalDefectStory = context.FunctionalDefectStory.Include("Administrators").Where(m=>m.Defect_Id== defectid).ToList();
                foreach (var item in FunctionalDefectStory)
                {
                    item.Resolver = context.Administrator.Where(m => m.Administrators_Id == item.Resolver_Id).FirstOrDefault();
                }
                return FunctionalDefectStory;
            }
            catch (Exception ex)
            {
                FunctionalDefectStory[0].ErrorMessage = ex.Message;
                return FunctionalDefectStory;
            }
        }

        internal FunctionalDefectStory CreateDefectStory(FunctionalDefectStory functionalDefectStory)
        {
            try
            {
                int maxDefectId = 1;
                if (context.FunctionalDefectStory.ToList().Count > 0)
                    maxDefectId = context.FunctionalDefectStory.Max(m => m.FunctionalDefectStory_Id);
                maxDefectId = (context.FunctionalDefectStory.ToList().Count > 0) ? (maxDefectId + 1) : maxDefectId;
                functionalDefectStory.FunDefectStryCode = "RT" + maxDefectId + "FUNSTRDEFCODE" + (maxDefectId + 1);
                context.FunctionalDefectStory.Add(functionalDefectStory);
                context.SaveChanges();
                return functionalDefectStory;
            }
            catch (Exception ex)
            {
                functionalDefectStory.ErrorMessage = ex.Message;
                return functionalDefectStory;
            }
        }

        internal List<FunctionalDefect> List()
        {
            List<FunctionalDefect> FunctionalDefect = new List<FunctionalDefect>();
            try
            {
                FunctionalDefect = context.FunctionalDefect.Include("FunctionalDefectStory").Include("Administrators").ToList();
                foreach(var item in FunctionalDefect)
                {
                    item.Resolver = context.Administrator.Where(m => m.Administrators_Id == item.Resolver_Id).FirstOrDefault();
                }
                return FunctionalDefect;
            }
            catch (Exception ex)
            {
                FunctionalDefect[0].ErrorMessage = ex.Message;
                return FunctionalDefect;
            }
        }

        internal FunctionalDefect Update(FunctionalDefect FunctionalDefect)
        {
            try
            {
                context.Entry(FunctionalDefect).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return FunctionalDefect;
            }
            catch (Exception ex)
            {
                FunctionalDefect.ErrorMessage = ex.Message;
                return FunctionalDefect;
            }
        }

        internal int Delete(FunctionalDefect FunctionalDefect)
        {
            try
            {
                context.Entry(FunctionalDefect).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                FunctionalDefect.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}