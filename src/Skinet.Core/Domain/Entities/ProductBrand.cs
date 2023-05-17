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
      Random random = new Random();
      ProductBrand newProduct = new ProductBrand() {
        Id = random.Next(0, 100000),
        Name = productBrand.Name
      };

      return newProduct;
    }
  }
}