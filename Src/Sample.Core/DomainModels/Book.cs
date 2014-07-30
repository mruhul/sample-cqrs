namespace Sample.Core.DomainModels
{
    public class Book : BaseEntity<long>
    {
        public string Title { get; set; }
    }
}
