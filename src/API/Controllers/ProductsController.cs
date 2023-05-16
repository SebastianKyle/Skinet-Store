using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Specifications;
using Skinet.Core.DTO;
using Skinet.Core.Helpers;
using Skinet.Core.ServiceContracts.ProductServices;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductGetServices _productGetServices;

        public ProductsController(IProductGetServices productGetServices)
        {
            _productGetServices = productGetServices;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductResponse>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            Pagination<ProductResponse> paginationResponse = await _productGetServices.GetProductsAsync(productSpecParams);

            return Ok(paginationResponse);
        } 

        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)] // let swagger know that this action method will also return a 404 response
        public async Task<ActionResult<ProductResponse?>> GetProduct(Guid id)
        {
            ProductResponse? productResponse = await _productGetServices.GetProductByIdAsync(id);

            if (productResponse == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(productResponse);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrandResponse>>> GetBrands()
        {
            List<ProductBrandResponse> brandResponses = await _productGetServices.GetProductBrandsAsync();

            return Ok(brandResponses);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductTypeResponse>>> GetTypes()
        {
            List<ProductTypeResponse> typeResponses = await _productGetServices.GetProductTypesAsync();

            return Ok(typeResponses);
        }
    }
}