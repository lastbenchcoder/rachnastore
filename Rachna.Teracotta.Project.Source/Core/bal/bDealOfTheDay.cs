using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bDealOfTheDay
    {
        public static DealOfTheDay Create(DealOfTheDay DealOfTheDay)
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            DealOfTheDay= _dDealOfTheDay.Create(DealOfTheDay);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Deal Of The Day", "Deal Of The Day Create " +
                    "( " + DealOfTheDay.Deal_Id + "  and " + DealOfTheDay.Deal_Code + " ) created successfully.",
                    DealOfTheDay.Administrators_Id, DateTime.Now.ToString());


                MailHelper.SendEmail(MailHelper.EmailToSend(), "Deal Of The Day Create", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return DealOfTheDay;
        }

        public static List<DealOfTheDay> List()
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            return _dDealOfTheDay.List();
        }
        public static DealOfTheDay Update(DealOfTheDay DealOfTheDay)
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Deal Of The Day", "Deal Of The Day Updation done on " +
                    "( " + DealOfTheDay.Deal_Id + "  and " + DealOfTheDay.Deal_Code + " ) successfully.",
                    DealOfTheDay.Administrators_Id, DateTime.Now.ToString());


                MailHelper.SendEmail(MailHelper.EmailToSend(), "Deal Of The Day Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dDealOfTheDay.Update(DealOfTheDay);
        }
        public static List<DealOfTheDay_Audit> AuditList()
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            return _dDealOfTheDay.AuditList();
        }
    }
}