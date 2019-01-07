using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bSocialNetworking
    {
        public static SocialNetworking Create(SocialNetworking SocialNetworking)
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            _dSocialNetworking.Create(SocialNetworking);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Social Networking", "New Social Networking " +
                    "( " + SocialNetworking.Scl_Ntk_Id + "  and " + SocialNetworking.Scl_Ntk_Code + " ) created successfully.",
                    SocialNetworking.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Social Networking Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return SocialNetworking;
        }

        public static List<SocialNetworking> List()
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            return _dSocialNetworking.List();
        }

        public static SocialNetworking Update(SocialNetworking SocialNetworking)
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Social Networking", "MetaInformation Udation done on " +
                    "( " + SocialNetworking.Scl_Ntk_Id + "  and " + SocialNetworking.Scl_Ntk_Code + " ) successfully.",
                    SocialNetworking.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Social Networking Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dSocialNetworking.Update(SocialNetworking);
        }

        public static int Delete(SocialNetworking SocialNetworking)
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Social Networking", "Social Networking Deletion done on " +
                    "( " + SocialNetworking.Scl_Ntk_Id + "  and " + SocialNetworking.Scl_Ntk_Code + " ) successfully.",
                    SocialNetworking.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Social Networking Deletion", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dSocialNetworking.Delete(SocialNetworking);
        }
    }
}