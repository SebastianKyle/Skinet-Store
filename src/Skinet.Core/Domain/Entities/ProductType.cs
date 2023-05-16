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
      ProductType productType = new ProductType() {
        Id = Guid.NewGuid(),
        Name = productTypeAddRequest.Name
      };

      return productType;
    }
  }
}