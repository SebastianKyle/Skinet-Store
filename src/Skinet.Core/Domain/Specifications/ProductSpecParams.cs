using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.Domain.Specifications
{
    /// <summary>
    /// Class containing detailf of user retrievement request with pagination
    /// </summary>
    public class ProductSpecParams
    {
        /// <summary>
        /// Maximum entities in a single page
        /// </summary>
        private const int MaxPageSize = 50;

        /// <summary>
        /// Index of page
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Amount of element in each page
        /// </summary>
        private int _pageSize = 6;
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
        }

        /// <summary>
        /// Id of product branch to retrieve
        /// </summary>
        public Guid? BrandId { get; set; }

        /// <summary>
        /// Id of product type to retrieve
        /// </summary>
        public Guid? TypeId { get; set; }

        /// <summary>
        /// Sorting order
        /// </summary>
        public string? Sort { get; set; }

        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value?.ToLower();
        }
    }
}