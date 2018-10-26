using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Entity
{
    public enum eFunctionalityStatus
    {
        InProgress = 0,
        Completed = 1,
        Testing = 2,
        Defect = 3,
        Resolved = 4,
        NotValid = 5,
        Proposed = 6,
        Reopened
    }
}