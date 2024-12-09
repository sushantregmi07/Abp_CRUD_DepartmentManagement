using System.Collections.Generic;
using System.Threading.Tasks;
using Susant.BookStore.DTOs;

namespace Susant.BookStore.Interfaces;

public interface IShelfService
{
    Task<IEnumerable<ShelfDto>> GetAllAsync();
    Task<ShelfDto> GetByIdAsync(long id);
    Task<ShelfDto> AddAsync(CreateShelfDto shelfDto);
    Task UpdateAsync(long id, CreateShelfDto shelfDto);
    Task DeleteAsync(long id);
}