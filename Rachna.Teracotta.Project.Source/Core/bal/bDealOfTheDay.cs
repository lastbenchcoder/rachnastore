using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bDealOfTheDay
    {
        public static DealOfTheDay Create(DealOfTheDay DealOfTheDay)
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            return _dDealOfTheDay.Create(DealOfTheDay);
        }

        public static List<DealOfTheDay> List()
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            return _dDealOfTheDay.List();
        }
        public static DealOfTheDay Update(DealOfTheDay DealOfTheDay)
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            return _dDealOfTheDay.Update(DealOfTheDay);
        }
        public static List<DealOfTheDay_Audit> AuditList()
        {
            dDealOfTheDay _dDealOfTheDay = new dDealOfTheDay();
            return _dDealOfTheDay.AuditList();
        }
    }
}