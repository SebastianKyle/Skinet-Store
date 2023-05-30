using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Errors;
using API.StartupExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Domain.Entities.OrderAggregate;
using Skinet.Core.DTO;
using Skinet.Core.ServiceContracts.OrderServices;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class OrdersController : BaseApiController
  {
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
      _orderService = orderService;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDTO)
    {
      var email = User.RetrieveEmailFromPrinciple();

      var address = _mapper.Map<AddressDTO, Skinet.Core.Domain.Entities.OrderAggregate.Address>(orderDTO.ShipToAddress);

      var order = await _orderService.CreateOrderAsync(email, orderDTO.DeliveryMethodId, orderDTO.BasketId, address);

      if (order == null) {
        return BadRequest(new ApiResponse(400, "Problem creating order"));
      }
        
      return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<OrderReturnDTO>>> GetOrdersForUser()
    {
      var email = User.RetrieveEmailFromPrinciple();

      var orders = await _orderService.GetOrdersForUserAsync(email);

      return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderReturnDTO>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReturnDTO>> GetOrderByIdForUser(int id) 
    {
      var email = User.RetrieveEmailFromPrinciple();
      var order = await _orderService.GetOrderByIdAsync(id, email);

      if (order == null) {
        return NotFound(new ApiResponse(404));
      }

      return _mapper.Map<Order, OrderReturnDTO>(order);
    }

    [HttpGet("DeliveryMethods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
      return Ok(await _orderService.GetDeliveryMethodsAsync());
    }
  }
}