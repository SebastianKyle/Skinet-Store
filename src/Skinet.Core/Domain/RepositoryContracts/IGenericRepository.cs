using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Specifications;

namespace Skinet.Core.Domain.RepositoryContracts
{
    /// <summary>
    /// A generic repository used for multiples entities which performs operations of retrieving entities from database
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieve entity based on given id 
        /// </summary>
        /// <param name="id">Id of entity to search</param>
        /// <returns>Matching entity with given id</returns>
        Task<T> GetByIdAsync(int id); 

        /// <summary>
        /// Retrieve all entites
        /// </summary>
        /// <returns>List of entities</returns>
        Task<List<T>> ListAllAsync();

        /// <summary>
        /// Get entity with specifications filter 
        /// </summary>
        /// <param name="spec">Specifications to filter entities</param>
        /// <returns>Entity that satisfy specifications</returns>
        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        /// <summary>
        /// Retrieve all entities that satisfy specifications
        /// </summary>
        /// <param name="spec">Specifications to filter entities</param>
        /// <returns>List of entities that satisfy specifications</returns>
        Task<List<T>> ListAsync(ISpecification<T> spec);

        /// <summary>
        /// Count the amount of entities that satisfy specification
        /// </summary>
        /// <param name="spec">Specifications to apply</param>
        /// <returns>Amount of entities that satisfy specifications</returns>
        Task<int> CountAsync(ISpecification<T> spec);

        /// <summary>
        /// Add the entity type into database table
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Update entity in database table 
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(T entity);

        /// <summary>
        /// Delete entity from database table
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(T entity);
    }
}