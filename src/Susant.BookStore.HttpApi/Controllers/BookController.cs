using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Susant.BookStore.DTOs;
using Susant.BookStore.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Susant.BookStore.Controllers;

[Route("api/books")]
public class BookController : AbpController
{
    private readonly IBookService _bookService;

    [HttpGet]
    public async Task<IEnumerable<BookDto>> GetListAsync()
    {
        return await _bookService.GetAllAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<BookDto> GetAsync(long id)
    {
        return await _bookService.GetByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<BookDto> CreateAsync(CreateBookDto input)
    {
        return await _bookService.AddAsync(input);
    }
    
    [HttpPut("{id}")]
    public async Task UpdateAsync(long id, CreateBookDto input)
    {
        await _bookService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id}")]
    public async Task DeleteAsync(long id)
    {
        await _bookService.DeleteAsync(id);
    }
}