using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Susant.BookStore.DTOs;
using Susant.BookStore.Entities;
using Susant.BookStore.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Susant.BookStore.Services;

public class ShelfService : ApplicationService, IShelfService
{
    private readonly IRepository<Shelf, long> _shelfRepository;
    private readonly IMapper _mapper;

    public ShelfService(IRepository<Shelf, long> shelfRepository, IMapper mapper)
    {
        _shelfRepository = shelfRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ShelfDto>> GetAllAsync()
    {
        var shelves = await _shelfRepository.GetListAsync();
        return _mapper.Map<List<Shelf>, List<ShelfDto>>(shelves);
    }

    public async Task<ShelfDto> GetByIdAsync(long id)
    {
        var shelf = await _shelfRepository.GetAsync(id);
        return _mapper.Map<Shelf, ShelfDto>(shelf);
    }

    public async Task<ShelfDto> AddAsync(CreateShelfDto shelfDto)
    {
        var shelf = _mapper.Map<CreateShelfDto, Shelf>(shelfDto);
        var createdShelf = await _shelfRepository.InsertAsync(shelf);
        return _mapper.Map<Shelf, ShelfDto>(createdShelf);
    }

    public async Task UpdateAsync(long id, CreateShelfDto shelfDto)
    {
        var shelf = await _shelfRepository.GetAsync(id);
        _mapper.Map(shelfDto, shelf);
        await _shelfRepository.UpdateAsync(shelf);
    }

    public async Task DeleteAsync(long id)
    {
        await _shelfRepository.DeleteAsync(id);
    }
}