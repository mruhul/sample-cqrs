using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Dtos
{
    public class BookListItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ViewCount { get; set; }
        public double Rating { get; set; }
    }
}
