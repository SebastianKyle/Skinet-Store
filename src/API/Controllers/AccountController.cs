using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Errors;
using API.StartupExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Domain.Entities.Identity;
using Skinet.Core.DTO;
using Skinet.Core.ServiceContracts.TokenServices;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccountController : BaseApiController
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
    {
      _mapper = mapper;
      _signInManager = signInManager;
      _userManager = userManager;
      _tokenService = tokenService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetCurrentUser()
    {
      var user = await _userManager.FindUserByClaimsPrincipleAsync(User);

      return user.ToUserDTO(_tokenService);
    }

    [HttpGet("emailexists")]
    public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
    {
      return await _userManager.FindByEmailAsync(email) != null;
    }

    [Authorize]
    [HttpGet("address")]
    public async Task<ActionResult<AddressDTO>> GetUserAddress()
    {
      var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);

      return _mapper.Map<Address, AddressDTO>(user.Address);
    }

    [Authorize]
    [HttpPut("address")]
    public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO address)
    {
      var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User); 

      user.Address = _mapper.Map<AddressDTO, Address>(address);
      var result = await _userManager.UpdateAsync(user);

      if (!result.Succeeded)
      {
        return BadRequest("Problem updating new user");
      }

      return _mapper.Map<Address, AddressDTO>(user.Address);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
    {
      var user = await _userManager.FindByEmailAsync(loginDTO.Email);
      if (user == null)
      {
        return Unauthorized(new ApiResponse(401));
      }

      var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

      if (!result.Succeeded)
      {
        return Unauthorized(new ApiResponse(401));
      }

      return user.ToUserDTO(_tokenService);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
    {
      var user = new AppUser()
      {
        DisplayName = registerDTO.DisplayName,
        Email = registerDTO.Email,
        UserName = registerDTO.Email
      };

      var result = await _userManager.CreateAsync(user, registerDTO.Password);

      if (!result.Succeeded)
      {
        return BadRequest(new ApiResponse(400));
      }

      return user.ToUserDTO(_tokenService);
    }
  }
}