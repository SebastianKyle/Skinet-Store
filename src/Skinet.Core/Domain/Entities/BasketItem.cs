namespace Skinet.Core.Domain.Entities
{
  /// <summary>
  /// A class that represents an item in customer basket
  /// </summary>
  public class BasketItem
  {
    /// <summary>
    /// Unique id or product
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of product
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Price of product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity of current product customer want
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Url to product picture
    /// </summary>
    public string PictureUrl { get; set; }

    /// <summary>
    /// Brand of product
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Type of product
    /// </summary>
    public string Type { get; set; }
  }
}