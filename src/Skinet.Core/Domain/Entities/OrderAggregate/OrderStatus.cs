using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Skinet.Core.Domain.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending, 

        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived,

        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed
    }
}