using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bAds
    {
        public static Ads Create(Ads ads)
        {
            dAds _dads = new dAds();
            return _dads.Create(ads);
        }

        public static List<Ads> List()
        {
            dAds _dads = new dAds();
            return _dads.List();
        }

        public static Ads Update(Ads ads)
        {
            dAds _dads = new dAds();
            return _dads.Update(ads);
        }

        public static int Delete(Ads ads)
        {
            dAds _dads = new dAds();
            return _dads.Delete(ads);
        }
    }
}