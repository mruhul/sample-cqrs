using Lib.SimpleCqrs;
using Sample.Core.Dtos;

namespace Sample.Core.Queries
{
    public class GetBooks : PagedRequest, IQuery
    {
    }
}
