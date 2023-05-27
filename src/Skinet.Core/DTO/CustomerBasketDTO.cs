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
  }
}