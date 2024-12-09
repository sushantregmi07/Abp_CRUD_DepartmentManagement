using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Susant.BookStore.Entities;

public class DepartmentType : AuditedAggregateRoot<long>
{
    public long Id { get; set; }
    public string Name { get; set; }

    // Navigation Property
    public ICollection<Department> Departments { get; set; }
}