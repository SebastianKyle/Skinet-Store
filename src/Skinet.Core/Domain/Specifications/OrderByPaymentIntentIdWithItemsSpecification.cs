using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities.OrderAggregate;

namespace Skinet.Core.Domain.Specifications
{
  public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
  {
    public OrderByPaymentIntentIdSpecification(string paymentIntentId)
        :base(o => o.PaymentIntentId == paymentIntentId)
    {

    }
  }
}