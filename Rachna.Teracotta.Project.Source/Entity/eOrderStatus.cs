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
        Shipped = 2,
        Dispached = 3,
        Delevery = 4,
        Delivered = 5,
        Rejected = 6,
        Cancelled = 7
    }
}