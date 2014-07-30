namespace Sample.Core.Mappers
{
    public interface IMapper
    {
        TTarget Map<TSource,TTarget>(TSource source);
    }
}
