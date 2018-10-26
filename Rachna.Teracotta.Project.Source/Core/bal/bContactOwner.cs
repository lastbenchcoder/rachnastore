using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bContactOwner
    {
        public static ContactOwner Create(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
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
            return _dContactOwner.Update(ContactOwner);
        }

        public static int Delete(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            return _dContactOwner.Delete(ContactOwner);
        }
    }
}