using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.ServiceContracts.BasketServices;

namespace Skinet.Core.Services.BasketServices
{
  public class BasketGetService : IBasketGetService
  {
    private readonly IBasketRepository _basketRepo;

    public BasketGetService(IBasketRepository basketRepo)
    {
      _basketRepo = basketRepo;
    }

    public async Task<CustomerBasket?> GetBasketAsync(string basketId)
    {
        CustomerBasket? basketFromGet = await _basketRepo.GetBasketAsync(basketId);

        return basketFromGet;
    }
  }
}