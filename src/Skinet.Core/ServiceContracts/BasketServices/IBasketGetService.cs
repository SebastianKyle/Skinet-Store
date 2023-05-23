using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.ServiceContracts.BasketServices
{
    /// <summary>
    /// A service performs operation of getting customer basket through basket repository
    /// </summary>
    public interface IBasketGetService
    {
        /// <summary>
        /// Get customer basket base on given basketId
        /// </summary>
        /// <param name="basketId">Basket id to search</param>
        /// <returns>Matching CustomerBasket object</returns>
        Task<CustomerBasket?> GetBasketAsync(string basketId);
    }
}