using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Entity
{
    public enum eOrderDeliveryStatus
    {
        InTransist=0,
        OutForDelivery=1,
        DelveryCompleted=2,
        DeliveryFailed=3,
        DeliveryRejected=4
    }
}