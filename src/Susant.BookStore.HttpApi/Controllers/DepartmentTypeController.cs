using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Susant.BookStore.DTOs;
using Susant.BookStore.Interfaces;
using Volo.Abp.AspNetCore.Mvc;

namespace Susant.BookStore.Controllers;

[Route("api/department-type")]
public class DepartmentTypeController : AbpController
{
    private readonly IDepartmentTypeService _departmentTypeService;
    
    public DepartmentTypeController(IDepartmentTypeService departmentTypeService)
    {
        _departmentTypeService = departmentTypeService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DepartmentTypeDto>> GetAllAsync()
    {
        return await _departmentTypeService.GetAllAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<DepartmentTypeDto> GetByIdAsync(long id)
    {
        return await _departmentTypeService.GetByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<DepartmentTypeDto> AddAsync(CreateDepartmentTypeDto departmentTypeDto)
    {
        return await _departmentTypeService.AddAsync(departmentTypeDto);
    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(long id, CreateDepartmentTypeDto departmentTypeDto)
    {
        await _departmentTypeService.UpdateAsync(id, departmentTypeDto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(long id)
    {
        await _departmentTypeService.DeleteAsync(id);
    }
}