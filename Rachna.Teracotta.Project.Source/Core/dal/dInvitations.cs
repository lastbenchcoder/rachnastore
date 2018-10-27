using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dInvitations
    {
        private RachnaDBContext context;
        internal dInvitations()
        {
            context = new RachnaDBContext();
        }

        internal Invitations Create(Invitations invitations)
        {
            try
            {
                int maxInvitationId = 0;
                if (context.Invitation.ToList().Count > 0)
                    maxInvitationId = context.Invitation.Max(m => m.Invitation_Id);
                maxInvitationId = (maxInvitationId > 0) ? (maxInvitationId + 1) : 1;
                invitations.Invitation_Code = "RT" + maxInvitationId + "INVTCODE" + (maxInvitationId + 1);
                context.Invitation.Add(invitations);
                context.SaveChanges();
                return invitations;
            }
            catch (Exception ex)
            {
                invitations.ErrorMessage = ex.Message;
                return invitations;
            }            
        }

        internal List<Invitations> List()
        {
            List<Invitations> invitations = new List<Invitations>();
            try
            {
                invitations = context.Invitation.Include("Store").ToList();
                return invitations;
            }
            catch (Exception ex)
            {
                invitations[0].ErrorMessage = ex.Message;
                return invitations;
            }
        }

        internal Invitations Update(Invitations invitations)
        {
            try
            {
                context.Entry(invitations).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return invitations;
            }
            catch (Exception ex)
            {
                invitations.ErrorMessage = ex.Message;
                return invitations;
            }
        }

        internal List<Invitations_Audit> AuditList()
        {
            List<Invitations_Audit> invitations = new List<Invitations_Audit>();
            try
            {
                invitations = context.Invitations_Audit.ToList();
                return invitations;
            }
            catch (Exception ex)
            {
                return invitations;
            }
        }
    }
}