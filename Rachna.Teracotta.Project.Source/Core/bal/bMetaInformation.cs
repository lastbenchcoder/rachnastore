using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bMetaInformation
    {
        public static MetaInformation Create(MetaInformation MetaInformation)
        {
            dMetaInformation _dMetaInformation = new dMetaInformation();
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
            return _dMetaInformation.Update(MetaInformation);
        }

        public static int Delete(MetaInformation MetaInformation)
        {
            dMetaInformation _dMetaInformation = new dMetaInformation();
            return _dMetaInformation.Delete(MetaInformation);
        }
    }
}