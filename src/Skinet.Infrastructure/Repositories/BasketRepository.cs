using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.RepositoryContracts;
using StackExchange.Redis;

namespace Skinet.Infrastructure.Repositories
{
  public class BasketRepository : IBasketRepository
  {
    private readonly IDatabase _db;

    public BasketRepository(IConnectionMultiplexer redis)
    {
      _db = redis.GetDatabase();
    }

    public async Task<bool> DeleteBasketAsync(string basketId)
    {
			return await _db.KeyDeleteAsync(basketId);
    }

    public async Task<CustomerBasket?> GetBasketAsync(string basketId)
    {
      var data = await _db.StringGetAsync(basketId);

      return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
			// Update
      var created = await _db.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(1));

			if (!created) 
			{
				return null;
			}

			return await GetBasketAsync(basket.Id);
    }
  }
}