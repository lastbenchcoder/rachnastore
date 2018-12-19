using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dSubCategory
    {
        private RachnaDBContext context;
        internal dSubCategory()
        {
            context = new RachnaDBContext();
        }

        internal SubCategories Create(SubCategories SubCategories)
        {
            try
            {
                int maxSubCategoriesId = 1;
                if (context.SubCategory.ToList().Count > 0)
                    maxSubCategoriesId = context.SubCategory.Max(m => m.SubCategory_Id);
                maxSubCategoriesId = (context.SubCategory.ToList().Count > 0) ? (maxSubCategoriesId + 1) : maxSubCategoriesId;
                SubCategories.SubCategoryCode = "RT" + maxSubCategoriesId + "SCATCODE" + (maxSubCategoriesId + 1);                
                context.SubCategory.Add(SubCategories);
                context.SaveChanges();
                return SubCategories;
            }
            catch (Exception ex)
            {
                SubCategories.ErrorMessage = ex.Message;
                return SubCategories;
            }
        }

        internal List<SubCategories> List()
        {
            List<SubCategories> SubCategories = new List<SubCategories>();
            try
            {
                SubCategories = context.SubCategory.Include("Admin").Include("Category").ToList();
                return SubCategories;
            }
            catch (Exception ex)
            {
                SubCategories[0].ErrorMessage = ex.Message;
                return SubCategories;
            }
        }

        internal SubCategories Update(SubCategories SubCategories)
        {
            try
            {
                context.Entry(SubCategories).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return SubCategories;
            }
            catch (Exception ex)
            {
                SubCategories.ErrorMessage = ex.Message;
                return SubCategories;
            }
        }

        internal int Delete(SubCategories SubCategories)
        {
            try
            {
                context.Entry(SubCategories).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                SubCategories.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}