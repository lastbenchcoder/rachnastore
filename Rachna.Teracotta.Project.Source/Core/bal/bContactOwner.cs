using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bContactOwner
    {
        public static ContactOwner Create(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Contact Detail", "New Ads " + ContactOwner.Contact_Address +
                    "( " + ContactOwner.Contact_Owner_Id + "  and " + ContactOwner.Contact_Owner_Code + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New ContactOwner Created", mailBody, "Activity Admin");
            }
            return _dContactOwner.Create(ContactOwner);
        }

        public static List<ContactOwner> List()
        {
            dContactOwner _dContactOwner = new dContactOwner();
            return _dContactOwner.List();
        }

        public static ContactOwner Update(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Contact Detail", "Contact Owner Updation " + ContactOwner.Contact_Address +
                    "( " + ContactOwner.Contact_Owner_Id + "  and " + ContactOwner.Contact_Owner_Code + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Contact Owner Updation", mailBody, "Activity Admin");
            }
            return _dContactOwner.Update(ContactOwner);
        }

        public static int Delete(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Contact Detail", "Contact Owner Deletion " + ContactOwner.Contact_Address +
                    "( " + ContactOwner.Contact_Owner_Id + "  and " + ContactOwner.Contact_Owner_Code + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Contact Owner Deletion", mailBody, "Activity Admin");
            }
            return _dContactOwner.Delete(ContactOwner);
        }
    }
}