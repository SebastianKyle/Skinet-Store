using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.ServiceContracts.BasketServices;

namespace Skinet.Core.Services.BasketServices
{
  public class BasketDeleteService : IBasketDeleteService
  {
    private readonly IBasketRepository _basketRepo;

    public BasketDeleteService(IBasketRepository basketRepo)
    {
      _basketRepo = basketRepo;
    }

    public async Task<bool> DeleteBasketAsync(string basketId)
    {
        bool succeeded = await _basketRepo.DeleteBasketAsync(basketId);

        return succeeded;
    }
  }
}