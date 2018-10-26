using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bLogo
    {
        public static Logo Create(Logo logo)
        {
            dLogo _dLogo = new dLogo();
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
            return _dLogo.Update(logo);
        }

        public static int Delete(Logo logo)
        {
            dLogo _dLogo = new dLogo();
            return _dLogo.Delete(logo);
        }
    }
}