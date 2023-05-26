using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities.Identity;

namespace Skinet.Core.ServiceContracts.TokenServices
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}