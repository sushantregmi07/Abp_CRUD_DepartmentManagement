using System.Collections.Generic;
using System.Threading.Tasks;
using Susant.BookStore.DTOs;

namespace Susant.BookStore.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<BookDto> GetByIdAsync(long id);
    Task<BookDto> AddAsync(CreateBookDto bookDto);
    Task UpdateAsync(long id, CreateBookDto bookDto);
    Task DeleteAsync(long id);
}