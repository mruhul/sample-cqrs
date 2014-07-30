using System.Threading.Tasks;
using Lib.SimpleCqrs;
using Sample.Core;
using Sample.Core.DomainModels;
using Sample.Core.Dtos;
using Sample.Core.Mappers;
using Sample.Core.Queries;
using Sample.Repositories;

namespace Sample.Infrastructure.QueryHandlers
{
    public class GetBooksHandler : IAsyncQueryHandler<GetBooks,PagedResponse<BookListItem>>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public GetBooksHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<BookListItem>> HandleAsync(GetBooks query)
        {
            var result = await _booksRepository.GetAllAsync(query);

            return _mapper.Map<PagedResponse<Book>, PagedResponse<BookListItem>>(result);
        }
    }
}
