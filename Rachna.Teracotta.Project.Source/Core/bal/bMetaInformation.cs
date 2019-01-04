using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bMetaInformation
    {
        public static MetaInformation Create(MetaInformation MetaInformation)
        {
            dMetaInformation _dMetaInformation = new dMetaInformation();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Meta Information", "New Meta Information " + MetaInformation.Meta_Title +
                    "( " + MetaInformation.Meta_Id + "  and " + MetaInformation.Meta_Code + " ) created successfully.",
                    MetaInformation.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Meta Information Created", mailBody, "Activity Admin");
            }
            return _dMetaInformation.Create(MetaInformation);
        }

        public static List<MetaInformation> List()
        {
            dMetaInformation _dMetaInformation = new dMetaInformation();
            return _dMetaInformation.List();
        }

        public static MetaInformation Update(MetaInformation MetaInformation)
        {
            dMetaInformation _dMetaInformation = new dMetaInformation();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Meta Information", "Meta Information Updation " + MetaInformation.Meta_Title +
                    "( " + MetaInformation.Meta_Id + "  and " + MetaInformation.Meta_Code + " ) done successfully.",
                    MetaInformation.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Meta Information Updation ", mailBody, "Activity Admin");
            }
            return _dMetaInformation.Update(MetaInformation);
        }

        public static int Delete(MetaInformation MetaInformation)
        {
            dMetaInformation _dMetaInformation = new dMetaInformation();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Meta Information", "Meta Information Deletion " + MetaInformation.Meta_Title +
                    "( " + MetaInformation.Meta_Id + "  and " + MetaInformation.Meta_Code + " ) done successfully.",
                    MetaInformation.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Meta Information Deletion ", mailBody, "Activity Admin");
            }
            return _dMetaInformation.Delete(MetaInformation);
        }
    }
}