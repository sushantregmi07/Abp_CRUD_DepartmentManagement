namespace Susant.BookStore.DTOs;

public class DepartmentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string UniqueCode { get; set; }
    public string ShortCode { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
    public long DepartmentTypeId { get; set; }
    public string DepartmentTypeName { get; set; }
}