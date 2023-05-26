using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Core.ServiceContracts.ProductServices;
using Skinet.Infrastructure.Data;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BuggyController : BaseApiController
  {
    private readonly IProductGetServices _productGetService;

    public BuggyController(IProductGetServices productGetServices)
    {
      _productGetService = productGetServices;
    }

    [HttpGet("testauth")]
    [Authorize]
    public ActionResult<string> GetSecretText()
    {
      return "secret stuff";
    }

    [HttpGet("notfound")]
    public async Task<ActionResult> GetNotFoundRequest()
    {
      var thing = await _productGetService.GetProductByIdAsync(42);

      if (thing == null)
      {
        return NotFound(new ApiResponse(404));
      }

      return Ok();
    }

    [HttpGet("servererror")]
    public async Task<ActionResult> GetServerErrorAsync()
    {
      var thing = await _productGetService.GetProductByIdAsync(42);

      var thingToReturn = thing.ToString();

      return Ok();
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {


      return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id)
    {
      return Ok();
    }
  }
}