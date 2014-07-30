using System.Threading.Tasks;
using AsyncPoco;
using Sample.Core.DomainModels;
using Sample.Core.Dtos;

namespace Sample.Repositories.SqlClient
{
    public class BooksRepository : IBooksRepository
    {
        private readonly Database _database;
        private readonly Core.Mappers.IMapper _mapper;

        public BooksRepository(Database database, Core.Mappers.IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<PagedResponse<Book>> GetAllAsync(PagedRequest request)
        {
            const string sqlSelect = "SELECT Id, Title FROM Book";

            var result = await _database.PageAsync<Book>(request.PageIndex, request.PageSize, sqlSelect);

            return _mapper.Map<Page<Book>, PagedResponse<Book>>(result);
        }

        public async Task InsertAsync(Book book)
        {
            const string sqlInsert = "INSERT INTO Book(Title) VALUES(@title); SELECT SCOPE_IDENTITY();";

            var result = await _database.ExecuteScalarAsync<long>(sqlInsert, new {title = book.Title});

            book.Id = result;
        }

        public async Task<bool> TitleExistsAsync(string title, long? id)
        {
            var sql = new Sql("SELECT COUNT(*) FROM Book");

            if (id.HasValue) sql = sql.Where("Id <> @0", id.Value);

            sql = sql.Where("Title = @0", title);

            var total = await _database.ExecuteScalarAsync<long>(sql);

            return total > 0;
        }
    }
}