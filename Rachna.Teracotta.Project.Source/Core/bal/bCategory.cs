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
    public static class bCategory
    {
        public static Categories Create(Categories Category)
        {
            dCategory _dCategory = new dCategory();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Sub Category", "New SubCategory " + Category.Category_Title +
                    "( " + Category.Category_Id + "  and " + Category.CategoryCode + " ) created successfully.",
                    Category.Administrators_Id, DateTime.Now.ToString());
               

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Category Created", mailBody, "Activity Admin");
            }
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
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Sub Category", "Category Updation " + Category.Category_Title +
                    "( " + Category.Category_Id + "  and " + Category.CategoryCode + " ) updated successfully.",
                    Category.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Category Updation ", mailBody, "Activity Admin");
            }
            return _dCategory.Delete(Category);
        }
    }
}