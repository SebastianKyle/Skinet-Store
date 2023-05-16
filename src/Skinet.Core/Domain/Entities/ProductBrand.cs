namespace Skinet.Core.Domain.Entities
{
  public class ProductBrand : BaseEntity
  {
    public string Name { get; set; }
  }

  public static class ProductExtensions
  {
    public static ProductBrand ToProductBrand(this ProductBrand productBrand)
    {
      ProductBrand newProduct = new ProductBrand() {
        Id = Guid.NewGuid(),
        Name = productBrand.Name
      };

      return newProduct;
    }
  }
}