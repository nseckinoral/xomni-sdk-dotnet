using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model
{
    /// <summary>
    /// A container of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CountedCollectionContainer<T>
    {
        /// <summary>
        /// A paged generic list of entity
        /// </summary>
        public List<T> Results { get; set; }
        /// <summary>
        /// Total count of entity in the filtered collection without paging
        /// </summary>
        public int TotalCount { get; set; }

        public CountedCollectionContainer(List<T> results, int totalCount)
        {
            this.Results = results;
            this.TotalCount = totalCount;
        }
    }
}
