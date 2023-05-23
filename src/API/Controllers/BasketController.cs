using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Domain.Entities;
using Skinet.Core.ServiceContracts.BasketServices;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BasketController : BaseApiController
  {
    private readonly IBasketGetService _basketGetService;
    private readonly IBasketUpdateService _basketUpdateService;
    private readonly IBasketDeleteService _basketDeleteService;

    public BasketController(IBasketGetService basketGetService, IBasketUpdateService basketUpdateService, IBasketDeleteService basketDeleteService)
    {
      _basketGetService = basketGetService;
      _basketUpdateService = basketUpdateService;
      _basketDeleteService = basketDeleteService;
    }

		[HttpGet]
		public async Task<ActionResult<CustomerBasket>> GetBasketById(string id) 
		{
			var basket = await _basketGetService.GetBasketAsync(id);

			return Ok(basket ?? new CustomerBasket(id));
		}

		[HttpPost]
		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
		{
			var updatedBasket = await _basketUpdateService.UpdateBasketAsync(basket);

			return Ok(updatedBasket);
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteBasketById(string id)
		{
			bool deleted = await _basketDeleteService.DeleteBasketAsync(id);

			return deleted;
		}
  }
}