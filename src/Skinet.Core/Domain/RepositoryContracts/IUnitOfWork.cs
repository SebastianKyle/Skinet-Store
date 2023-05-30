using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.Domain.RepositoryContracts
{
    /// <summary>
    /// A repository that instantiate instances of generic repository base on the given entity type and save changes after operations
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Return instance of generic repository based on given entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Corresponding generic repository instance</returns>
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity; 

        /// <summary>
        /// Save changes to database
        /// </summary>
        /// <returns>Amount of operated entities</returns>
        Task<int> Complete();
    }
}