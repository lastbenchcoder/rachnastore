using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Entity
{
    public enum eOrderStatus
    {
        Placed = 0,
        Approved = 1,
        Packed = 2,
        Shipped = 3,
        Delevery = 4,
        Rejected = 6,
        Cancelled = 7
    }
}