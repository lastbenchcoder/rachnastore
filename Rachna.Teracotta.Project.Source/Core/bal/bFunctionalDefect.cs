using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bFunctionalDefect
    {
        public static FunctionalDefect Create(FunctionalDefect FunctionalDefect)
        {
            dFunctionalDefect _dFunctionalDefect = new dFunctionalDefect();
            return _dFunctionalDefect.Create(FunctionalDefect);
        }

        public static FunctionalDefectStory CreateDefectStory(FunctionalDefectStory functionalDefectStory)
        {
            dFunctionalDefect _dFunctionalDefect = new dFunctionalDefect();
            return _dFunctionalDefect.CreateDefectStory(functionalDefectStory);
        }

        public static List<FunctionalDefect> List()
        {
            dFunctionalDefect _dFunctionalDefect = new dFunctionalDefect();
            return _dFunctionalDefect.List();
        }

        public static FunctionalDefect Update(FunctionalDefect FunctionalDefect)
        {
            dFunctionalDefect _dFunctionalDefect = new dFunctionalDefect();
            return _dFunctionalDefect.Update(FunctionalDefect);
        }

        public static int Delete(FunctionalDefect FunctionalDefect)
        {
            dFunctionalDefect _dFunctionalDefect = new dFunctionalDefect();
            return _dFunctionalDefect.Delete(FunctionalDefect);
        }
    }
}