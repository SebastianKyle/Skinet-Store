using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.ServiceContracts.BasketServices;

namespace Skinet.Core.Services.BasketServices
{
  public class BasketUpdateService : IBasketUpdateService
  {
    private readonly IBasketRepository _basketRepo;

    public BasketUpdateService(IBasketRepository basketRepo)
    {
      _basketRepo = basketRepo;
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
      CustomerBasket updatedBasket = await _basketRepo.UpdateBasketAsync(basket);

      return updatedBasket;
    }
  }
}