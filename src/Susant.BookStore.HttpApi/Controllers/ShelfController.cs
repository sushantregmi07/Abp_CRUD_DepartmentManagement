using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Susant.BookStore.DTOs;
using Susant.BookStore.Interfaces;
using Volo.Abp.AspNetCore.Mvc;

namespace Susant.BookStore.Controllers;

[Route("api/shelf")]
public class ShelfController : AbpController
{
    private readonly IShelfService _shelfService;

    [HttpGet]
    public async Task<IEnumerable<ShelfDto>> GetListAsync()
    {
        return await _shelfService.GetAllAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ShelfDto> GetAsync(long id)
    {
        return await _shelfService.GetByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<ShelfDto> CreateAsync(CreateShelfDto shelfDto)
    {
        return await _shelfService.AddAsync(shelfDto);
    }
    
    [HttpPut("{id}")]
    public async Task UpdateAsync(long id, CreateShelfDto shelfDto)
    {
        await _shelfService.UpdateAsync(id, shelfDto);
    }
    
    [HttpDelete("{id}")]
    public async Task DeleteAsync(long id)
    {
        await _shelfService.DeleteAsync(id);
    }

}