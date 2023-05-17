using Skinet.Core.DTO;

namespace Skinet.Core.Domain.Entities
{
  public class ProductType : BaseEntity
  {
    public string Name { get; set; }
  }

  public static class ProductTypeAddRequestExtensions
  {
    public static ProductType ToProductType(this ProductTypeAddRequest productTypeAddRequest)
    {
      Random random = new Random();
      ProductType productType = new ProductType() {
        Id = random.Next(0, 100000),
        Name = productTypeAddRequest.Name
      };

      return productType;
    }
  }
}