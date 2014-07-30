using Sample.Core.BootstrapperTasks;
using Sample.Core.Commands;
using Sample.Core.DomainModels;
using Sample.Core.Dtos;
using AutoMapper;

namespace Sample.Infrastructure.BootstrapperTasks
{
    public class AutomapperBootstrapperTask : IBoostrapperTask
    {
        public void Run()
        {
            Mapper.CreateMap<PagedResponse<Book>, PagedResponse<BookListItem>>();
            Mapper.CreateMap<Book, BookListItem>()
                .ForMember(x => x.ViewCount, opt => opt.Ignore());

            Mapper.CreateMap<CreateBook, Book>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
