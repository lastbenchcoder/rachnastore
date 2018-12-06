using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bSubCategory
    {
        public static SubCategories Create(SubCategories SubCategory)
        {
            dSubCategory _dSubCategory = new dSubCategory();
            return _dSubCategory.Create(SubCategory);
        }

        public static List<SubCategories> List()
        {
            dSubCategory _dSubCategory = new dSubCategory();
            return _dSubCategory.List();
        }

        public static SubCategories Update(SubCategories SubCategory)
        {
            dSubCategory _dSubCategory = new dSubCategory();
            return _dSubCategory.Update(SubCategory);
        }

        public static int Delete(SubCategories SubCategory)
        {
            dSubCategory _dSubCategory = new dSubCategory();
            return _dSubCategory.Delete(SubCategory);
        }
    }
}