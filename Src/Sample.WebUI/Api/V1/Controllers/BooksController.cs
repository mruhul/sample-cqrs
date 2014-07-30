using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Lib.SimpleCqrs;
using Lib.SimpleCqrs.Extended;
using Sample.Core;
using Sample.Core.Commands;
using Sample.Core.Dtos;
using Sample.Core.Logger;
using Sample.Core.Queries;
using Sample.Repositories;
using Sample.WebUI.Extensions;

namespace Sample.WebUI.Api.V1.Controllers
{
    [RoutePrefix("api/v1/cqrs/books")]
    public class BooksController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ILogger _logger;

        public BooksController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher, ILogger logger)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _logger = logger;
        }

        [Route("{id}", Name = "GetBookById")]
        public async Task<IHttpActionResult> Get([FromUri] long id)
        {
            throw new NotImplementedException();
        }

        [Route(Name = "GetBooks")]
        public async Task<IHttpActionResult> Get([FromUri]GetBooks query)
        {
            _logger.Debug("start requesting...");

            var result = await _queryDispatcher.DispatchAsync<GetBooks, PagedResponse<BookListItem>>(query ?? new GetBooks());

            return Ok(result);
        }

        [Route(Name = "CreateBook")]
        public async Task<IHttpActionResult> Post([FromBody] CreateBook createBook)
        {
            var reply = await _commandDispatcher.DispatchAsync<CreateBook, CommandReply<long>>(createBook);

            return this.CommandResult(reply, () => Url.BookDetails(reply.Data));
        }
    }
}
