using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace Susant.BookStore.Entities;

public class Shelf : AuditedAggregateRoot<long>
{
    public long Id { get; set; }
    public string RackName { get; set; }
    public ICollection<Book> Books { get; set; }
}