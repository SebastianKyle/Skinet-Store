using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Core.Helpers
{
    /// <summary>
    /// Generic class used for containing details about pagination while retrieving entities
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, List<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        /// <summary>
        /// Index of page
        /// </summary>
        public int PageIndex { get; set; } 

        /// <summary>
        /// Size of page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Amount of entities retrieved
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// List of entities details 
        /// </summary>
        public List<T> Data { get; set; } 
    }
}