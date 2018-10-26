using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dContactOwner
    {
        private RachnaDBContext context;
        internal dContactOwner()
        {
            context = new RachnaDBContext();
        }

        internal ContactOwner Create(ContactOwner ContactOwner)
        {
            try
            {
                int maxContactOwnerId = 1;
                if (context.ContactOwner.ToList().Count > 0)
                    maxContactOwnerId = context.ContactOwner.Max(m => m.Contact_Owner_Id);
                maxContactOwnerId = (maxContactOwnerId == 1 && context.ContactOwner.ToList().Count > 0) ? (maxContactOwnerId + 1) : maxContactOwnerId;
                ContactOwner.Contact_Owner_Code = "RT" + maxContactOwnerId + "CTOCODE" + (maxContactOwnerId + 1);
                if (ContactOwner.Contact_Status == eStatus.Active.ToString())
                {
                    List<ContactOwner> _ContactOwner = context.ContactOwner.ToList();
                    foreach (var item in _ContactOwner)
                    {
                        item.Contact_Status = eStatus.InActive.ToString();
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                context.ContactOwner.Add(ContactOwner);
                context.SaveChanges();
                return ContactOwner;
            }
            catch (Exception ex)
            {
                ContactOwner.ErrorMessage = ex.Message;
                return ContactOwner;
            }
        }

        internal List<ContactOwner> List()
        {
            List<ContactOwner> ContactOwner = new List<ContactOwner>();
            try
            {
                ContactOwner = context.ContactOwner.Include("Administrators").ToList();
                return ContactOwner;
            }
            catch (Exception ex)
            {
                ContactOwner[0].ErrorMessage = ex.Message;
                return ContactOwner;
            }
        }

        internal ContactOwner Update(ContactOwner ContactOwner)
        {
            try
            {
                context.Entry(ContactOwner).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                UpdateAllInactive(ContactOwner.Contact_Owner_Id);
                return ContactOwner;
            }
            catch (Exception ex)
            {
                ContactOwner.ErrorMessage = ex.Message;
                return ContactOwner;
            }
        }

        internal void UpdateAllInactive(int id)
        {
            List<ContactOwner> _ContactOwner = context.ContactOwner.ToList();
            foreach (var item in _ContactOwner)
            {
                if (item.Contact_Owner_Id != id)
                {
                    item.Contact_Status = eStatus.InActive.ToString();
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        internal int Delete(ContactOwner ContactOwner)
        {
            try
            {
                context.Entry(ContactOwner).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                ContactOwner.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}