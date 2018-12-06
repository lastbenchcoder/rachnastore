using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bCategory
    {
        public static Categories Create(Categories Category)
        {
            dCategory _dCategory = new dCategory();
            return _dCategory.Create(Category);
        }

        public static List<Categories> List()
        {
            dCategory _dCategory = new dCategory();
            return _dCategory.List();
        }

        public static Categories Update(Categories Category)
        {
            dCategory _dCategory = new dCategory();
            return _dCategory.Update(Category);
        }

        public static int Delete(Categories Category)
        {
            dCategory _dCategory = new dCategory();
            return _dCategory.Delete(Category);
        }
    }
}