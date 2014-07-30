namespace Sample.Core.DomainModels
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}