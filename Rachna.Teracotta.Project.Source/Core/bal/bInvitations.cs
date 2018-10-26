using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bInvitations
    {
        public static Invitations Create(Invitations invitations)
        {
            dInvitations _dInvitations = new dInvitations();
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
            return _dInvitations.Update(invitations);
        }
        public static List<Invitations_Audit> AuditList()
        {
            dInvitations _dInvitations = new dInvitations();
            return _dInvitations.AuditList();
        }
    }
}