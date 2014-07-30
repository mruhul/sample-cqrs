using System.Threading.Tasks;
using Lib.SimpleCqrs;
using Lib.SimpleCqrs.Extended;
using Sample.Core.Commands;
using Sample.Core.DomainModels;
using Sample.Core.Mappers;
using Sample.Repositories;

namespace Sample.Infrastructure.CommandHandlers
{
    public class CreateBookHandler : IAsyncCommandHandler<CreateBook,CommandReply<long>>
    {
        private readonly IBooksRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookHandler(IBooksRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandReply<long>> HandleAsync(CreateBook command)
        {
            var book = _mapper.Map<CreateBook, Book>(command);

            await _repository.InsertAsync(book);

            return new CommandReply<long>
            {
                Succeed = true,
                Data = book.Id
            };
        }
    }
}
