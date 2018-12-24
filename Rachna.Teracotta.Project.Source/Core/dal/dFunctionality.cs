using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dFunctionality
    {
        private RachnaDBContext context;
        internal dFunctionality()
        {
            context = new RachnaDBContext();
        }

        internal Functionality Create(Functionality Functionality)
        {
            try
            {
                int maxCategoriesId = 1;
                if (context.Functionality.ToList().Count > 0)
                    maxCategoriesId = context.Functionality.Max(m => m.Function_Id);
                maxCategoriesId = (context.Functionality.ToList().Count > 0) ? (maxCategoriesId + 1) : maxCategoriesId;
                Functionality.FunctionCode = "RT" + maxCategoriesId + "FUNCTCODE" + (maxCategoriesId + 1);
                context.Functionality.Add(Functionality);
                context.SaveChanges();
                return Functionality;
            }
            catch (Exception ex)
            {
                Functionality.ErrorMessage = ex.Message;
                return Functionality;
            }
        }

        internal List<Functionality> List()
        {
            List<Functionality> Functionality = new List<Functionality>();
            try
            {
                Functionality = context.Functionality.Include("Administrators").ToList();
                return Functionality;
            }
            catch (Exception ex)
            {
                Functionality[0].ErrorMessage = ex.Message;
                return Functionality;
            }
        }

        internal Functionality Update(Functionality Functionality)
        {
            try
            {
                context.Entry(Functionality).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return Functionality;
            }
            catch (Exception ex)
            {
                Functionality.ErrorMessage = ex.Message;
                return Functionality;
            }
        }

        internal int Delete(Functionality Functionality)
        {
            try
            {
                context.Entry(Functionality).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                Functionality.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}