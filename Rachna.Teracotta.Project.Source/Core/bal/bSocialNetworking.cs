using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bSocialNetworking
    {
        public static SocialNetworking Create(SocialNetworking SocialNetworking)
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            return _dSocialNetworking.Create(SocialNetworking);
        }

        public static List<SocialNetworking> List()
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            return _dSocialNetworking.List();
        }

        public static SocialNetworking Update(SocialNetworking SocialNetworking)
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            return _dSocialNetworking.Update(SocialNetworking);
        }

        public static int Delete(SocialNetworking SocialNetworking)
        {
            dSocialNetworking _dSocialNetworking = new dSocialNetworking();
            return _dSocialNetworking.Delete(SocialNetworking);
        }
    }
}