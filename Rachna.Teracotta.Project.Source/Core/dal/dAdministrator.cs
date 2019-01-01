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
                int maxAdministratorsId = 0;
                if (context.Administrator.ToList().Count > 0)
                    maxAdministratorsId = context.Administrator.Max(m => m.Administrators_Id);
                maxAdministratorsId = (maxAdministratorsId > 0) ? (maxAdministratorsId + 1) : 1;
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

        internal EmailTracker CreateEmailTracker(EmailTracker EmailTracker)
        {
            context.EmailTracker.Add(EmailTracker);
            context.SaveChanges();
            return EmailTracker;
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

        internal List<EmailTracker> ListEmailTracker()
        {
            List<EmailTracker> EmailTracker = new List<EmailTracker>();
            EmailTracker = context.EmailTracker.ToList();
            return EmailTracker;
        }

        internal Administrators Update(Administrators administrators)
        {
            try
            {
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

        internal AdminActivity CreateActivity(AdminActivity adminActivity)
        {
            try
            {
                context.AdminActivity.Add(adminActivity);
                context.SaveChanges();
                return adminActivity;
            }
            catch (Exception ex)
            {
                adminActivity.ErrorMessage = ex.Message;
                return adminActivity;
            }
        }

        internal List<AdminActivity> ListActivity()
        {
            List<AdminActivity> administrators = new List<AdminActivity>();
            try
            {
                administrators = context.AdminActivity.Include("Administrators").ToList();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators[0].ErrorMessage = ex.Message;
                return administrators;
            }
        }

        internal List<AdminActivity> ListActivityByAdmin(int adminId)
        {
            List<AdminActivity> administrators = new List<AdminActivity>();
            try
            {
                administrators = context.AdminActivity.Include("Administrators").Where(m => m.Administrators_Id == adminId).ToList();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators[0].ErrorMessage = ex.Message;
                return administrators;
            }
        }
    }
}