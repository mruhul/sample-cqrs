using System;
using System.Linq;
using System.Threading.Tasks;
using Lib.SimpleCqrs;
using Sample.Core.Dtos;
using Sample.Core.Queries;

namespace Sample.Infrastructure.QueryResultFilters
{
    public class BooksQueryResultFilter : IAsyncQueryResultFilter<GetBooks,PagedResponse<BookListItem>>
    {
        public async Task<PagedResponse<BookListItem>> FilterAsync(GetBooks query, PagedResponse<BookListItem> result)
        {
            var rnd = new Random();
            var booksWithViewCount = result.Items.ToList();

            booksWithViewCount.ForEach(x =>
            {
                x.ViewCount = rnd.Next(1, 1000);
                x.Rating = rnd.NextDouble() * 10;
            });

            result.Items = booksWithViewCount;
            
            return await Task.FromResult(result);
        }
    }
}
