using System.Collections.Generic;
using System.Threading.Tasks;
using Susant.BookStore.DTOs;

namespace Susant.BookStore.Interfaces;

public interface IDepartmentTypeService
{
    Task<IEnumerable<DepartmentTypeDto>> GetAllAsync();
    Task<DepartmentTypeDto> GetByIdAsync(long id);
    Task<DepartmentTypeDto> AddAsync(CreateDepartmentTypeDto departmentTypeDto);
    Task UpdateAsync(long id, CreateDepartmentTypeDto departmentTypeDto);
    Task DeleteAsync(long id);
}