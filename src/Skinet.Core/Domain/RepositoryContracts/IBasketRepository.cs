using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.Domain.RepositoryContracts
{
    /// <summary>
    /// A repository for performing operations of getting, updating and deleting customer baskets by accessing Redis
    /// </summary>
    public interface IBasketRepository
    {
        /// <summary>
        /// Get a customer basket base on given basket id
        /// </summary>
        /// <param name="basketId">Basket id to search</param>
        /// <returns>Matching CustomerBasket object</returns>
        Task<CustomerBasket?> GetBasketAsync(string basketId);

        /// <summary>
        /// Update customer basket
        /// </summary>
        /// <param name="basket">CustomerBasket for updating</param>
        /// <returns>The updated CustomerBasket object</returns>
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        /// <summary>
        /// Delete a customer basket base on given basket id
        /// </summary>
        /// <param name="basketId">Basket id to search</param>
        /// <returns>Boolean value to indicate wether the basket has been deleted successfully</returns>
        Task<bool> DeleteBasketAsync(string basketId);
    }
}