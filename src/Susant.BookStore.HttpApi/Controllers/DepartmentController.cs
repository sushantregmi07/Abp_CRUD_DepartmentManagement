using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Susant.BookStore.DTOs;
using Susant.BookStore.Interfaces;
using Volo.Abp.AspNetCore.Mvc;

namespace Susant.BookStore.Controllers;

[Route("api/department")]
public class DepartmentController : AbpController
{
    private readonly IDepartmentService _departmentService;
    
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        return await _departmentService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<DepartmentDto> GetByIdAsync(long id)
    {
        return await _departmentService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<DepartmentDto> AddAsync(CreateDepartmentDto departmentDto)
    {
        return await _departmentService.AddAsync(departmentDto);
    }
    
    [HttpPut("{id}")]
    public async Task UpdateAsync(long id, CreateDepartmentDto departmentDto)
    {
        await _departmentService.UpdateAsync(id, departmentDto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(long id)
    {
        await _departmentService.DeleteAsync(id);
    }
}