using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext storeDbContext)
        {
            try {
                if (!storeDbContext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/brands.json");

                    List<ProductBrand>? brands = System.Text.Json.JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var brand in brands)
                    {
                        storeDbContext.ProductBrands.Add(brand);
                    }

                    await storeDbContext.SaveChangesAsync();
                }

                if (!storeDbContext.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/types.json");

                    List<ProductType>? types = System.Text.Json.JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var type in types)
                    {
                        storeDbContext.ProductTypes.Add(type);
                    }

                    await storeDbContext.SaveChangesAsync();
                }

                if (!storeDbContext.Products.Any())
                {
                    var productsData = File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/products.json");

                    List<Product>? products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        storeDbContext.Products.Add(product);
                    }

                    await storeDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // TODO: use ILogger to log information in case any problem while seeding data 
            }
        } 
    }
}