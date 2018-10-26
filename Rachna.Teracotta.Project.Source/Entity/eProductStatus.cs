using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Entity
{
    public enum eProductStatus
    {
        Draft = 0,
        Submitted = 1,
        ReviewPending = 2,
        ReviewCompleted = 3,
        ApprovePending = 4,
        Approved = 5,
        PublishPending = 6,
        Published = 7,
        Rejected = 8
    }
}