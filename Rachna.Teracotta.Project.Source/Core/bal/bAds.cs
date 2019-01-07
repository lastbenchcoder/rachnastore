using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bAds
    {
        public static Ads Create(Ads ads)
        {
            dAds _dads = new dAds();
            ads= _dads.Create(ads);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Ads", "New Ads " + ads.Ads_RedirectUrl +
                    "( " + ads.Ads_Id + "  and " + ads.AdsCode + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Ads Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return ads;
        }

        public static List<Ads> List()
        {
            dAds _dads = new dAds();
            return _dads.List();
        }

        public static Ads Update(Ads ads)
        {
            dAds _dads = new dAds();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Ads", "Ads Updation done on " + ads.Ads_RedirectUrl +
                    "( " + ads.Ads_Id + "  and " + ads.AdsCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Ads Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dads.Update(ads);
        }

        public static int Delete(Ads ads)
        {
            dAds _dads = new dAds();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Ads", "Ads Deletion done on" + ads.Ads_RedirectUrl +
                    "( " + ads.Ads_Id + "  and " + ads.AdsCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Ads Deletion", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dads.Delete(ads);
        }
    }
}