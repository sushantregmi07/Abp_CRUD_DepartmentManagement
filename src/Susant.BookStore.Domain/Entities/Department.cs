using Volo.Abp.Domain.Entities.Auditing;

namespace Susant.BookStore.Entities;

public class Department : AuditedAggregateRoot<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string UniqueCode { get; set; }
    public string ShortCode { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; } = true;

    // Foreign Key
    public long DepartmentTypeId { get; set; }

    // Navigation Property
    public DepartmentType DepartmentType { get; set; }
}