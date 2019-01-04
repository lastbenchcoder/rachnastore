using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bUnderConstrunction
    {
        public static UnderConstrunction Create(UnderConstrunction UnderConstrunction)
        {
            dUnderConstrunction _dUnderConstrunction = new dUnderConstrunction();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Under Construnction", "New Under Construnction " +
                    "( " + UnderConstrunction.UnderConst_Id + "  and " + UnderConstrunction.UnderConstCode + " ) created successfully.",
                    UnderConstrunction.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New UnderConstrunction Created", mailBody, "Activity Admin");
            }
            return _dUnderConstrunction.Create(UnderConstrunction);
        }

        public static List<UnderConstrunction> List()
        {
            dUnderConstrunction _dUnderConstrunction = new dUnderConstrunction();
            return _dUnderConstrunction.List();
        }

        public static UnderConstrunction Update(UnderConstrunction UnderConstrunction)
        {
            dUnderConstrunction _dUnderConstrunction = new dUnderConstrunction();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Under Construnction", "Under Updation " +
                    "( " + UnderConstrunction.UnderConst_Id + "  and " + UnderConstrunction.UnderConstCode + " ) done successfully.",
                    UnderConstrunction.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "UnderConstrunction Updation", mailBody, "Activity Admin");
            }
            return _dUnderConstrunction.Update(UnderConstrunction);
        }

        public static int Delete(UnderConstrunction UnderConstrunction)
        {
            dUnderConstrunction _dUnderConstrunction = new dUnderConstrunction();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Under Construnction", "Under Construnction Deletion " +
                    "( " + UnderConstrunction.UnderConst_Id + "  and " + UnderConstrunction.UnderConstCode + " ) done successfully.",
                    UnderConstrunction.Administrators_Id, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "UnderConstrunction Deletion", mailBody, "Activity Admin");
            }
            return _dUnderConstrunction.Delete(UnderConstrunction);
        }
    }
}