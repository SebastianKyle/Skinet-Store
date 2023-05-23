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
  }
}