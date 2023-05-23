using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.ServiceContracts.BasketServices
{
    /// <summary>
    /// A service performs operation of updating customer basket
    /// </summary>
    public interface IBasketUpdateService
    {
        /// <summary>
        /// Update customer basket
        /// </summary>
        /// <param name="basket">CustomerBasket object for updating</param>
        /// <returns>CustomerBasket object after updating</returns>
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    }
}