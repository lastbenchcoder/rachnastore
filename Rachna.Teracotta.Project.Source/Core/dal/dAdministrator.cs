using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dAdministrator
    {
        private RachnaDBContext context;
        internal dAdministrator()
        {
            context = new RachnaDBContext();
        }

        internal Administrators Create(Administrators administrators)
        {
            try
            {
                int maxAdministratorsId = 1;
                if (context.Administrator.ToList().Count > 0)
                    maxAdministratorsId = context.Administrator.Max(m => m.Administrators_Id);
                maxAdministratorsId = (maxAdministratorsId == 1 && context.Administrator.ToList().Count > 0) ? (maxAdministratorsId + 1) : maxAdministratorsId;
                administrators.AdminCode = "RT" + maxAdministratorsId + "ADMCODE" + (maxAdministratorsId + 1);
                context.Administrator.Add(administrators);
                context.SaveChanges();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators.ErrorMessage = ex.Message;
                return administrators;
            }            
        }

        internal List<Administrators> List()
        {
            List<Administrators> administrators = new List<Administrators>();
            try
            {
                administrators = context.Administrator.Include("Store").ToList();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators[0].ErrorMessage = ex.Message;
                return administrators;
            }
        }

        internal Administrators Update(Administrators administrators)
        {
            try
            {
                int maxAdministratorsId = 1;
                if (context.Administrator.ToList().Count > 0)
                    maxAdministratorsId = context.Administrator.Max(m => m.Administrators_Id);
                maxAdministratorsId = (maxAdministratorsId == 1 && context.Administrator.ToList().Count > 0) ? (maxAdministratorsId + 1) : maxAdministratorsId;
                administrators.AdminCode = "RT" + maxAdministratorsId + "ADMCODE" + (maxAdministratorsId + 1);
                context.Entry(administrators).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators.ErrorMessage = ex.Message;
                return administrators;
            }
        }

        internal int CreateChatMessage(AdminChatting adminChatting)
        {
            try
            {
                context.AdminChatting.Add(adminChatting);
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                return 404;
            }
        }
        internal List<AdminChatting> ListChatMessage()
        {
            List<AdminChatting> adminChatting = new List<AdminChatting>();
            try
            {
                adminChatting = context.AdminChatting.Include("Administrators").ToList();
                return adminChatting;
            }
            catch (Exception ex)
            {
                adminChatting[0].ErrorMessage = ex.Message;
                return adminChatting;
            }
        }
    }
}