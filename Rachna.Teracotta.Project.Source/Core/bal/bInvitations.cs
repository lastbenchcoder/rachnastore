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
    public static class bInvitations
    {
        public static Invitations Create(Invitations invitations)
        {
            dInvitations _dInvitations = new dInvitations();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Invitations", "New Invitation " + invitations.Invitation_EmailId +
                    "( " + invitations.Invitation_Id + "  and " + invitations.Invitation_Code + " ) created successfully.",
                    1, DateTime.Now.ToString());
                string emailIdToSend = string.Empty;
                List<Administrators> Administrators = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Administrators)
                {
                    if (item.Admin_Role == eRole.Super.ToString())
                    {
                        if (!string.IsNullOrEmpty(emailIdToSend))
                        {
                            emailIdToSend = emailIdToSend + "," + item.EmailId;
                        }
                        else
                        {
                            emailIdToSend = item.EmailId;
                        }
                    }
                }

                MailHelper.SendEmail(emailIdToSend, "New SubCategory Created", mailBody, "Activity Admin");
            }
            return _dInvitations.Create(invitations);
        }

        public static List<Invitations> List()
        {
            dInvitations _dInvitations = new dInvitations();
            return _dInvitations.List();
        }
        public static Invitations Update(Invitations invitations)
        {
            dInvitations _dInvitations = new dInvitations();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Invitations", "Invitation Updation" + invitations.Invitation_EmailId +
                    "( " + invitations.Invitation_Id + "  and " + invitations.Invitation_Code + " ) updated successfully.",
                    1, DateTime.Now.ToString());
                string emailIdToSend = string.Empty;
                List<Administrators> Administrators = bAdministrator.List().Where(m => m.Admin_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Administrators)
                {
                    if (item.Admin_Role == eRole.Super.ToString())
                    {
                        if (!string.IsNullOrEmpty(emailIdToSend))
                        {
                            emailIdToSend = emailIdToSend + "," + item.EmailId;
                        }
                        else
                        {
                            emailIdToSend = item.EmailId;
                        }
                    }
                }

                MailHelper.SendEmail(emailIdToSend, "Invitation Updation", mailBody, "Activity Admin");
            }
            return _dInvitations.Update(invitations);
        }
        public static List<Invitations_Audit> AuditList()
        {
            dInvitations _dInvitations = new dInvitations();
            return _dInvitations.AuditList();
        }
    }
}