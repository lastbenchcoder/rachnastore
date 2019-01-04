using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bLogo
    {
        public static Logo Create(Logo logo)
        {
            dLogo _dLogo = new dLogo();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Logo", "New Logo " + logo.Logo_Title +
                    "( " + logo.Logo_Id + "  and " + logo.LogoCode + " ) created successfully.",
                    logo.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Logo Created", mailBody, "Activity Admin");
            }
            return _dLogo.Create(logo);
        }

        public static List<Logo> List()
        {
            dLogo _dLogo = new dLogo();
            return _dLogo.List();
        }

        public static Logo Update(Logo logo)
        {
            dLogo _dLogo = new dLogo();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Logo", "Updation Logo " + logo.Logo_Title +
                    "( " + logo.Logo_Id + "  and " + logo.LogoCode + " ) done successfully.",
                    logo.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Logo Deletion", mailBody, "Activity Admin");
            }
            return _dLogo.Update(logo);
        }

        public static int Delete(Logo logo)
        {
            dLogo _dLogo = new dLogo();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Logo", "Updation Logo " + logo.Logo_Title +
                    "( " + logo.Logo_Id + "  and " + logo.LogoCode + " ) done successfully.",
                    logo.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Logo Deletion", mailBody, "Activity Admin");
            }
            return _dLogo.Delete(logo);
        }
    }
}