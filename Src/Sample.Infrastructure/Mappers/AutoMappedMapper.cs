using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Core.Mappers;

namespace Sample.Infrastructure.Mappers
{
    public class AutoMappedMapper : IMapper
    {
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return AutoMapper.Mapper.Map<TTarget>(source);
        }
    }
}
