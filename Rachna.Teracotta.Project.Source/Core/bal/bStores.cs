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
    public static class bStores
    {
        public static Stores Create(Stores stores)
        {
            dStores _dStores = new dStores();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Stores", "New Store " + stores.Store_Name +
                    "( " + stores.Store_Id + "  and " + stores.StoreCode + " ) created successfully.",
                    1, DateTime.Now.ToString());
                string emailIdToSend = string.Empty;
                List<Administrators> Administrators = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Administrators)
                {
                    if (item.Admin_Role == eRole.Super.ToString())
                    {
                        if (!string.IsNullOrEmpty(emailIdToSend))
                        {
                            emailIdToSend = emailIdToSend + "," + item.EmailId;
                        }
                        else
                        {
                            emailIdToSend = item.EmailId;
                        }
                    }
                }

                MailHelper.SendEmail(emailIdToSend, "New Store Created", mailBody, "Activity Admin");
            }
            return _dStores.Create(stores);
        }

        public static List<Stores> List()
        {
            dStores _dStores = new dStores();
            return _dStores.List();
        }

        public static Stores Update(Stores stores)
        {
            dStores _dStores = new dStores();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Stores", "Store Updation " + stores.Store_Name +
                    "( " + stores.Store_Id + "  and " + stores.StoreCode + " ) updated successfully.",
                    1, DateTime.Now.ToString());
                string emailIdToSend = string.Empty;
                List<Administrators> Administrators = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Administrators)
                {
                    if (item.Admin_Role == eRole.Super.ToString())
                    {
                        if (!string.IsNullOrEmpty(emailIdToSend))
                        {
                            emailIdToSend = emailIdToSend + "," + item.EmailId;
                        }
                        else
                        {
                            emailIdToSend = item.EmailId;
                        }
                    }
                }

                MailHelper.SendEmail(emailIdToSend, "Store Updation", mailBody, "Activity Admin");
            }
            return _dStores.Update(stores);
        }

        public static List<Stores_Audit> AuditList()
        {
            dStores _dStores = new dStores();
            return _dStores.AuditList();
        }
    }
}