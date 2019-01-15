using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dCategory
    {
        private RachnaDBContext context;
        internal dCategory()
        {
            context = new RachnaDBContext();
        }

        internal Categories Create(Categories Categories)
        {
            try
            {
                int maxCategoriesId = 1;
                if (context.Category.ToList().Count > 0)
                    maxCategoriesId = context.Category.Max(m => m.Category_Id);
                maxCategoriesId = (context.Category.ToList().Count > 0) ? (maxCategoriesId + 1) : maxCategoriesId;
                Categories.CategoryCode = "RT" + maxCategoriesId + "CATCODE" + (maxCategoriesId + 1);                
                context.Category.Add(Categories);
                context.SaveChanges();
                return Categories;
            }
            catch (Exception ex)
            {
                Categories.ErrorMessage = ex.Message;
                return Categories;
            }
        }

        internal List<Categories> List()
        {
            List<Categories> Categories = new List<Categories>();
            try
            {
                Categories = context.Category.Include("Admin").ToList();
                return Categories;
            }
            catch (Exception ex)
            {
                Categories[0].ErrorMessage = ex.Message;
                return Categories;
            }
        }

        internal Categories Update(Categories Categories)
        {
            try
            {
                var entity = context.Category.Where(c => c.Category_Id == Categories.Category_Id).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.Category.Add(Categories);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(Categories);
                }
                context.SaveChanges();
                return Categories;
            }
            catch (Exception ex)
            {
                Categories.ErrorMessage = ex.Message;
                return Categories;
            }
        }

        internal int Delete(Categories Categories)
        {
            try
            {
                context.Entry(Categories).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                Categories.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}