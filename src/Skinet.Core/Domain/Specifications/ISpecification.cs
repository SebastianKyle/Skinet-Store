using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skinet.Core.Domain.Specifications
{
    /// <summary>
    /// An interface that represents the specifications to retrieve entities
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// The criteria of the entity we want to retrieve
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Expressions that specify the properties we want to include while retrieving entities
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// Expression to specify ascending order of entities while retrieving
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// Expression to specify descending order of entities while retrieving
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }

        /// <summary>
        /// User decision to take a certain amount of records
        /// </summary>
        int Take { get; }

        /// <summary>
        /// User decision to skip a certain amount of records
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// Specify if paging is enabled
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}