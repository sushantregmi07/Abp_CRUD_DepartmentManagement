using System.Collections.Generic;
using System.Threading.Tasks;
using Susant.BookStore.DTOs;

namespace Susant.BookStore.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync();
    Task<DepartmentDto> GetByIdAsync(long id);
    Task<DepartmentDto> AddAsync(CreateDepartmentDto departmentDto);
    Task UpdateAsync(long id, CreateDepartmentDto departmentDto);
    Task DeleteAsync(long id);
}