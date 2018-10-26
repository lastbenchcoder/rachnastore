using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bUnderConstrunction
    {
        public static UnderConstrunction Create(UnderConstrunction UnderConstrunction)
        {
            dUnderConstrunction _dUnderConstrunction = new dUnderConstrunction();
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
            return _dUnderConstrunction.Update(UnderConstrunction);
        }

        public static int Delete(UnderConstrunction UnderConstrunction)
        {
            dUnderConstrunction _dUnderConstrunction = new dUnderConstrunction();
            return _dUnderConstrunction.Delete(UnderConstrunction);
        }
    }
}