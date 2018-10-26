using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bStores
    {
        public static Stores Create(Stores stores)
        {
            dStores _dStores = new dStores();
            return _dStores.Create(stores);
        }

        public static List<Stores> List()
        {
            dStores _dStores = new dStores();
            return _dStores.List();
        }

        public static Stores Update(Stores stores)
        {
            dStores _dStores = new dStores();
            return _dStores.Update(stores);
        }

        public static List<Stores_Audit> AuditList()
        {
            dStores _dStores = new dStores();
            return _dStores.AuditList();
        }
    }
}