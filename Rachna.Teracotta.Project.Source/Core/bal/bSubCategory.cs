using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bSubCategory
    {
        public static SubCategories Create(SubCategories SubCategory)
        {
            dSubCategory _dSubCategory = new dSubCategory();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Sub Category", "New SubCategory " + SubCategory.SubCategory_Title +
                    "( " + SubCategory.SubCategory_Id + "  and " + SubCategory.SubCategoryCode + " ) created successfully.",
                    SubCategory.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New SubCategory Created", mailBody, "Activity Admin");
            }
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
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Sub Category", "SubCategory Updation " + SubCategory.SubCategory_Title +
                    "( " + SubCategory.SubCategory_Id + "  and " + SubCategory.SubCategoryCode + " ) updated successfully.",
                    SubCategory.Administrators_Id, DateTime.Now.ToString());
               

                MailHelper.SendEmail(MailHelper.EmailToSend(), "SubCategory Updation", mailBody, "Activity Admin");
            }
            return _dSubCategory.Update(SubCategory);
        }

        public static int Delete(SubCategories SubCategory)
        {
            dSubCategory _dSubCategory = new dSubCategory();
            return _dSubCategory.Delete(SubCategory);
        }
    }
}