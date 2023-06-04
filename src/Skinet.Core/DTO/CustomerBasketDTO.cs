using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.DTO
{
	/// <summary>
	/// DTO class for customber basket
	/// </summary>
  public class CustomerBasketDTO
  {
    /// <summary>
    /// Basket id
    /// </summary>
		[Required]
    public string Id { get; set; }

    /// <summary>
    /// The list of products in basket
    /// </summary>
    public List<BasketItemDTO> Items { get; set; } = new List<BasketItemDTO>();

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
    public string? PaymentItentId { get; set; }

    /// <summary>
    /// Shipping price of chosen delivery method
    /// </summary>
    public decimal? ShippingPrice { get; set; }
  }
}