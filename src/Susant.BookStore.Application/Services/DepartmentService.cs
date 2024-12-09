using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Susant.BookStore.DTOs;
using Susant.BookStore.Entities;
using Susant.BookStore.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Susant.BookStore.Services;

public class DepartmentService : ApplicationService, IDepartmentService
{
    private readonly IRepository<Department, long> _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IRepository<Department, long> directionalRepository, IMapper mapper)
    {
        _departmentRepository = directionalRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        /*var departments = await _departmentRepository.GetListAsync();
        return _mapper.Map<List<Department>, List<DepartmentDto>>(departments);*/
        
        var departments = await _departmentRepository.GetQueryableAsync();

        var departmentDtos = await departments
            .Include(d => d.DepartmentType)
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                UniqueCode = d.UniqueCode,
                ShortCode = d.ShortCode,
                Location = d.Location,
                IsActive = d.IsActive,
                DepartmentTypeId = d.DepartmentTypeId,
                DepartmentTypeName = d.DepartmentType.Name // Dynamically map the name
            })
            .ToListAsync();

        return departmentDtos;
    }

    public async Task<DepartmentDto> GetByIdAsync(long id)
    {
       /*var department = await _departmentRepository.GetAsync(id);
       return _mapper.Map<Department, DepartmentDto>(department);*/
       
       // Fetch the department along with the related DepartmentType
       var department = await _departmentRepository
           .WithDetails(d => d.DepartmentType) // Includes related DepartmentType
           .FirstOrDefaultAsync(d => d.Id == id);

       if (department == null)
       {
           throw new EntityNotFoundException($"Department with ID {id} not found.");
       }

       // Map to DTO
       var departmentDto = new DepartmentDto
       {
           Id = department.Id,
           Name = department.Name,
           UniqueCode = department.UniqueCode,
           ShortCode = department.ShortCode,
           Location = department.Location,
           IsActive = department.IsActive,
           DepartmentTypeId = department.DepartmentTypeId,
           DepartmentTypeName = department.DepartmentType?.Name // Safely map the name
       };

       return departmentDto;
    }

    public async Task<DepartmentDto> AddAsync(CreateDepartmentDto departmentDto)
    {
        var department = _mapper.Map<CreateDepartmentDto, Department>(departmentDto);
        var createdDepartment = await _departmentRepository.InsertAsync(department);
        return _mapper.Map<Department, DepartmentDto>(createdDepartment);
    }

    public async Task UpdateAsync(long id, CreateDepartmentDto departmentDto)
    {
        var department = await _departmentRepository.GetAsync(id);
        _mapper.Map(departmentDto, department);
        await _departmentRepository.UpdateAsync(department);
    }

    public async Task DeleteAsync(long id)
    {
        await _departmentRepository.DeleteAsync(id);
    }
}