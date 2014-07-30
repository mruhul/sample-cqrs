using System.Collections.Generic;

namespace Sample.Core.Dtos
{
    public class PagedResponse<T>
    {
        public long TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}