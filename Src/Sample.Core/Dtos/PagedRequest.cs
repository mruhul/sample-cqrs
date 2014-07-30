using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Dtos
{
    public interface IPagedRequest
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
    }

    public class PagedRequest : IPagedRequest
    {
        public PagedRequest()
        {
            PageIndex = 1;
            PageSize = 15;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
