using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Core.BootstrapperTasks;
using Sample.Core.DomainModels;
using Sample.Core.Dtos;

namespace Sample.Repositories.BootstrapperTasks
{
    public class AutomapperBootstrapperTask : IBoostrapperTask
    {
        public void Run()
        {
            AutoMapper.Mapper.CreateMap<AsyncPoco.Page<Book>, PagedResponse<Book>>()
                .ForMember(x => x.TotalItems, opt => opt.MapFrom(source => source.TotalItems))
                .ForMember(x => x.TotalPages, opt => opt.MapFrom(source => (int)source.TotalPages));
        }
    }
}
