using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Susant.BookStore.DTOs;
using Susant.BookStore.Entities;
using Susant.BookStore.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Susant.BookStore.Services;

public class DepartmentTypeService : ApplicationService, IDepartmentTypeService
{
    private readonly IRepository<DepartmentType, long> _departmentTypeRepository;
    private readonly IMapper _mapper;

    public DepartmentTypeService(IRepository<DepartmentType, long> departmentTypeRepository, IMapper mapper)
    {
        _departmentTypeRepository = departmentTypeRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DepartmentTypeDto>> GetAllAsync()
    {
        var departmentTypes = await _departmentTypeRepository.GetListAsync();
        return _mapper.Map<List<DepartmentType>, List<DepartmentTypeDto>>(departmentTypes);
    }

    public async Task<DepartmentTypeDto> GetByIdAsync(long id)
    {
        var departmentType = await _departmentTypeRepository.GetAsync(id);
        return _mapper.Map<DepartmentType, DepartmentTypeDto>(departmentType);
    }

    public async Task<DepartmentTypeDto> AddAsync(CreateDepartmentTypeDto departmentTypeDto)
    {
        var departmentType = _mapper.Map<CreateDepartmentTypeDto, DepartmentType>(departmentTypeDto);
        var createdDepartmentType = await _departmentTypeRepository.InsertAsync(departmentType);
        return _mapper.Map<DepartmentType, DepartmentTypeDto>(createdDepartmentType);
    }

    public async Task UpdateAsync(long id, CreateDepartmentTypeDto departmentTypeDto)
    {
        var departmentType = await _departmentTypeRepository.GetAsync(id);
        _mapper.Map(departmentTypeDto, departmentType);
        await _departmentTypeRepository.UpdateAsync(departmentType);
    }

    public async Task DeleteAsync(long id)
    {
        await _departmentTypeRepository.DeleteAsync(id);
    }
}