using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.ServiceContracts.BasketServices
{
    /// <summary>
    /// A service performs operation of deleting customer basket
    /// </summary>
    public interface IBasketDeleteService
    {
        /// <summary>
        /// Delete a basket base on basket id
        /// </summary>
        /// <param name="basketId">Id of basket to search</param>
        /// <returns>Boolean value indicating wether deletion has been done successfully</returns>
        Task<bool> DeleteBasketAsync(string basketId);
    }
}