using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.Domain.Entities
{
  /// <summary>
  /// An entity represents a customer basket
  /// </summary>
  public class CustomerBasket
  {
    public CustomerBasket()
    {

    }

    public CustomerBasket(string id)
    {
      Id = id;
    }

    /// <summary>
    /// Basket id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The list of products in basket
    /// </summary>
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    /// <summary>
    /// Unique id of delivery method customer chose
    /// </summary>
    public int? DeliveryMethodId { get; set; }

    /// <summary>
    /// Client secret key for customer to confirm their payment intent
    /// </summary>
    public string? ClientSecret { get; set; }

    /// <summary>
    /// Id of payment intent - used for updating payment intent incase client make changes
    /// </summary>
    public string? PaymentIntentId { get; set; }

    /// <summary>
    /// Shipping price of chosen delivery method
    /// </summary>
    public decimal? ShippingPrice { get; set; }
  }
}