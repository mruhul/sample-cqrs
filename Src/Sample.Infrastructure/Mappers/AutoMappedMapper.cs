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
