using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dStores
    {
        private RachnaDBContext context;
        internal dStores()
        {
            context = new RachnaDBContext();
        }

        internal Stores Create(Stores stores)
        {
            try
            {
                int maxStoreId = 1;
                if (context.Store.ToList().Count > 0)
                    maxStoreId = context.Store.Max(m => m.Store_Id);
                maxStoreId = (maxStoreId == 1 && context.Store.ToList().Count > 0) ? (maxStoreId + 1) : maxStoreId;
                stores.StoreCode = "RT" + maxStoreId + "STRECODE" + (maxStoreId + 1);
                stores.Store_Url = "?storecode=" + stores.StoreCode + "&redirect-url=" + stores.Store_Name.Trim() + ".html";
                context.Store.Add(stores);
                context.SaveChanges();
                return stores;
            }
            catch (Exception ex)
            {
                stores.ErrorMessage = ex.Message;
                return stores;
            }
        }

        internal List<Stores> List()
        {
            List<Stores> stores = new List<Stores>();
            try
            {
                stores = context.Store.Include("Order").ToList();
                return stores;
            }
            catch (Exception ex)
            {
                stores[0].ErrorMessage = ex.Message;
                return stores;
            }
        }

        internal Stores Update(Stores stores)
        {
            try
            {
                context.Entry(stores).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return stores;
            }
            catch (Exception ex)
            {
                stores.ErrorMessage = ex.Message;
                return stores;
            }
        }

        internal List<Stores_Audit> AuditList()
        {
            List<Stores_Audit> stores_Audit = new List<Stores_Audit>();
            try
            {
                stores_Audit = context.Stores_Audit.ToList();
                return stores_Audit;
            }
            catch (Exception ex)
            {
                return stores_Audit;
            }
        }
    }
}