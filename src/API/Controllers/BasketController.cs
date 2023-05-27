using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Domain.Entities;
using Skinet.Core.DTO;
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
    private readonly IMapper _mapper;

    public BasketController(IBasketGetService basketGetService, IBasketUpdateService basketUpdateService, IBasketDeleteService basketDeleteService, IMapper mapper)
    {
      _mapper = mapper;
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
		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDTO basketDTO)
		{
			var basket = _mapper.Map<CustomerBasketDTO, CustomerBasket>(basketDTO);	
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