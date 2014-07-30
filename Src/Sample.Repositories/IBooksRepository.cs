using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Core;
using Sample.Core.DomainModels;
using Sample.Core.Dtos;

namespace Sample.Repositories
{
    public interface IBooksRepository
    {
        Task<PagedResponse<Book>> GetAllAsync(PagedRequest request);
        Task InsertAsync(Book book);
        Task<bool> TitleExistsAsync(string title, long? id);
    }
}
