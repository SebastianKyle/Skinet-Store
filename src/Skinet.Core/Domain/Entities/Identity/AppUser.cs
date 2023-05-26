using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Skinet.Core.DTO;
using Skinet.Core.ServiceContracts.TokenServices;

namespace Skinet.Core.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; } 
        public Address Address { get; set; }
    }

    public static class AppUserExtensions
    {
        public static UserDTO ToUserDTO(this AppUser appUser, ITokenService tokenService)
        {
            UserDTO newUserDTO = new UserDTO() {
                Email = appUser.Email,
                Token = tokenService.CreateToken(appUser),
                DisplayName = appUser.DisplayName
            };

            return newUserDTO;
        }
    }
}