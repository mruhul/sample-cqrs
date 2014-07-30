namespace Sample.Core.DomainModels
{
    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}