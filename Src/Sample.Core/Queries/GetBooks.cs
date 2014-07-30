using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.SimpleCqrs;
using Sample.Core.Dtos;

namespace Sample.Core.Queries
{
    public class GetBooks : PagedRequest, IQuery
    {
    }
}
