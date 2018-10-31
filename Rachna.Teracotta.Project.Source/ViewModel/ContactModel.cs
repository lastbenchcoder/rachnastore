using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public sealed class ContactModel
    {
        private static ContactModel instance = null;
        private static readonly object padlock = new object();

        public ContactModel()
        {
        }

        public static ContactModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ContactModel();
                        }
                    }
                }
                return instance;
            }
        }

        public UnderConstrunction PageUnderConstruction()
        {
            UnderConstrunction underConstrunction = new UnderConstrunction();
            underConstrunction = bUnderConstrunction.List().Where(m => m.UnderConst_Status == eStatus.Active.ToString()).FirstOrDefault();
            return underConstrunction;
        }

        public ContactOwner ContactUs()
        {
            ContactOwner contactOwner = new ContactOwner();
            contactOwner = bContactOwner.List().Where(m => m.Contact_Status == eStatus.Active.ToString()).FirstOrDefault();
            return contactOwner;
        }
    }
}