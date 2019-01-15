using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bFunctionality
    {
        public static Functionality Create(Functionality Functionality)
        {
            dFunctionality _dFunctionality = new dFunctionality();
            return _dFunctionality.Create(Functionality);
        }        

        public static List<Functionality> List()
        {
            dFunctionality _dFunctionality = new dFunctionality();
            return _dFunctionality.List();
        }

        public static Functionality Update(Functionality Functionality)
        {
            dFunctionality _dFunctionality = new dFunctionality();
            return _dFunctionality.Update(Functionality);
        }

        public static int Delete(Functionality Functionality)
        {
            dFunctionality _dFunctionality = new dFunctionality();
            return _dFunctionality.Delete(Functionality);
        }
    }
}