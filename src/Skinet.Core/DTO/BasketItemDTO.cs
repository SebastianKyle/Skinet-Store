using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.DTO
{
	/// <summary>
	/// DTO class for BasketItem
	/// </summary>
  public class BasketItemDTO
  {
    /// <summary>
    /// Unique id or product
    /// </summary>
		[Required]
    public int Id { get; set; }

    /// <summary>
    /// Name of product
    /// </summary>
		[Required]
    public string ProductName { get; set; }

    /// <summary>
    /// Price of product
    /// </summary>
		[Required]
		[Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity of current product customer want
    /// </summary>
		[Required]
		[Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 1")]
    public int Quantity { get; set; }

    /// <summary>
    /// Url to product picture
    /// </summary>
		[Required]
    public string PictureUrl { get; set; }

    /// <summary>
    /// Brand of product
    /// </summary>
		[Required]
    public string Brand { get; set; }

    /// <summary>
    /// Type of product
    /// </summary>
		[Required]
    public string Type { get; set; }

  }
}