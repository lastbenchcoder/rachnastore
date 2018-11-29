using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bAdministrator
    {
        public static Administrators Create(Administrators administrators)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.Create(administrators);
        }

        public static List<Administrators> List()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.List();
        }

        public static Administrators Update(Administrators administrators)
        {
            dAdministrator _dAdministrator = new dAdministrator();
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