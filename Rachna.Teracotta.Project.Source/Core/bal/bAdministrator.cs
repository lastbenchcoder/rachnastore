using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bAdministrator
    {
        public static Administrators Create(Administrators administrators)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            administrators = _dAdministrator.Create(administrators);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Administrator", "New Administrator " + administrators.EmailId +
                    "( " + administrators.Administrators_Id + "  and " + administrators.AdminCode + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Administrator Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return administrators;
        }

        public static EmailTracker CreateEmailTracker(EmailTracker EmailTracker)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.CreateEmailTracker(EmailTracker);
        }

        public static List<Administrators> List()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.List();
        }

        public static List<EmailTracker> ListEmailTracker()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListEmailTracker();
        }

        public static Administrators Update(Administrators administrators)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Administrator", "Administrator Updation done on " + administrators.EmailId +
                    "( " + administrators.Administrators_Id + "  and " + administrators.AdminCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Administrator Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dAdministrator.Update(administrators);
        }

        public static int CreateChatMessage(AdminChatting adminChatting)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.CreateChatMessage(adminChatting);
        }

        public static List<AdminChatting> ListChatMessage()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListChatMessage();
        }

        public static AdminActivity Create(AdminActivity adminActivity)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.CreateActivity(adminActivity);
        }

        public static List<AdminActivity> ListActivity()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListActivity();
        }

        public static List<AdminActivity> ListActivityByAdmin(int adminId)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListActivityByAdmin(adminId);
        }
    }
}