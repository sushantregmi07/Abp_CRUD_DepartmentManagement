using Volo.Abp.Domain.Entities.Auditing;

namespace Susant.BookStore.Entities;

public class Book : AuditedAggregateRoot<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public long ShelfId { get; set; }
    public Shelf Shelf { get; set; }
}