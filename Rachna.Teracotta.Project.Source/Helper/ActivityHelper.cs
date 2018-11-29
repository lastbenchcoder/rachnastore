using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Helper
{
    public static class ActivityHelper
    {
        public static void Create(string category, string description, int adminId)
        {
            AdminActivity adminActivity = new AdminActivity()
            {
                Administrators_Id = adminId,
                Category=category,
                Description=description,
                Ip_Address= IpAddress.GetLocalIPAddress(),
                Activity_CreatedDate=DateTime.Now,
                Activity_UpdatedDate=DateTime.Now
            };

            bAdministrator.Create(adminActivity);
        }

        public static List<AdminActivity> ListByAdmin(int adminId)
        {
            List<AdminActivity> adminActivities = bAdministrator.ListActivityByAdmin(adminId);
            return adminActivities;
        }
    }
}